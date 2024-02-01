using Pharmacy.Common.Util.Constants;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Pharmacy.Common.Util.Security.JsonWebToken
{
    public static class JsonWebTokenExtensions
    {
        public static void AddJti(this ICollection<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string userId)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static void AddSub(this ICollection<Claim> claims, string sub)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, sub));
        }

        public static void AddFullName(this ICollection<Claim> claims, string value)
        {
            claims.Add(new Claim("Fullname", value));
        }

        public static void AddEmail(this ICollection<Claim> claims, string value)
        {
            claims.Add(new Claim("UserEmail", value));
        }
    }
}
