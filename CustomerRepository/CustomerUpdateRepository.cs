using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository
{
    public class CustomerUpdateRepository : Connection
    {
        public Customer Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = " UPDATE [dbo].[Customer] SET [Phone] = '" + Item.Phone + "',[Email] ='" + Item.Email + "',[isVender] = '" + Item.isVender + "',[isCustomer] ='" + Item.isCustomer + "' ,[WriteDate] = '',[EditDate] = '',[WriterId] = '',[EditorId] = '',[CustomerName] = N'" + Item.CustomerName + "' WHERE [Customer].CustomerId = " + Item.CustomerId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
