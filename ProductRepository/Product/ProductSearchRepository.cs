using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductSearchRepository : Connection
    {
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT [Product].*,[ProductGroup].ProductGroupName FROM [Product] LEFT JOIN [ProductGroup] on [ProductGroup].ProductGroupId = [Product].ProductGroupId";
                return cmd.ExecuteQuery();
            }
        }
    }
}
