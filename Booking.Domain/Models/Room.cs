using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Models
{
    public class Room
    {

        public int roomID{get;set;}
        public int roomNumber { get; set; }
        public double surface { get; set; }
        public bool needsRepair { get; set; }


    }
}
