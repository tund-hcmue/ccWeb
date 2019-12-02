using Domain;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class ProductExecuteSaveAction
    {
        public Product Item { get; set; }
        public string EditFlag { get; set; }
        public bool Execute()
        {
            using(var cmd = new ProductExecuteSaveBusiness())
            {
                cmd.EditFlag = this.EditFlag;
                cmd.Item = this.Item;
                return cmd.Execute();
            }
        }
    }
}