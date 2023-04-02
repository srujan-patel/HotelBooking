//using Booking.Domain.Models;
using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Dal
{
    public class DataContext:DbContext //it is like an image of the database not the actual database which is written in the c# ie a code representation

    {

        public DataContext(DbContextOptions options):base(options) { 
        
        
        
        
        }
        public DbSet<Booking.Domain.Models.Hotel> hotels { get; set; }//generate a table for hotels which will contain hotels
        public DbSet<Booking.Domain.Models.Room> Rooms { get; set; }//table for rooms
        public DbSet<Booking.Domain.Models.Reservation> Reservations { get; set; }//table for reservations



    }
}
