using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class ProductGroupInputAction
    {
        public int? ProductGroupId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new ProductGroupGetByIdRepository())
            {
                cmd.ProductGroupId = this.ProductGroupId.Value;
                return cmd.Execute();
            }
        }
    }
}