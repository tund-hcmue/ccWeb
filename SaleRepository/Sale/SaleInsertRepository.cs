using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleInsertRepository : Connection
    {
        public Sale Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "INSERT INTO [dbo].[Sale]([SaleId] ,[CustomerId] ,[EmployeeId] ,[SaleDate],[Note],[Status]) VALUES ((SELECT isnull(MAX(SaleId),0) + 1 from [Sale])," + Item.CustomerId + "," + Item.EmployeeId + ",'" + Convert.ToDateTime(Item.SaleDate).ToString("yyyy-MM-dd") + "',N'"+Item.Note+"',0)";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
