using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
    }
}
