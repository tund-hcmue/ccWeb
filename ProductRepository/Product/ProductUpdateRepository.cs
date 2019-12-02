using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductUpdateRepository : Connection
    {
        public Product Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "UPDATE [dbo].[Product] SET [ProductName] = N'" + Item.ProductName + "' ,[Price] = " + Item.Price + " ,[Barcode] = '" + Item.Barcode + "' ,[Qty] = " + Item.Qty + ",[ProductGroupId] = "+Item.ProductGroupId+" WHERE [Product].ProductId = " + Item.ProductId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
