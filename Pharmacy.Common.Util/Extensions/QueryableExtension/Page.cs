using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Util.Extensions.QueryableExtension
{
    public abstract class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortProperty { get; set; } = "insertDate";
        public bool IsDescending { get; set; } = true;
    }
}
