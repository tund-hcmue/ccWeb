using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class SaleExecuteSaveAction
    {
        public Sale Item { get; set; }
        public string EditFlag { get; set; }
        public bool Execute()
        {
            using (var cmd = new SaleExecuteSaveBusiness())
            {
                cmd.Item = this.Item;
                cmd.EditFlag = this.EditFlag;
                return cmd.Execute();
            }
        }
    }
}