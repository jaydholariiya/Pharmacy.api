using Microsoft.AspNetCore.Http;
using Pharmacy.Common.Api.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Common.BusinessLayer.Service.Abstract;
using Pharmacy.Common.Util.GenericResponses;
using Pharmacy.Common.Util.Models;


namespace Pharmacy.Common.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyOrderController : ControllerBase
    {

        protected IPharmacyService _pharmacyService;

        public PharmacyOrderController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PharmacyOrder model)
        {
            var response = await _pharmacyService.PharmacyOrderPost(model).ConfigureAwait(false);
            return response.ToHttpResponse();
        }
    }
}
