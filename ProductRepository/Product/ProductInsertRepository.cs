using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductInsertRepository : Connection
    {
        public Product Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "INSERT INTO [dbo].[Product]([ProductId] ,[ProductName] ,[Price] ,[Barcode] ,[Qty],[ProductGroupId]) VALUES ((SELECT isnull(MAX(ProductId),0) + 1 from [Product]),N'" + Item.ProductName + "'," + Item.Price + ",'" + Item.Barcode + "'," + Item.Qty + ","+Item.ProductGroupId+")";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
