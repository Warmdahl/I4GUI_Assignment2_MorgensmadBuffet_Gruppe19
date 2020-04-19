using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models
{
    public class Resturant : IResturant
    {
        private List<Reservation> reservations_;
        public List<Reservation> BuffetList 
        {
            get => reservations_; 
            set => reservations_= value; 
        }
    }
}
