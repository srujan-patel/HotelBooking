namespace Booking.API
{
    public interface IDataSource
    {

        List<Booking.Domain.Models.Hotel> GetHotels();

    }
}
