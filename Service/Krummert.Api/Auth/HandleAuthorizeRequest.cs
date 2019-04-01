using Krummert.Api.Helpers;
using Krummert.BLL.Models;
using Krummert.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Krummert.Api.Auth
{
    public class HandleAuthorizeRequest
        : AuthorizationHandler<CustomAuthRequirement>
    {
        IHttpContextAccessor _httpContextAccessor;
        UserService _service;

        public HandleAuthorizeRequest(IHttpContextAccessor httpContextAccessor, UserService customerService)
        {
            _httpContextAccessor = httpContextAccessor;
            _service = customerService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthRequirement requirement)
        {
            // If we are under a brute force attack, return 400
            if (!CachedHelper.CanProceed(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Else, try to process the page
            var auth = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].First().Split("Bearer ")[1].Replace("\"", "");
            var token = (JwtSecurityToken)new JwtSecurityTokenHandler().ReadToken(auth);

            var customAuthorize = new User();
            foreach (var pi in typeof(User).GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    if (token.Claims.Any(m => m.Type == pi.Name.ToTitleCase()))
                    {
                        pi.SetValue(customAuthorize, token.Claims.First(m => m.Type == pi.Name.ToTitleCase()).Value);
                    }
                    else
                    {
                        pi.SetValue(customAuthorize, "");
                    }
                }
                else if (pi.PropertyType == typeof(Int64))
                {
                    pi.SetValue(customAuthorize, Int64.Parse(token.Claims.First(m => m.Type == pi.Name.ToTitleCase()).Value));
                }
            }

            if ((token.ValidTo > DateTime.Today) &&
                (_service.Read(customAuthorize.EmailAddress, customAuthorize.Password) != null))
            {
                _httpContextAccessor.HttpContext.User = new CustomPrincipal(customAuthorize);

                context.Succeed(requirement);
                CachedHelper.ResetForSuccess(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress);
            }

            return Task.CompletedTask;
        }
    }

    public static class StringOverride
    {
        public static string ToTitleCase(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }
    }
}