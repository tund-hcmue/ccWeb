using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User;

namespace QuanLyBanHang.Models
{
    public class OAuthAction
    {
        public OAuth data { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new OAuthGetByIdRepository())
            {
                cmd.Email = data.Email;
                return cmd.Execute();
            }
        }
    }
}