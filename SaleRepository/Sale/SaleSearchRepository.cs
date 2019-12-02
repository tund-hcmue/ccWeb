using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleSearchRepository : Connection
    {
        public List<dynamic> Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "select Sale.*,Employee.EmployeeName,Customer.CustomerName,ISNULL(SUM(SaleItem.Qty),0) as Qty,ISNULL(SUM(SaleItem.Qty * Product.Price),0) as Total from Sale left join SaleItem on SaleItem.SaleId = Sale.SaleId left join Product on Product.ProductId = SaleItem.ProductId left join Customer on Customer.CustomerId = Sale.CustomerId left join Employee on Employee.EmployeeId = Sale.EmployeeId group by Sale.SaleId,Sale.CustomerId,Sale.EmployeeId,Sale.SaleDate,Customer.CustomerName,Employee.EmployeeName,Sale.Status,Sale.Note";
                return cmd.ExecuteQuery();
            }
        }
    }
}
