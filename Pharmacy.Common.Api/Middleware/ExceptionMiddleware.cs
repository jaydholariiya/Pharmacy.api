using Pharmacy.Common.Util.GenericResponses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Pharmacy.Common.Util.GenericResponses;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DRPRO.Common.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new SingleResponse<object>();
            response.SetError(exception);
            Log.Fatal(exception.Message, "Web Host terminated unexpectedly");
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}