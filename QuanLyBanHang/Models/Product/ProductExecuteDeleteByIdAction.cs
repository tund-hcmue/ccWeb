using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class ProductExecuteDeleteByIdAction
    {
        public int ProductId { get; set; }
        public bool Execute()
        {
            using(var cmd = new ProductDeleteByIdRepository())
            {
                cmd.ProductId = this.ProductId;
                return cmd.Execute();
            }
        }
    }
}