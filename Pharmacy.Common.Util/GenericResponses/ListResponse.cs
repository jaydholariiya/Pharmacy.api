using System.Collections.Generic;
using System.Net;

namespace Pharmacy.Common.Util.GenericResponses
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public ListResponse()
        {
            Data = new List<TModel>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<TModel> Data { get; set; }
        public int TotalCount { get; set; }
    }
}