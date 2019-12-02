using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerGetByIdRepository : Connection
    {
        public int CustomerId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT * FROM [Customer] WHERE [Customer].CustomerId = "+CustomerId;
                return cmd.ExecuteQuery();
            }
        }
    }
}
