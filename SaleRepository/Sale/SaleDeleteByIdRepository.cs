using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleDeleteByIdRepository : Connection
    {
        public int SaleId { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "DELETE FROM [Sale] WHERE [Sale].SaleId=" + this.SaleId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
