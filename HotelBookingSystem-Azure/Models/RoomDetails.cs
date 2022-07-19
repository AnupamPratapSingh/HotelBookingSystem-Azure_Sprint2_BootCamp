using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Models
{
    public class RoomDetails
    {
        [Key]
        public int room_no { get; set; }

        public string room_type { get; set; }

        public int per_night_rate { get; set; }

        public bool availability { get; set; }

        public int hotel_id { get; set; }
    }
}
