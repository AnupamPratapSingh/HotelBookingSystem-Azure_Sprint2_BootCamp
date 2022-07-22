using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Models
{
    public class ServiceBusMessageData
    {
        public int hotel_id { get; set; }

        public string hotel_name { get; set; }

        public int user_id { get; set; }

        public string user_name { get; set; }

        public int Booking_id { get; set; }

        public int booking_id { get; set; }

        public int room_id { get; set; }

        public string Action { get; set; }


    }
}
