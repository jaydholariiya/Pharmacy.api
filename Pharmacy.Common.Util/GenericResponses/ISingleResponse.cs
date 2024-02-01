namespace Pharmacy.Common.Util.GenericResponses
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Data { get; set; }
    }
}