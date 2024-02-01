using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Database.DbModels
{
    public class PharmacyOrder
    {
        public long OrderId { get; set; }

        public int CompanyId { get; set; }

        public long PatientId { get; set; }

        public long VisitId { get; set; }

        public string PrescribeBy { get; set; }

        public int Status { get; set; }

        public long UserName { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
