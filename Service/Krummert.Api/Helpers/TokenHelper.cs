using Krummert.BLL.Models;
using Krummert.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Krummert.Api.Helpers
{
    public static class TokenHelper
    {
        public static string BuildToken(User user, IConfiguration config)
        {
            var claims = new List<Claim>(new[] {
                new Claim("id", user.Id.ToString()),
                new Claim("emailAddress", user.EmailAddress),
                new Claim("password", user.Password),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static User Authenticate(Guid id, UserService authenticationService)
        {
            return authenticationService.Read(id);
        }
        public static User Authenticate(string emailAddress, string password, UserService authenticationService)
        {
            return authenticationService.Read(emailAddress, password);
        }
    }
}
