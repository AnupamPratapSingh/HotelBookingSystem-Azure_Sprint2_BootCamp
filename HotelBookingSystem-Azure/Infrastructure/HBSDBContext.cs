using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingSystem_Azure.Models;

namespace HotelBookingSystem_Azure.Infrastructure
{
    public class HBSDBContext : DbContext
    {
        public HBSDBContext(DbContextOptions options) : base(options)
        {
           

        }

        DbSet<User> User { get; set; }
        DbSet<Hotel> Hotel { get; set; }

        DbSet<RoomDetails> RoomDetails { get; set; }

        DbSet<BookingDetails> BookingDetails { get; set; }

        DbSet<BookingRequest> BookingRequest { get; set; }
    }
}
