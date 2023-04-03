using Booking.Domain.Models;

namespace Booking.API.DTOs
{
    public class ReservationGetDto
    {


        public int reservationId { get; set; }
        //public int roomId { get; set; }
        //public int hotelId { get; set; }
        public RoomGetDto room { get; set; }
        public HotelGetDto hotel { get; set; }
        public DateTime checkinDate { get; set; }
        public DateTime checkoutDate { get; set; }
        public string customerName { get; set; }
    }
}
