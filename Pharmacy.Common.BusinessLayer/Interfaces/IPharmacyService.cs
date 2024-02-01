using Pharmacy.Common.Util.GenericResponses;
using Pharmacy.Common.Util.Models;
using System.Threading.Tasks;


namespace Pharmacy.Common.BusinessLayer.Service.Abstract
{
    public interface IPharmacyService
    {
        Task<IResponse> PharmacyOrderPost(PharmacyOrder model);

    }
}
