using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LoginGetByIdRepository : Connection
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT [User].*,[Employee].EmployeeName FROM [User] LEFT JOIN [Employee] on [Employee].EmployeeId = [User].EmployeeId WHERE [User].Username = '" + this.Username + "' AND [User].Password='" + this.Password + "'";
                return cmd.ExecuteQuery();
            }
        }

    }
}
