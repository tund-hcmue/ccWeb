using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleRepository.SaleItem
{
    public class SaleItemUpdateRepository : Connection
    {
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
