using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFinder.BLL.Abstract;
using FFinder.Core.DataTransferObjects.User;
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

            return Ok();
        }
    }
}