using ConnectDataBase;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class ProductGetByIdAction
    {
        public int ProductId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new ProductGetByIdRepository())
            {
                cmd.ProductId = this.ProductId;
                return cmd.Execute();
            }
        }
    }
}