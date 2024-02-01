using Pharmacy.Common.BusinessLayer.Service.Abstract;
using Pharmacy.Common.Database.DbModels;
using Pharmacy.Common.Database.GenericRepository;
using Pharmacy.Common.Util.Config;
using Pharmacy.Common.Util.Constants;
using Pharmacy.Common.Util.Extensions;
using Pharmacy.Common.Util.Extensions.QueryableExtension;
using Pharmacy.Common.Util.GenericResponses;
using Pharmacy.Common.Util.Security.Criptography;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.Design;
using System;
using AutoMapper;
using Pharmacy.Common.Util.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PharmacyOrder = Pharmacy.Common.Util.Models.PharmacyOrder;


namespace Pharmacy.Common.Service.Concrete
{
   
        public class PharmacyOrderService : IPharmacyService
        {
            private readonly IMapper _mapper;
            private readonly IRepository<PharmacyOrder> _pharmacyOrderRepository;
    
            public PharmacyOrderService(IMapper mapper, IRepository<PharmacyOrder> pharmacyRepository)
            {
                _mapper = mapper;
                _pharmacyOrderRepository = pharmacyRepository;
               
            }
            public async Task<IResponse> PharmacyOrderPost(PharmacyOrder model)
            {
                var response = new SingleResponse();
                var isNew = false;
                var successMessage = string.Empty;

                model.CompanyId = model.CompanyId > 0 ? model.CompanyId : CurrentContext.CompanyId;
             
                model.UpdateDate = DateTime.UtcNow;


                return response;


            }
        }
       

    }

      

