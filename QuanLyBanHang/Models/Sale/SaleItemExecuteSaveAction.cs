using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class SaleItemExecuteSaveAction
    {
        public List<SaleItem> Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new SaleItemExecuteSaveBusiness())
            {
                cmd.Item = this.Item;
                return cmd.Execute();
            }
        }
    }
}