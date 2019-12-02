using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDataBase;
using Domain;
using Repository;
namespace Business
{
    public class ProductGroupExecuteSaveBusiness : Connection
    {
        public string EditFlag { get; set; }
        public ProductGroup Item { get; set; }
        public bool Execute()
        {
            if (this.EditFlag == "M")
            {
                using (var cmd = new ProductGroupUpdateRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
            else
            {
                using (var cmd = new ProductGroupInsertRepository())
                {
                    cmd.Item = this.Item;
                    return cmd.Execute();
                }
            }
        }
    }
}
