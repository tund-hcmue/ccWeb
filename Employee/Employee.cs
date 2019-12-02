using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Phone { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WriteDate { get; set; }
        public string EditDate { get; set; }
        public int EditorId { get; set; }
        public int WriterId { get; set; }
    }
}
