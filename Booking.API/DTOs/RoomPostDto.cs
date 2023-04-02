namespace Booking.API.DTOs
{
    public class RoomPostDto
    {

        //public int roomID { get; set; } not required managed by the DB
        public int roomNumber { get; set; }
        public double surface { get; set; }
        public bool needsRepair { get; set; }
        //public int hotelId { get; set; }//nested resource    
    }
}
