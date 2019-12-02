using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleUpdateRepository : Connection
    {
        public Sale Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "UPDATE [dbo].[Sale] SET [CustomerId] = " + Item.CustomerId + " ,[EmployeeId] = " + Item.EmployeeId + ",[SaleDate] = '" + Convert.ToDateTime(Item.SaleDate).ToString("yyyy-MM-dd hh:mm:ss") + "',[Note] = N'"+Item.Note+"' WHERE SaleId=" + Item.SaleId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
