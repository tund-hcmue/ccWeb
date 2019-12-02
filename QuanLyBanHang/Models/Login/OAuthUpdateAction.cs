using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User;

namespace QuanLyBanHang.Models
{
    public class OAuthUpdateAction
    {
        public OAuth data { get; set; }
        public bool Execute()
        {
            using(var cmd =new OAuthUpdateByIdRepository())
            {
                cmd.data = this.data;
                return cmd.Execute();
            }
        }
    }
}