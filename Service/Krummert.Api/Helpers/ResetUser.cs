using Krummert.Api.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Krummert.Api.Helpers
{
    public static class ResetUser
    {
        public static void Reset(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            if (httpContextAccessor.HttpContext.User == null)
            {
                return;
            }

            httpContextAccessor.HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "Authorization";
            httpContextAccessor.HttpContext.Response.Headers["Access-Control-Allow-Methods"] = "*";
            httpContextAccessor.HttpContext.Response.Headers["Access-Control-Allow-Headers"] = "Authorization, Content-Type";
            httpContextAccessor.HttpContext.Response.Headers["Access-Control-Allow-Origin"] = "*";
            httpContextAccessor.HttpContext.Response.Headers["Authorization"] = TokenHelper.BuildToken(new CustomPrincipal(httpContextAccessor.HttpContext.User.Claims).Auth, config);
        }
    }
}
