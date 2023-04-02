namespace Booking.API.DTOs
{
    public class HotelGetDto
    {
        public int HotelId { get; set; }
        public string hotelName { get; set; }
        public int starRating { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string description { get; set; }

    }
}
