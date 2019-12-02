using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class SaleExecuteDeleteByIdAction
    {
        public int SaleId { get; set; }
        public bool Execute()
        {
            using(var cmd = new SaleDeleteByIdRepository())
            {
                cmd.SaleId = this.SaleId;
                cmd.Execute();
            }
            using(var cmd = new SaleItemDeleteBySaleIdRepository())
            {
                cmd.SaleId = this.SaleId;
                return cmd.Execute();
            }
        }
    }
}