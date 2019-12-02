using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductGroupSearchRepository : Connection
    {
        public List<dynamic> Exeucte()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT * FROM [ProductGroup]";
                return cmd.ExecuteQuery();
            }
        }
    }
}
