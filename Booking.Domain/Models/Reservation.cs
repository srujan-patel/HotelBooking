using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Models
{
    public class Reservation
    {

        public int reservationId { get; set; }
        public int roomId { get; set; }
        public int hotelId { get; set; }
        public Room room { get; set; }
        public Hotel hotel { get; set; }
        public DateTime? checkinDate { get; set; }
        public DateTime? checkoutDate { get; set; }
        public string customerName { get; set; }

    }
}
