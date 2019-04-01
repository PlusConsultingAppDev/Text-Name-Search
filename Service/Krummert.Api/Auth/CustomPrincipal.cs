using Krummert.BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Krummert.Api.Auth
{
    public class CustomPrincipal : ClaimsPrincipal
    {
        public readonly User Auth;

        public CustomPrincipal() : base()
        {
            Auth = new User();
        }
        public CustomPrincipal(User auth)
        {
            Auth = auth;
            var claims = new List<Claim>();

            foreach (var pi in typeof(User).GetProperties())
            {
                claims.Add(new Claim(pi.Name, pi.GetValue(Auth).ToString(), pi.PropertyType.Name));
            }

            base.AddIdentities(new List<ClaimsIdentity>(new[] { new ClaimsIdentity(claims) }));
        }
        public CustomPrincipal(IEnumerable<Claim> claims) : this()
        {
            var type = Auth.GetType();

            foreach (var claim in claims)
            {
                var property = type.GetProperty(claim.Type);

                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(Auth, claim.Value);
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    property.SetValue(Auth, Guid.Parse(claim.Value));
                }
                else if (property.PropertyType == typeof(long))
                {
                    property.SetValue(Auth, long.Parse(claim.Value));
                }
                else if ((property.PropertyType == typeof(int)))
                {
                    property.SetValue(Auth, int.Parse(claim.Value));
                }
                else if (property.PropertyType == typeof(bool))
                {
                    property.SetValue(Auth, bool.Parse(claim.Value));
                }
                else
                    throw new Exception();
            }

            base.AddIdentities(new List<ClaimsIdentity>(new[] { new ClaimsIdentity(claims) }));
        }
    }
}
