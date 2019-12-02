using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class EmployeeExecuteDeleteByIdAction : Connection
    {
        public int EmployeeId { get; set; }
        public bool Execute()
        {
            using(var cmd = new EmployeeDeleteByIdRepository())
            {
                cmd.EmployeeId = this.EmployeeId;
                return cmd.Execute();
            }
        }
    }
}