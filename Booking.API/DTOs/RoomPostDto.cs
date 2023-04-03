using Booking.Domain.Models;

namespace Booking.API.DTOs
{
    public class RoomPostDto
    {
        public int roomNumber { get; set; }
        public double surface { get; set; }
        public bool needsRepair { get; set; }
    }
}
