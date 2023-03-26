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

namespace Booking.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]//base route for all the methods in the class

    public class HotelsController : Controller

    {
        //private readonly IDataSource m_dataSource;// data  soure is readonly
        private readonly DataContext m_dataContext;


        private readonly IMapper m_mapper;
        //private readonly HttpContext _http;

        public HotelsController(DataContext dataContext, IMapper mapper)//datasource is a service registered in program.cs
        {
            //m_dataSource = dataSource;
            //_http = httpContextAccessor.HttpContext;
            m_dataContext = dataContext;
            m_mapper= mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllHotels()
        {
            
            var hotels = await m_dataContext.hotels.ToListAsync();

            var hotelsGet = m_mapper.Map<List<HotelGetDto>>(hotels);

            //_http.Request.Headers.TryGetValue("my-middleware-header", out var headerDate);
            return Ok(hotelsGet);


        }


        [HttpGet]
        [Route("{Id}")]//only define what follows after base route part,  {} is a placeholder for value entered by the client
        public async Task <IActionResult> GetHotelByID(int Id)// lets the client specify which id to use
        {
            var hotel = await m_dataContext.hotels.FirstOrDefaultAsync(hotel=>hotel.hotelID==Id);
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


            m_dataContext.hotels.Add(DomainHotel); //only modifies the datacontext
            await m_dataContext.SaveChangesAsync();// until you do this no changes are actually made to the database, this actually applies the changes to 
                                                   //var hotels = m_dataSource.GetHotels();
                                                   //hotels.Add(hotel);


            var HotelGet = m_mapper.Map<HotelGetDto>(DomainHotel);

            //HotelGetDto hotelGet= new HotelGetDto();
            //hotelGet.address= DomainHotel.address;
            //hotelGet.city= DomainHotel.city;    
            //hotelGet.country= DomainHotel.country;  
            //hotelGet.description= DomainHotel.description;
            //hotelGet.starRating= DomainHotel.starRating;
            //hotelGet.hotelName= DomainHotel.hotelName;
            //hotelGet.HotelId = DomainHotel.hotelID;
           
            return CreatedAtAction(nameof(GetHotelByID), new {id= DomainHotel.hotelID}, HotelGet);

        }


        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelCreateDTO update, int Id) //get object from the body and id from the route
        {

            var toUpdate = m_mapper.Map<Hotel>(update);
            toUpdate.hotelID = Id;

            var hotels =  m_dataContext.hotels;

            var old = await hotels.FirstOrDefaultAsync(h => h.hotelID == Id);
            if (old == null)
            {
                return NotFound();
            }
            hotels.Remove(old);
            hotels.Add(toUpdate);
            await m_dataContext.SaveChangesAsync();

            return NoContent();



        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task <IActionResult> DeleteHotel(int Id)
        {
            var hotel = await m_dataContext.hotels.FirstOrDefaultAsync(h => h.hotelID == Id);
            if (hotel == null)
            {
                return NotFound();
            }

            m_dataContext.hotels.Remove(hotel);
            await m_dataContext.SaveChangesAsync();

            return NoContent();



        }








    }
}
