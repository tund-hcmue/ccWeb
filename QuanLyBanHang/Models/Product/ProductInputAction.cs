using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class ProductInputAction
    {
        public int? ProductId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new ProductGetByIdRepository())
            {
                cmd.ProductId = this.ProductId.Value;
                return cmd.Execute();
            }
        }
    }
}