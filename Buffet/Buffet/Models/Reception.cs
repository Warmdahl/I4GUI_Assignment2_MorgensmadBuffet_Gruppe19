using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models
{
    public class Reception
    {
        public int Room { get; set; }

        [DisplayName("NrAdults")]
        public int NrAdults { get; set; }

        [DisplayName("NrChildren")]
        public int NrChildren { get; set; }

        public Reception(int room, int nradults, int nrchildren)
        {
            Room = room;
            NrAdults = nradults;
            NrChildren = nrchildren;
        }
    }
}
