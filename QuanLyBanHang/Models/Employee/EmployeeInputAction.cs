using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class EmployeeInputAction
    {
        public int EmployeeId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new EmployeeGetByIdRepository())
            {
                cmd.EmployeeId = this.EmployeeId;
                return cmd.Execute();
            }
        }
    }
}