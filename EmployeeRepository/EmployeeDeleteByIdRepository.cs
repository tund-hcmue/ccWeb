using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeDeleteByIdRepository : Connection
    {
        public int EmployeeId { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "DELETE FROM [Employee] WHERE [Employee].EmployeeId=" + EmployeeId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
