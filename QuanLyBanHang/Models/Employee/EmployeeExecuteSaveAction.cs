using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
using Domain;

namespace QuanLyBanHang.Models
{
    public class EmployeeExecuteSaveAction
    {
        public string EditFlag { get; set; }
        public Employee EmployeeList { get; set; }
        public bool Execute()
        {
            using(var cmd = new EmployeeExecuteSaveBusiness())
            {
                cmd.EditFlag = this.EditFlag;
                cmd.Item = this.EmployeeList;
                return cmd.Execute();
            }
        }
    }
}