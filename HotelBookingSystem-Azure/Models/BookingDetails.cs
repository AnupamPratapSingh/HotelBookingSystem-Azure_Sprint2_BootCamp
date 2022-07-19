using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Models
{
    public class BookingDetails
    {
        [Key]

        public int booking_id { get; set; }

        public int room_id { get; set; }

        public int user_id { get; set; }

        public DateTime booked_from { get; set; }

        public DateTime booked_to { get; set; }

        public int no_of_adults { get; set; }

        public int no_of_children { get; set; }

        public int amount { get; set; }

    }
}
