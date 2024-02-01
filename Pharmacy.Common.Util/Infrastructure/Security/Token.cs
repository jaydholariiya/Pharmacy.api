using Pharmacy.Common.Util.Security.Criptography;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pharmacy.Common.Util.Infrastructure.Security
{
    public static class Token
    {
        public static string Encode<T>(T auth)
        {
            string jsonString = JsonSerializer.Serialize(auth);
            return Encryptor.Encrypt(jsonString);
        }

        public static T Decode<T>(string authEncode, out bool success)
        {
            try
            {
                string auth = Encryptor.Decrypt(authEncode);
                success = true;
                return JsonSerializer.Deserialize<T>(auth, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                success = false;
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }
    }
}
