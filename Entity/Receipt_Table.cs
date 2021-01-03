using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blood_bank_management_Csharp.Entity
{
    public class Receipt_Table
    {
        internal int receipt_id { get; set; }
        internal string receipt_no { get; set; }
        internal DateTime date { get; set; }
        internal int requester_id { get; set; }
        internal int donor_id { get; set; }
        internal int issued_by { get; set; }
        internal string receipt_type { get; set; }
    }
}
