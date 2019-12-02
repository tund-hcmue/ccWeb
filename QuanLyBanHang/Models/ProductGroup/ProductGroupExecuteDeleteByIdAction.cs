using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class ProductGroupExecuteDeleteByIdAction
    {
        public int ProductGroupId { get; set; }
        public bool Execute()
        {
            using(var cmd = new ProductGroupDeleteByIdRepository())
            {
                cmd.ProductGroupId = this.ProductGroupId;
                return cmd.Execute();
            }
        }
    }
}