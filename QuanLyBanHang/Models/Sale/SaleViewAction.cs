using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class SaleViewAction
    {
        public int SaleId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new SaleItemGetByIdRepository())
            {
                cmd.SaleId = this.SaleId;
                return cmd.Execute();
            }
        }
    }
}