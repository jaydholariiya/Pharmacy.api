using Pharmacy.Common.Util.GenericResponses;
using Microsoft.AspNetCore.Mvc;


namespace Pharmacy.Common.Api.Infrastructure.Extensions
{
    public static class HttpResponse
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            return new JsonResult(response);
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            return new JsonResult(response);
        }

        public static IActionResult ToHttpResponse(this IResponse response)
        {
            return new JsonResult(response);
        }
    }
}