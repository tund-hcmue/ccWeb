using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyBanHang.Models
{
    public class LoginExecuteSearchAction
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public List<dynamic> Execute()
        {
            using(var cmd = new LoginGetByIdRepository())
            {
                cmd.Username = this.Username;
                cmd.Password = CreateMD5(this.Password).ToLower();
                var result = cmd.Execute();
                return result;
            }
        }
    }
}