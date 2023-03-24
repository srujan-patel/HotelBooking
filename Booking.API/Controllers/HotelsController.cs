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
        private readonly DataSource m_dataSource;
        public HotelsController(DataSource dataSource)//datasource is a service registered in program.cs
        {
            m_dataSource=dataSource;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {

            var hotels = m_dataSource.hotels;
            return Ok(hotels);
        }


        [HttpGet]
        [Route("{Id}")]//only define what follows after base route part,  {} is a placeholder for value entered by the client
        public IActionResult GetHotelByID(int Id)// lets the client specify which id to use
        {
            var hotels = m_dataSource.hotels;
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
            var hotels = m_dataSource.hotels;
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelByID), new { Id = hotel.hotelID }, hotel);

        }


        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateHotel([FromBody] Booking.Domain.Models.Hotel update, int Id) //get object from the body and id from the route
        {

            var hotels = m_dataSource.hotels;
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
            var hotels = m_dataSource.hotels;
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
