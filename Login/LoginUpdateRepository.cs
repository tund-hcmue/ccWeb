using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LoginUpdateRepository : Connection
    {
        public dynamic Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "UPDATE [dbo].[User] SET [Password] = '"+Item.Password+"' ,[Email] = '"+Item.Email+"' ,[EmployeeId] = '"+Item.EmployeeId+"' ,[Token] = '"+Item.Token+"' ,[LastLogin] = '"+Item.LastLogin+"' WHERE [User].Username ='"+Item.Username+"'";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
