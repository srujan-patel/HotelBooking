using AutoMapper;
using Booking.API.DTOs;
using Booking.Domain.Abstractions.Services;
using Booking.Domain.Models;
using Booking.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace Booking.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {


        private readonly IReservationInterface m_reservationService;
        private readonly IMapper m_mapper;
        public ReservationController(IReservationInterface reservation, IMapper mapper)
        {
            m_reservationService = reservation;
            m_mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> MakeReservation([FromBody] ReservationPutPostDto reservationDto)
        {

            var reservation= m_mapper.Map<Reservation>(reservationDto);
            var result =await m_reservationService.MakeReservationAsync(reservation);
            if (result == null)
            {
                return BadRequest("cannot create reservation");
            }

            var mapped = m_mapper.Map<ReservationGetDto>(result); //from reservation to reservation get dto
            return Ok(mapped);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {

            var reservations = await m_reservationService.GetAllReservationsAsync();
            var mapped = m_mapper.Map<List<ReservationGetDto>>(reservations);
            return Ok(mapped);

        }

        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> GetReservationById(int Id)
        {

            var reservation = await m_reservationService.GetReservationByIdAsync(Id);

            if (reservation == null)
            {
                return NotFound($"Not Reservation Found for the Id: {Id}");
            }
            var mapped = m_mapper.Map<ReservationGetDto>(reservation);
            return Ok(mapped);

        }
        [HttpDelete]
        [Route("Id")]
        public async Task<IActionResult> CancelBooking(int Id)
        {

            var deleted = await m_reservationService.DeleteReservationasync(Id);
            if (deleted == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

    }
}
