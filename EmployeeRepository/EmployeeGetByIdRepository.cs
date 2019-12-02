using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeGetByIdRepository : Connection
    {
        public int EmployeeId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd =new Query())
            {
                cmd.QueryString = "SELECT * FROM [Employee] WHERE [Employee].EmployeeId=" + EmployeeId;
                return cmd.ExecuteQuery();
            }
        }
    } 
}
