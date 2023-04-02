using Booking.Domain.Abstractions.Repositories;
using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Booking.Dal.Repositories
{


      public class HotelRepository : IHotelsRepository
    {

        private readonly DataContext m_dataContext;


        public HotelRepository(DataContext context)
        {
        
            m_dataContext= context;
 
        }



        public async Task<Hotel> CreateHotelASync(Hotel hotel)
        {



            m_dataContext.hotels.Add(hotel); //only modifies the datacontext
           await m_dataContext.SaveChangesAsync();// until you do this no changes are actually made to the database, this actually applies the changes to 
                                                   //var hotels = m_dataSource.GetHotels();
                                                   //hotels.Add(hotel);

            return hotel;

        }

        public async Task<Room> CreateHotelRoomAsync(int hotelId, Room room)
        {


            var hotel = await m_dataContext.hotels.Include(h => h.roomList).FirstOrDefaultAsync(h => h.hotelID == hotelId);
            hotel.roomList.Add(room);
            await m_dataContext.SaveChangesAsync(); //reflect the changes
            return room;

        }

        public async Task<Hotel> DeleteHotelAsync(int id)
        {
            var hotel = await m_dataContext.hotels.FirstOrDefaultAsync(h => h.hotelID == id);
            if (hotel == null)
            {
                return null; ;
            }

            m_dataContext.hotels.Remove(hotel);
            await m_dataContext.SaveChangesAsync();
            return hotel;
        }

        public async Task<Room> DeleteHotelRoomAsync(int hotelId, int roomId)
        {
            var room = await m_dataContext.Rooms.SingleOrDefaultAsync(r => r.roomID == roomId && r.hotelId == hotelId);
            if (room == null) return null;

            m_dataContext.Rooms.Remove(room);
            await m_dataContext.SaveChangesAsync();
            return room;

        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await m_dataContext.hotels.ToListAsync();
            
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {

            var hotel = await m_dataContext.hotels.FirstOrDefaultAsync(hotel => hotel.hotelID == id);
            if (hotel == null)
            {
                return null;
            }

            return hotel;

        }

        public async Task<Room> GetHotelRoomByIdAsync(int hotelId, int roomId)
        {
            var room = await m_dataContext.Rooms.FirstOrDefaultAsync(r => r.hotelId == hotelId && r.roomID == roomId);
            if (room == null)
            {
                return null;

            }

            return room;



        }

        public async Task<List<Room>> ListHotelRoomAsync(int hotelId)
        {
            return await m_dataContext.Rooms.Where(r => r.hotelId == hotelId).ToListAsync();

        }

        public async Task<Hotel> UpdateHotelAsync(Hotel updatedHotel)
        {


            m_dataContext.hotels.Update(updatedHotel);
            await m_dataContext.SaveChangesAsync();
            return updatedHotel;

        }

        public async Task<Room> UpdateHotelRoomAsync(int hotelId, Room updatedRoom)
        {

            m_dataContext.Rooms.Update(updatedRoom);

            await m_dataContext.SaveChangesAsync();
            return updatedRoom;

        }
    }
}

