using Booking.Dal;
using Booking.Domain.Abstractions.Repositories;
using Booking.Domain.Abstractions.Services;
using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Service.Services
{
    public class ReservationService : IReservationInterface
    {

        private readonly IHotelsRepository m_hotelRepository;
        private readonly DataContext m_dataContext;

        public ReservationService(IHotelsRepository hotelsRepository, DataContext dataContext)
        {
            m_hotelRepository = hotelsRepository;
            m_dataContext = dataContext;
        }
        public async Task<Reservation> MakeReservationAsync(Reservation reservation)
        {


            //Get hotel including all the rooms
            var hotel = await m_hotelRepository.GetHotelByIdAsync(reservation.hotelId);

            //Find the specified Room
            var room = hotel.roomList.Where(r => r.roomID == reservation.roomId).FirstOrDefault();


            if (hotel == null || room == null)
            {
                return null;
            }

            //make sure the room is available...
            bool isBusy = await m_dataContext.Reservations.AnyAsync(
                
                res=> 
                
                (reservation.checkinDate>=res.checkinDate && reservation.checkinDate<=res.checkoutDate)&&(reservation.checkoutDate>=res.checkinDate&& reservation.checkoutDate<=res.checkoutDate));            // instead of returning a resource it will return true or false from the lambda expression


            if ( isBusy || room.needsRepair)
                return null;

      

            //persist all the changes to the database
            m_dataContext.Rooms.Update(room);
            m_dataContext.Reservations.Add(reservation);
           await  m_dataContext.SaveChangesAsync();





            return reservation;
            


        }

        async Task<Reservation> IReservationInterface.DeleteReservationasync(int id)
        {

            var todelete=  await m_dataContext.Reservations.FirstOrDefaultAsync(r=>r.reservationId==id);
            if(todelete == null)
            {
                return null;
            }
            
            m_dataContext.Remove(todelete);
            await m_dataContext.SaveChangesAsync();
            return todelete;
        }



        async Task<List<Reservation>> IReservationInterface.GetAllReservationsAsync()
        {

            return await m_dataContext.Reservations
                .Include(res=>res.hotel)//related properties also include them
                .Include(res=>res.room)
                .ToListAsync();

        }

        async Task<Reservation> IReservationInterface.GetReservationByIdAsync(int id)
        {
            return await m_dataContext.Reservations.Include(r => r.room).Include(r => r.hotel).FirstOrDefaultAsync(r=>r.reservationId==id);

        }
    }
}
