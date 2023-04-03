using AutoMapper;
using Booking.API.DTOs;
using Booking.Domain.Models;

namespace Booking.API.Automapper
{
    public class ReservationMappingProfiles:Profile
    {
        public ReservationMappingProfiles() 
        {

            CreateMap<ReservationPutPostDto, Reservation>();
            CreateMap<Reservation, ReservationGetDto>();

        }


    }
}
