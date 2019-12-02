using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OAuthGetByIdRepository : Connection
    {
        public string Email { get; set; }
        public List<dynamic> Execute()
        {
            using (var cmd = new Query())
            {
                cmd.QueryString = "SELECT [OAuth].* FROM [OAuth] WHERE [OAuth].Email='" + this.Email + "'";
                return cmd.ExecuteQuery();
            }
        }
    }
}
