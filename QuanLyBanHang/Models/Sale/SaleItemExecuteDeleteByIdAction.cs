using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class SaleItemExecuteDeleteByIdAction
    {
        public int SaleItemId { get; set; }
        public bool Execute()
        {
            using(var cmd = new SaleItemDeleteByIdRepository())
            {
                cmd.SaleItemId = this.SaleItemId;
                return cmd.Execute();
            }
        }
    }
}