using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VenderSearchRepository : Connection
    {
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT * FROM [Customer] WHERE [Customer].isVender = 1";
                return cmd.ExecuteQuery();
            }
        }
    }
}
