using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository
{
    public class CustomerInsertRepository : Connection
    {
        public Customer Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = " INSERT INTO [dbo].[Customer]([CustomerId] ,[Phone] ,[Email] ,[isVender] ,[isCustomer] ,[WriteDate] ,[EditDate] ,[WriterId] ,[EditorId] ,[CustomerName]) VALUES ((SELECT isnull(MAX(CustomerId),0) + 1 from Customer),'" + Item.Phone + "','" + Item.Email + "','" + Item.isVender + "','" + Item.isCustomer+ "','','','','',N'"+ Item.CustomerName+"')";
                return cmd.ExecuteQueryNonReader(); ;
            }
        }
    }
}
