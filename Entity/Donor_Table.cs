using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_bank_management_Csharp.Entity
{
    public class Donor_Table
    {
        internal int d_id { get; set; }
        internal string blood_grp { get; set; }
        internal int user_id { get; set; }
        internal User_Table user { get; set; }
    }
}
