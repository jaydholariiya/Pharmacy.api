using System.Net;

namespace Pharmacy.Common.Util.GenericResponses
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public SingleResponse()
        {
            Data = new TModel();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public TModel Data { get; set; }
        public int TotalCount { get; set; }
    }

    public class SingleResponse : IResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public object Data { get; set; }
        public int TotalCount { get; set; }
    }
}