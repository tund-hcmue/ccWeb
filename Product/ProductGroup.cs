using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductGroup
    {
        public int ProductGroupId { get; set; }
        public int ProductId { get; set; }
        public string ProductGroupName { get; set; }
        public string Remark { get; set; }
    }
}
