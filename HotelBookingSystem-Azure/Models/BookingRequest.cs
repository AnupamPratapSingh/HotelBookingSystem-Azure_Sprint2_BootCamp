using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Models
{
    public class BookingRequest
    {
        [Key]
        public int Booking_id { get; set; }

        public string hotel_name { get; set; }

        public string user_name { get; set; }

        public string room_type { get; set; }

        public DateTime booked_from { get; set; }

        public DateTime booked_to { get; set; }

        public int no_of_adults { get; set; }

        public int no_of_children { get; set; }
    }
}
