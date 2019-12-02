using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductGroupUpdateRepository : Connection
    {
        public ProductGroup Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "UPDATE [dbo].[ProductGroup] SET [ProductGroupName] = N'" + Item.ProductGroupName + "' ,[Remark] = '" + Item.Remark+ "' WHERE [ProductGroup].ProductGroupId = " + Item.ProductGroupId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
