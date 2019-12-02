using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class VenderInputAction
    {
        public int? CustomerId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new VenderGetByIdRepository())
            {
                cmd.CustomerId = this.CustomerId.Value;
                return cmd.Execute();
            }
        }
    }
}