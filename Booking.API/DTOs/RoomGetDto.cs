namespace Booking.API.DTOs
{
    public class RoomGetDto
    {

        public int roomID { get; set; }
        public int roomNumber { get; set; }
        public double surface { get; set; }
        public bool needsRepair { get; set; }
        //public int hotelId { get; set; } this info is redundant becoz you get the room only when you know the id
    }
}
