using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductGroupInsertRepository : Connection
    {
        public ProductGroup Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "INSERT INTO [dbo].[ProductGroup]([ProductGroupId] ,[ProductId] ,[ProductGroupName] ,[Remark]) VALUES ((SELECT isnull(MAX(ProductGroupId),0) + 1 from [ProductGroup])," + 1 + ",N'" + Item.ProductGroupName + "','" + Item.Remark + "')";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
