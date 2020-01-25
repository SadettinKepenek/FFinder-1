﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FFinder.BLL.Abstract;
using FFinder.BLL.Validators.User;
using FFinder.Core.Authentication;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Core.Exception;
using FFinder.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FFinder.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AuthIdentityUser> _userManager;
        private readonly SignInManager<AuthIdentityUser> _signInManager;
        private readonly RoleManager<AuthIdentityRole> _roleManager;
        private readonly IPasswordHasher<AuthIdentityUser> _passwordHasher;
        private IHttpContextAccessor _httpContext;
        private IMapper _mapper;

        public AuthManager(UserManager<AuthIdentityUser> userManager, SignInManager<AuthIdentityUser> signInManager, IPasswordHasher<AuthIdentityUser> passwordHasher, IHttpContextAccessor httpContext, IMapper mapper, RoleManager<AuthIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _httpContext = httpContext;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public UserLoginResponseDto Login(UserLoginRequestDto dto)
        {
            try
            {
                UserLoginRequestValidator validator = new UserLoginRequestValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.ToString());
                }

                //
                var user = _userManager.FindByNameAsync(dto.Username).Result;
                if (user == null)
                {
                    throw new NullReferenceException();
                }

                var resultSucceeded = MatchPasswordAndHash(user, dto.Password);
                if (resultSucceeded)
                {
                    var generateTokenModel = GenerateToken(user, DateTime.Now.AddYears(10));
                    var authenticateModel = new UserLoginResponseDto()
                    {
                        Username = user.UserName,
                        Token = generateTokenModel,
                        TokenExpireDate = DateTime.Now.AddYears(10),
                        Id = user.Id
                    };
                    return authenticateModel;
                }

                throw new UnauthorizedAccessException("Kullanıcı adı veya şifre yanlış");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task Register(UserAddDto userAddModel, string password)
        {
            //
            try
            {
                UserAddValidator validator = new UserAddValidator();
                var validationResult = validator.Validate(userAddModel);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.ToString());
                }

                var identityUser = _mapper.Map<AuthIdentityUser>(userAddModel);

               var findResult=await _userManager.FindByNameAsync(identityUser.UserName);
               if (findResult!=null)
               {
                   throw new ValidationException("Kullanıcı zaten mevcut");
               }

                var createdUser = await
                    _userManager.CreateAsync(
                        identityUser, password);
                if (!createdUser.Succeeded)
                {
                    throw new Exception("Kayıt sırasında hata oluştu.");
                }


                var role = await _roleManager.FindByNameAsync("User");
                if (role==null)
                {
                    var result=await _roleManager.CreateAsync(new AuthIdentityRole() {Name = "User"});
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(identityUser, "User");
                    }
                    else
                    {
                        throw new Exception("Rol eklenirken hata oluştu");
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(UserUpdateDto userUpdateModel, string password)
        {
            try
            {
                UserUpdateValidator validator = new UserUpdateValidator();
                var validationResult = validator.Validate(userUpdateModel);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.ToString());
                }

                var user = _userManager.FindByNameAsync(userUpdateModel.UserName).Result;
                if (user == null)
                {
                    throw new NullReferenceException();
                }
                var newPassword = _passwordHasher.HashPassword(user, password);
                user.Firstname = userUpdateModel.Firstname;
                user.Lastname = userUpdateModel.Lastname;
                user.Email = userUpdateModel.Email;
                user.PasswordHash = newPassword;
                user.IsActive = userUpdateModel.IsActive;
                user.FacebookUrl = userUpdateModel.FacebookUrl;
                user.ViberUrl = userUpdateModel.ViberUrl;
                user.Country = userUpdateModel.Country;
                user.Town = userUpdateModel.Town;
                user.InstagramUrl = userUpdateModel.InstagramUrl;
                user.LinkedInUrl = userUpdateModel.LinkedInUrl;
                user.ProfilePhotoUrl = userUpdateModel.ProfilePhotoUrl;
                user.TwitterUrl = userUpdateModel.TwitterUrl;
                var result = _userManager.UpdateAsync(user).Result;
                if (!result.Succeeded)
                {
                    throw new Exception("Güncelleme sırasında hata oluştu");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(string username)
        {
            try
            {


                var applicationIdentityUser = _userManager.FindByNameAsync(username).Result;
                if (applicationIdentityUser == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    var result = _userManager.DeleteAsync(applicationIdentityUser);
                    if (result.IsCompletedSuccessfully)
                    {
                        // Do Nothing
                    }
                    else if (result.IsFaulted)
                    {
                        throw new Exception("Silme sırasında hata oluştu");
                    }
                    else if (result.IsCanceled)
                    {
                        throw new Exception("Silme iptal edildi");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserDetailDto GetUser()
        {
            var user = _httpContext.HttpContext.User.Identity.Name;
            if (user == null)
            {
                throw new NullReferenceException("");
            }

            var dbUser = _userManager.Users.
                Include(x => x.PostRate).
                Include(x => x.Post).
                Include(x => x.CommentRate).
                Include(x => x.Comment).
                FirstOrDefault(x => x.UserName == user);

            if (dbUser == null)
            {
                throw new NullReferenceException("");
            }


            var mappedUser = _mapper.Map<UserDetailDto>(dbUser);
            return mappedUser;
        }

        public UserDetailDto GetUser(string userName)
        {
        

            var dbUser = _userManager.Users.
                Include(x => x.PostRate).
                Include(x => x.Post).
                Include(x => x.CommentRate).
                Include(x => x.Comment).
                FirstOrDefault(x => x.UserName == userName);

            if (dbUser == null)
            {
                throw new NullReferenceException("");
            }


            var mappedUser = _mapper.Map<UserDetailDto>(dbUser);
            return mappedUser;
        }

        private string GenerateToken(AuthIdentityUser user, DateTime expireDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenBase.SecretKey);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            var roles = _userManager.GetRolesAsync(user).Result.ToList();
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate,
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private bool MatchPasswordAndHash(AuthIdentityUser applicationIdentityUser, string password)
        {
            if (applicationIdentityUser == null)
            {
                return false;
            }

            bool resultSucceeded = _signInManager.CheckPasswordSignInAsync(applicationIdentityUser, password, false)
                .Result.Succeeded;
            return resultSucceeded;
        }
    }
}