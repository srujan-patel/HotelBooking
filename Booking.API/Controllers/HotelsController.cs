using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
//using Booking.Domain.Models;
using System.Collections.Generic;
using Booking.Domain.Models;
using Booking.Dal;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Booking.API.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography;
using Booking.Domain.Abstractions.Repositories;

namespace Booking.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]//base route for all the methods in the class

    public class HotelsController : Controller

    {
        //private readonly IDataSource m_dataSource;// data  soure is readonly
        private readonly DataContext m_dataContext;
        private readonly IHotelsRepository m_hotelsRepository;

        private readonly IMapper m_mapper;
        //private readonly HttpContext _http;

        public HotelsController(DataContext dataContext, IMapper mapper, IHotelsRepository hotelsRepository)//datasource is a service registered in program.cs
        {
            //m_dataSource = dataSource;
            //_http = httpContextAccessor.HttpContext;
            m_dataContext = dataContext;
            m_mapper = mapper;
            m_hotelsRepository= hotelsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {

            //var hotels = await m_dataContext.hotels.ToListAsync();
            var hotels = await m_hotelsRepository.GetAllHotelsAsync();
            var hotelsGet = m_mapper.Map<List<HotelGetDto>>(hotels);

            //_http.Request.Headers.TryGetValue("my-middleware-header", out var headerDate);
            return Ok(hotelsGet);


        }


        [HttpGet]
        [Route("{Id}")]//only define what follows after base route part,  {} is a placeholder for value entered by the client
        public async Task<IActionResult> GetHotelByID(int Id)// lets the client specify which id to use
        {

            var hotel =await m_hotelsRepository.GetHotelByIdAsync(Id);
            if (hotel == null)
            {
                return NotFound();
            }
            var hotelsGet = m_mapper.Map<HotelGetDto>(hotel);

            return Ok(hotelsGet); //first or default will send you the first item in the list


        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelCreateDTO hotel)
        {
            var DomainHotel = m_mapper.Map<Hotel>(hotel);
            //Hotel DomainHotel = new Hotel();
            //DomainHotel.address= hotel.address;
            //DomainHotel.city= hotel.city;
            //DomainHotel.country= hotel.country;
            //DomainHotel.description= hotel.description;
            //DomainHotel.starRating= hotel.starRating;
            //DomainHotel.hotelName= hotel.hotelName;


            //m_dataContext.hotels.Add(DomainHotel); //only modifies the datacontext
            //await m_dataContext.SaveChangesAsync();// until you do this no changes are actually made to the database, this actually applies the changes to 
            //                                       //var hotels = m_dataSource.GetHotels();
            //                                       //hotels.Add(hotel);

            await m_hotelsRepository.CreateHotelASync(DomainHotel);
            var HotelGet = m_mapper.Map<HotelGetDto>(DomainHotel);

            //HotelGetDto hotelGet= new HotelGetDto();
            //hotelGet.address= DomainHotel.address;
            //hotelGet.city= DomainHotel.city;    
            //hotelGet.country= DomainHotel.country;  
            //hotelGet.description= DomainHotel.description;
            //hotelGet.starRating= DomainHotel.starRating;
            //hotelGet.hotelName= DomainHotel.hotelName;
            //hotelGet.HotelId = DomainHotel.hotelID;

            return CreatedAtAction(nameof(GetHotelByID), new { id = DomainHotel.hotelID }, HotelGet);

        }


        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelCreateDTO update, int Id) //get object from the body and id from the route
        {

            var toUpdate = m_mapper.Map<Hotel>(update);
            toUpdate.hotelID = Id;



            await m_hotelsRepository.UpdateHotelAsync(toUpdate);
            //var hotels = m_dataContext.hotels;

            //var old = await hotels.FirstOrDefaultAsync(h => h.hotelID == Id);
            //if (old == null)
            //{
            //    return NotFound();
            //}
            //hotels.Remove(old);
            //hotels.Add(toUpdate);
            //await m_dataContext.SaveChangesAsync();

            return NoContent();



        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteHotel(int Id)
        {
            //var hotel = await m_dataContext.hotels.FirstOrDefaultAsync(h => h.hotelID == Id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //m_dataContext.hotels.Remove(hotel);
            //await m_dataContext.SaveChangesAsync();
            var hotel = await m_hotelsRepository.DeleteHotelAsync(Id);

            if (hotel == null)
            {
                return NotFound();
            }

            return NoContent();



        }


        [HttpGet]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> GetAllHotelRooms(int hotelId)
        {
            //var rooms = await m_dataContext.Rooms.Where(r => r.hotelId == hotelId).ToListAsync();

           var rooms= await m_hotelsRepository.ListHotelRoomAsync(hotelId);
            var mappedRooms = m_mapper.Map<List<RoomGetDto>>(rooms); //source rooms , destination RoomGetDto
            return Ok(mappedRooms);



        }


        [HttpGet]
        [Route("{hotelId}/rooms/{RoomsId}")]
        public async Task<IActionResult> GetHotelRoomById(int hotelId, int RoomID)
        {
            var room = await m_hotelsRepository.GetHotelRoomByIdAsync(hotelId, RoomID);
            //var room = await m_dataContext.Rooms.FirstOrDefaultAsync(r => r.hotelId == hotelId && r.roomID == RoomID);
            if (room == null)
            {
                return NotFound();
            }
            var mappedRoom = m_mapper.Map<RoomGetDto>(room);
            return Ok(mappedRoom);

        }
        [HttpPost]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> AddHotelRoom(int hotelId, [FromBody] RoomPostDto newRoom)
        {
            var room = m_mapper.Map<Room>(newRoom);
            ////room.hotelId= hotelId;

            ////m_dataContext.Rooms.Add(room);
            ////await m_dataContext.SaveChangesAsync(); //reflect the changes

            ////other approach dont make a context for rooms every thing should go by the hotel

            //var hotel = await m_dataContext.hotels.Include(h=>h.roomList).FirstOrDefaultAsync(h => h.hotelID == hotelId);
            //hotel.roomList.Add(room);
            //await m_dataContext.SaveChangesAsync(); //reflect the changes

            await m_hotelsRepository.CreateHotelRoomAsync(hotelId, room);

            var mappedRoom = m_mapper.Map<RoomGetDto>(room);

            return CreatedAtAction(nameof(GetHotelRoomById), new {hotelId= hotelId, RoomsId= mappedRoom.roomID}, mappedRoom);// parameter names must match the routing params of the called function
        }

        [HttpPut]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> UpdateHotelRoom(int hotelId, int roomId, [FromBody] RoomPostDto updatedRoom)
        {

            var toUpdate = m_mapper.Map<Room>(updatedRoom);
            //toUpdate.roomID = roomId;
            //toUpdate.hotelId= hotelId;
            //m_dataContext.Rooms.Update(toUpdate);

            //await m_dataContext.SaveChangesAsync(); 

            await m_hotelsRepository.UpdateHotelRoomAsync(hotelId, toUpdate);
            return NoContent();


        }


        [HttpDelete]
        [Route("{hotelId}/rooms/{roomsID}")]
        public async Task<IActionResult> RemoveRoomFromHotel(int hotelId, int roomID)
        {
            //var room = await m_dataContext.Rooms.SingleOrDefaultAsync(r => r.roomID == roomID && r.hotelId == hotelId);
            //if (room == null) return NotFound("No Rooms Found");

            //m_dataContext.Rooms.Remove(room);
            //await m_dataContext.SaveChangesAsync();

            var room = await m_hotelsRepository.DeleteHotelRoomAsync(hotelId, roomID);


            if(room != null){
                return null;
            }
            return NoContent();

        }






    }
}
