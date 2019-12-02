using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleItemDeleteByIdRepository : Connection
    {
        public int SaleItemId { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "DELETE FROM SaleItem WHERE SaleItemId=" + this.SaleItemId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
