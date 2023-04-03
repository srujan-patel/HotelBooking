using Booking.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Booking.API.DTOs
{
    public class HotelCreateDTO
    {
        // only info that client needs to add...

        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string hotelName { get; set; }

        [Required]
        [Range(1,5)]
        public int starRating { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string description { get; set; }
    }


}
