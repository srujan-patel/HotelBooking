namespace Booking.API
{
    public class DataSource
    {
        public List<Booking.Domain.Models.Hotel> hotels { get; set; }


        public DataSource() {
        
        hotels= GetHotels();
        }



        private List<Booking.Domain.Models.Hotel> GetHotels()
        {

            //List<Booking.Domain.Models.Hotel> hotelList = new List<Hotel>();

            return new List<Booking.Domain.Models.Hotel>()
            {
                new Booking.Domain.Models.Hotel
                {
                    hotelID= 1,
                    hotelName="Holiday Inn",
                    country="Canada",
                    city="Calgary",
                    starRating=4



                },
                new Booking.Domain.Models.Hotel
                {
                    hotelID= 2,
                    hotelName="Fairmont Hotel",
                    country="Canada",
                    city="Edmonton",
                    starRating=3
                }

            };
        }
    }
}
