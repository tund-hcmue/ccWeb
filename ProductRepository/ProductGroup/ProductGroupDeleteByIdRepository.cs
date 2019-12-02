using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductGroupDeleteByIdRepository : Connection
    {
        public int ProductGroupId { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "DELETE FROM [ProductGroup] WHERE [ProductGroup].ProductGroupId = " + this.ProductGroupId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
