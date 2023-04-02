using AutoMapper;
using Booking.API.DTOs;
using Booking.Domain.Models;

namespace Booking.API.Automapper
{
    public class RoomMappingProfiles: Profile
    {

        public RoomMappingProfiles() { 
        CreateMap<Room, RoomGetDto>();//source, destination
        CreateMap<RoomPostDto, Room>();

        }


    }
}
