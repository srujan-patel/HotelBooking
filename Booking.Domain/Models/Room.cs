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
        public int hotelId { get; set; }//one to many relationship 
        public Hotel Hotel { get; set; }//if you want to make a rrelation with the room you should be able to see the hotel as per the entity framework called as navigation property

    }
}
