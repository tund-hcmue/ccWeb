using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class CustomerExecuteDeleteByIdAction
    {
        public int CustomerId { get; set; }
        public bool Execute()
        {
            using(var cmd = new CustomerExecuteDeleteByIdRepository())
            {
                cmd.CustomerId = this.CustomerId;
                return cmd.Execute();
            }
        }
    }
}