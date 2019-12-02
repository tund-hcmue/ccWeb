using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class SaleChangeStatusAction
    {
        public int SaleId { get; set; }
        public bool Execute()
        {
            using(var cmd = new SaleChangeStatusRepository())
            {
                cmd.SaleId = this.SaleId;
                return cmd.Execute();
            }
        }
    }
}