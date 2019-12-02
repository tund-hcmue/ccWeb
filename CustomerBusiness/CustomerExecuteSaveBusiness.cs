using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerRepository;
using Domain;

namespace Business
{
    public class CustomerExecuteSaveBusiness : Connection
    {
        public string EditFlag { get; set; }
        public Customer Item { get; set; }
        public bool Execute()
        {
            if(EditFlag == "M") // modifi - sua 
            {
                using(var cmd= new CustomerUpdateRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
            else
            {
                using(var cmd = new CustomerInsertRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
        }
    }
}
