using Pharmacy.Common.Util.Extensions.QueryableExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Util.Models
{
    public class FeaturePermissionModel
    {
        public class GetFeatureRequest : Page
        {
            [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters.")]
            public string Text { get; set; }
            public int? ProductId { get; set; }
            public int CompanyId { get; set; }
            public int ModualId { get; set; }
        }

        public class FeatureModel
        {
            public int Id { get; set; }
            public int? ProductId { get; set; }
            public string Code { get; set; }
            public string Permission { get; set; }
            public int Sequense { get; set; }
            public int Status { get; set; }
            public int InsertUser { get; set; }
            public DateTime InsertDate { get; set; }
            public int UpdateUser { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        public class GetFeaturePermissionModel
        {
            public int FeaturePermissionId { get; set; }
            public string Code { get; set; } = null!;
            public string PermissionName { get; set; } = null!;
            public bool IsAssigned { get; set; }
            public int ModualId { get; set; }
            public List<FeatureChieldPermissionModel> featureChieldPermissionModels { get; set; }
        }

        public class FeatureChieldPermissionModel
        {
            public int FeatureChieldPermissionId { get; set; }
            public string Code { get; set; }
            public string PermissionName { get; set; }
            public bool IsRequired { get; set; }
            public bool IsAssigned { get; set; }

        }

        public class AddFeaturePermissionRequestModel
        {
            [Required(ErrorMessage = "{0} is required.")]
            public long CompanyId { get; set; }
            public int FeaturePermissionId { get; set; }
            public int ChieldFeaturePermissionId { get; set; }
            public int IsAssigned { get; set; }
            public int? IsRequired { get; set; }
            [Required(ErrorMessage = "{0} is required.")]
            public int ProductId { get; set; }
        }
    }
}

