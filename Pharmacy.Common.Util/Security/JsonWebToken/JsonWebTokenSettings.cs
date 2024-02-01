using Microsoft.IdentityModel.Tokens;
using Pharmacy.Common.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Util.Security.JsonWebToken
{
    public static class JsonWebTokenSettings
    {
        public static string Audience => JwtConfigs.AUDIENCE;

        public static DateTime Expires => DateTime.UtcNow.AddHours(10);

        public static string Issuer => JwtConfigs.ISSUER;

        public static string Key => JwtConfigs.SECRET;

        public static SecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

        public static SigningCredentials SigningCredentials => new(SecurityKey, SecurityAlgorithms.HmacSha256);
    }
}
