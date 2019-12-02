using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace QuanLyBanHang.Models
{
    public class CustomerExecuteSaveAction
    {
        public Customer customerList { get; set; }
        public string EditFlag { get; set; }
        public bool Execute()
        {
            using(var cmd = new CustomerExecuteSaveBusiness())
            {
                cmd.EditFlag = this.EditFlag;
                cmd.Item = this.customerList;
                return cmd.Execute();
            }
        }
    }
}