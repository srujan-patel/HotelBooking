using Booking.Domain.Models;

namespace Booking.API
{
    public class DataSource:IDataSource
    {
        List<Booking.Domain.Models.Hotel> hotelList;

        public DataSource() {

            hotelList = new List<Booking.Domain.Models.Hotel>() {
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



        List<Booking.Domain.Models.Hotel> IDataSource.GetHotels()
        {
            return hotelList;           
        }
    }
}
