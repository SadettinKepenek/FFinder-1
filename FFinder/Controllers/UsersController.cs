using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Core.System;
using FFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> Login(UserLoginRequestDto model)
        {
            HttpResponseModel responseModel;
            try
            {
                var loginResult = _authService.Login(model);

                responseModel = new HttpResponseModelData<UserLoginResponseDto>()
                {
                    Message =Message.SuccessMessage,
                    StatusCode = 200,
                    Data = loginResult
                };

            }
            catch (Exception e)
            {
                 responseModel = new HttpResponseModelSimple
                {
                    Message = e.Message,
                    StatusCode = 400
                };
                return BadRequest(responseModel);
            }
            return Ok();
        }

        public async Task<IActionResult> Register(UserAddDto userAddDto)
        {
            HttpResponseModel responseModel;
            try
            {
                await _authService.Register(userAddDto,userAddDto.Password);

                responseModel = new HttpResponseModelSimple()
                {
                    Message = Message.SuccessMessage,
                    StatusCode = 200,
                };

            }
            catch (Exception e)
            {
                responseModel = new HttpResponseModelSimple
                {
                    Message = e.Message,
                    StatusCode = 400
                };
                return BadRequest(responseModel);
            }
            return Ok();
        }
    }
}