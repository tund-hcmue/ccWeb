using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace QuanLyBanHang.Models
{
    public class CustomerListAcion
    {
        public List<dynamic> Execute()
        {
            using(var cmd = new CustomerSearchRepository())
            {
                return cmd.Execute();
            }
        }
    }
}