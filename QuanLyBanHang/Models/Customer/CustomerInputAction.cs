using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
namespace QuanLyBanHang.Models
{
    public class CustomerInputAction
    {
        public int? CustomerId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new CustomerGetByIdRepository())
            {
                cmd.CustomerId = this.CustomerId.Value;
                return cmd.Execute();
            }
        }
    }
}