using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleItemInsertRepository : Connection
    {
        public SaleItem Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "INSERT INTO [dbo].[SaleItem]([SaleItemId] ,[SaleId] ,[ProductId] ,[Qty]) VALUES ((SELECT isnull(MAX(SaleItemId),0) + 1 from SaleItem),"+Item.SaleId+","+Item.ProductId+","+Item.Qty+")";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
