using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductGroupGetByIdRepository : Connection
    {
        public int ProductGroupId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT * FROM [ProductGroup] WHERE [ProductGroup].ProductGroupId = " + this.ProductGroupId;
                return cmd.ExecuteQuery();
            }
        }
    }
}
