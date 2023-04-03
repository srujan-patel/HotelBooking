using Booking.Domain.Models;

namespace Booking.API.DTOs
{
    public class ReservationPutPostDto
    {
        public int roomId { get; set; }
        public int hotelId { get; set; }
        public DateTime checkinDate { get; set; }
        public DateTime checkoutDate { get; set; }
        public string customerName { get; set; }

    }
}
