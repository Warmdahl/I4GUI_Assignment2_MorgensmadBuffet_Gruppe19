using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models
{
    public class Reservation
    {
        //public Guest Attending { get; set; }
        //public bool Checked { get; set; }
        //public DateTime Date { get; set; }

        // P R I M A R Y    K E Y
        public long ResavationId { get; set; }

        // C H E C K E D
        [DisplayName("Checked")]
        [MaxLength(2000)]
        public bool Checked { get; set; }

        // D A T E
        [DisplayName("Date")]
        [MaxLength(2000)]
        public DateTime Date { get; set; }
    }
}
