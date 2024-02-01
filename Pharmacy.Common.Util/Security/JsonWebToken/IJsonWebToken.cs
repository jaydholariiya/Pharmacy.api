using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Pharmacy.Common.Util.Security.JsonWebToken
{
    public interface IJsonWebToken
    {
        TokenValidationParameters TokenValidationParameters { get; }

        Dictionary<string, object> Decode(string token);

        string Encode(string userId, string sub, string email, string fullname, string[] roles);
    }
}
