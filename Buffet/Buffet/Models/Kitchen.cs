using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models
{
    public class Kitchen
    {
        public int TotalAll { get; set; }
        public int AdultsTotal { get; set; }
        public int AdultsCheckedIn { get; set; }
        public int ChildrenTotal { get; set; }
        public int ChildrenCheckedIn { get; set; }
        public int NotCheckedIn { get; set; }
        public int AdultNotCheckedIn { get; set; }
        public int ChildrenNotCheckedIn { get; set; }

        public DateTime Date { get; set; }
    }
}
