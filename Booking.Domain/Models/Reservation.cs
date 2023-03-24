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
        public Room room { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string customerName { get; set; }
    }
}
