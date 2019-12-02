using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectDataBase;
namespace Repository
{
    public class SaleItemGetByIdRepository : Connection
    {
        public int SaleId { get; set; }
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "SELECT [SaleItem].*,[Product].ProductName,[Product].Price,([Product].Qty * [Product].Price) as Total FROM [SaleItem] LEFT JOIN [Product] on [Product].ProductId = [SaleItem].ProductId WHERE [SaleItem].SaleId = " + SaleId;
                return cmd.ExecuteQuery();
            }
        }
    }
}
