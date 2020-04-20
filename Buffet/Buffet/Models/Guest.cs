using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace Buffet.Models
{
    public enum Status
    {
        Adult,
        Child
    }
    public class Guest
    {
        // P R I M A R Y    K E Y
        public long GuestId { get; set; }

        // A P P L I C A T I O N     U S E R
        [DisplayName("AgeStatus")]
        [MaxLength(5)]
        public String AgeStatus { get; set; }

        // R O O M     N U M B E R
        [DisplayName("RoomNr")]
        public int RoomNr { get; set; }

        // D A T E
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        // C H E C K E D
        [DisplayName("Checked")]
        public bool Checked { get; set; }

        //public String TestStatus { get; set; }
        //public IEnumerable<SelectListItem> Statuseses { get; set; }

    }
}
