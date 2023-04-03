using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Booking.Domain.Models
{
    public class Hotel
    {

        public Hotel()
        {
          
        }

        public int hotelID { get; set; }
        public string  hotelName { get; set; }
        public int starRating { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string description { get; set; }
        public List<Room> roomList {get; set;}
    }
}
