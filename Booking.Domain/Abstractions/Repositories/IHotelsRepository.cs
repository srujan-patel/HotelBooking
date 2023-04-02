using Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Abstractions.Repositories
{
    public interface IHotelsRepository
    {
        //define behaviours and attributes
        Task<List<Hotel>> GetAllHotelsAsync();// implemneting a task because it has to work with a database
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> CreateHotelASync(Hotel hotel);
        Task<Hotel> UpdateHotelAsync(Hotel updatedHotel);
        Task<Hotel> DeleteHotelAsync(int id);
        

        Task<List<Room>> ListHotelRoomAsync(int hotelId);
        Task<Room> GetHotelRoomByIdAsync(int hotelId, int roomId);
        Task<Room> CreateHotelRoomAsync(int hotelId, Room room);
        Task<Room> UpdateHotelRoomAsync(int hotelId, Room updatedRoom);
        Task<Room> DeleteHotelRoomAsync(int hotelId, int roomId);

        
    }
}
