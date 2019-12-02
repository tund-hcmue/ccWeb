using ConnectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

namespace Repository
{
    public class OAuthUpdateByIdRepository : Connection
    {
        public OAuth data { get; set; }
        public bool Execute()
        {
            using(var cmd = new Query())
            {
                cmd.QueryString = "UPDATE [dbo].[OAuth] SET [Token] = '" + data.Token + "' ,[Photo] = '" + data.Photo + "',[Name] = N'" + data.Name + "',[Id] = '"+data.Id+"' WHERE [OAuth].Email='" + data.Email + "'";
                return cmd.ExecuteQueryNonReader();
            }
        }
    }
}
