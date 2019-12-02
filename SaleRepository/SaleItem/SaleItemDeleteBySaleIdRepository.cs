using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleItemDeleteBySaleIdRepository : Connection
    {
        public int SaleId { get; set; }
        public bool Execute()
        {
            using(var cmd= new Query())
            {
                cmd.QueryString = "DELETE FROM SaleItem WHERE SaleId=" + this.SaleId;
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
