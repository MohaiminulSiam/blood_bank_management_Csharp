using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_bank_management_Csharp.Entity
{
    public class User_Table
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal string email { get; set; }
        internal string password { get; set; }
        internal string phone { get; set; }
        internal string address { get; set; }
        internal string image { get; set; }
        internal DateTime join_date { get; set; }
        internal string role { get; set; }
    }
}
