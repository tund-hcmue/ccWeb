using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDataBase
{
    public abstract class Connection : IDisposable
    {
        protected string ConnectionString { get; }
        public Connection()
        {
            this.ConnectionString = @"Data Source=DOANTU-PC\DT;Initial Catalog=QLBH;Integrated Security=True";
        }
        public void Dispose()
        {
        }
    }
}
