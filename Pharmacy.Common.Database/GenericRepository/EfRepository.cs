using Pharmacy.Common.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Database.GenericRepository
{
    public class EfRepository
    {
        protected readonly PharmacyContext _dbContext;
    }
}
