using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;

namespace Business
{
    public class EmployeeExecuteSaveBusiness : Connection
    {
        public string EditFlag { get; set; }
        public Employee Item { get; set; }
        public bool Execute()
        {
            if(this.EditFlag == "M")
            {
                using(var cmd = new EmployeeUpdateRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
            else
            {
                using(var cmd = new EmployeeInsertRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
        }
    }
}
