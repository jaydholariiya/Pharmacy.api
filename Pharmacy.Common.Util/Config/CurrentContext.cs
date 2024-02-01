using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Pharmacy.Common.Util.Constants;
using Microsoft.AspNetCore.Http;

namespace Pharmacy.Common.Util.Config
{
    public static class CurrentContext
    {
        public static HttpContext HttpContext => new HttpContextAccessor().HttpContext;

        public static int UserId
        {
            get
            {
                return Convert.ToInt32(HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            }
        }

        public static int CompanyId
        {
            get
            {
                return Convert.ToInt32(HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == Constants.Constants.COMPANYID)?.Value);
            }
        }
        public static string FirstName
        {
            get
            {
                return Convert.ToString(HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == Constants.Constants.FIRSTNAME)?.Value);
            }
        }
        public static string LastName
        {
            get
            {
                return Convert.ToString(HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == Constants.Constants.LASTNAME)?.Value);
            }
        }
    }
}