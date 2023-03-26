using AutoMapper;
using Booking.API.DTOs;
using Booking.Domain.Models;

namespace Booking.API.Automapper
{
    public class HotelMappingProfiles:Profile
    {



        public HotelMappingProfiles() {

            CreateMap<HotelCreateDTO, Hotel>();
            CreateMap<Hotel, HotelGetDto>();
        }
    }
}
