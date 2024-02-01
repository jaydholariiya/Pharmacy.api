using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Database.DbModels
{
    public partial class PharmacyContext : DbContext
    {

        public PharmacyContext(DbContextOptions<PharmacyContext> options)
       : base(options)
        {
        }

        /*public virtual DbSet<PharmacyOrder> PharmacyOrders { get; set; }*/

    }
}
