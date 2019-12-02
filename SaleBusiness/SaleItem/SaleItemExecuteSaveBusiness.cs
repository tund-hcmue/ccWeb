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
    public class SaleItemExecuteSaveBusiness : Connection
    {
        public List<SaleItem> Item { get; set; }
        public bool Execute()
        {
            try
            {
                var flag = false;
                foreach (var item in Item)
                {
                    using (var cmd = new SaleItemDeleteBySaleIdRepository())
                    {
                        cmd.SaleId = item.SaleId;
                        if (!flag)
                        {
                            cmd.Execute();
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        using (var cmd = new SaleItemInsertRepository())
                        {
                            cmd.Item = item;
                            cmd.Execute();
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
