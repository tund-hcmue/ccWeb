using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;
using System.Data;
using System.Dynamic;

namespace Repository
{
    public class CustomerSearchRepository : Connection
    {
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT * FROM [Customer] WHERE [Customer].isCustomer = 1";
                return cmd.ExecuteQuery();
            }
        }
    }
}
