using Krummert.Api.Helpers;
using Krummert.BLL.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krummert.Api.Controllers
{
    [Route("api/User"), AllowAnonymous]
    public class UserController : Controller
    {
        private IConfiguration _config;
        private IHttpContextAccessor _httpContextAccessor;
        //private AuthenticationService _AuthenticationService;
        private UserService _UserService;

        public UserController(IConfiguration config, IHttpContextAccessor httpContextAccessor,
            UserService userService)
        {
            _UserService = userService;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            // If we are under a brute force attack, return 400
            if (!CachedHelper.CanProceed(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress))
            {
                return BadRequest();
            }

            // Try to authenticate
            var user = TokenHelper.Authenticate(login.EmailAddress, login.Password, _UserService);
            if (user != null)
            {
                user.Password = login.Password;

                CachedHelper.ResetForSuccess(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress); //Reset for success
                return Ok(new { token = TokenHelper.BuildToken(user, _config) });
            }

            // Send 401 for a failed login that is less than 5 attempts
            CachedHelper.IncrimentValueForFailedLogin(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
            return Unauthorized();
        }

        public class LoginModel
        {
            public string EmailAddress { get; set; }
            public string Password { get; set; }
        }
    }
}
