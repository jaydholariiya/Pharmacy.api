using System.Collections.Generic;

namespace Pharmacy.Common.Util.GenericResponses
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Data { get; set; }
    }

    public interface IObjectResponse : IResponse
    {
        object Data { get; set; }
    }
}