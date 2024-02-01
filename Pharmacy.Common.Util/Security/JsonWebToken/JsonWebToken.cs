using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pharmacy.Common.Util.Security.JsonWebToken
{
    public class JsonWebToken : IJsonWebToken
    {
        public TokenValidationParameters TokenValidationParameters => new()
        {
            IssuerSigningKey = JsonWebTokenSettings.SecurityKey,
            ValidateActor = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidAudience = JsonWebTokenSettings.Audience,
            ValidIssuer = JsonWebTokenSettings.Issuer,
            ClockSkew = TimeSpan.Zero
        };

        public Dictionary<string, object> Decode(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
        }

        public string Encode(string userId, string sub, string email, string fullname, string[] roles)
        {
            var claims = new List<Claim>();
            claims.AddEmail(email);
            claims.AddFullName(fullname);
            claims.AddJti();
            claims.AddNameIdentifier(sub);
            claims.AddRoles(roles);
            claims.AddSub(sub);

            return new JwtSecurityTokenHandler().WriteToken(CreateJwtSecurityToken(claims));
        }

        private static JwtSecurityToken CreateJwtSecurityToken(IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken
            (
                JsonWebTokenSettings.Issuer,
                JsonWebTokenSettings.Audience,
                claims,
                DateTime.UtcNow,
                JsonWebTokenSettings.Expires,
                JsonWebTokenSettings.SigningCredentials
            );
        }
    }
}
