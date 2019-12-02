using ConnectDataBase;
using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SaleExecuteSaveBusiness : Connection
    {
        public Sale Item { get; set; }
        public string EditFlag { get; set; }
        public bool Execute()
        {
            if(this.EditFlag == "M")
            {
                using(var cmd = new SaleUpdateRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
            else
            {
                using(var cmd = new SaleInsertRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
        }
    }
}
