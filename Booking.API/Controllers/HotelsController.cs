using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using Booking.Domain.Models;
using System.Collections.Generic;
using Booking.Domain.Models;

namespace Booking.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]//base route for all the methods in the class

    public class HotelsController : Controller

    {
        private readonly IDataSource m_dataSource;// data  soure is readonly
        private readonly HttpContext _http;

        public HotelsController(IDataSource dataSource, IHttpContextAccessor httpContextAccessor)//datasource is a service registered in program.cs
        {
            m_dataSource = dataSource;
            _http = httpContextAccessor.HttpContext;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {


            
            var hotels = m_dataSource.GetHotels();

            _http.Request.Headers.TryGetValue("my-middleware-header", out var headerDate);
            return Ok(headerDate);


        }


        [HttpGet]
        [Route("{Id}")]//only define what follows after base route part,  {} is a placeholder for value entered by the client
        public IActionResult GetHotelByID(int Id)// lets the client specify which id to use
        {
            var hotels = m_dataSource.GetHotels();
            var hotel = hotels.FirstOrDefault(hotel => hotel.hotelID == Id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel); //first or default will send you the first item in the list


        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Booking.Domain.Models.Hotel hotel)
        {
            var hotels = m_dataSource.GetHotels();
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelByID), new { Id = hotel.hotelID }, hotel);

        }


        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateHotel([FromBody] Booking.Domain.Models.Hotel update, int Id) //get object from the body and id from the route
        {

            var hotels = m_dataSource.GetHotels();
            var old = hotels.FirstOrDefault(h => h.hotelID == Id);
            if (old == null)
            {
                return NotFound();
            }
            hotels.Remove(old);
            hotels.Add(update);
            return NoContent();



        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteHotel(int Id)
        {
            var hotels = m_dataSource.GetHotels();
            var todelete = hotels.FirstOrDefault(h => h.hotelID == Id);
            if (todelete == null)
            {
                return NotFound();
            }
            hotels.Remove(todelete);
            return NoContent();

        }


       





    }
}
