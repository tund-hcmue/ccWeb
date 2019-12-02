using ConnectDataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeInsertRepository : Connection
    {
        public Employee Item { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "INSERT INTO [dbo].[Employee]([EmployeeId] ,[Phone] ,[Email] ,[Address] ,[WriteDate] ,[EditDate] ,[WriterId] ,[EditorId] ,[EmployeeName]) VALUES ((SELECT isnull(MAX(EmployeeId),0) + 1 from Employee),'"+Item.Phone+"','"+Item.Email + "',N'" +Item.Address + "','','','','',N'"+Item.EmployeeName+"')";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
