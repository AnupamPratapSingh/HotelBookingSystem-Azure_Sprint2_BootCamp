using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Models
{
    public class Hotel
    {
        [Key]
        public int hotel_id { get; set; }

        public string city { get; set; }

        public string hotel_name { get; set; }

        public string address { get; set; }

        public string description { get; set; }

        public int avg_rate_per_nigh { get; set; }

        public int phone_no1 { get; set; }

        public int phone_no2 { get; set; }

        public int rating { get; set; }

        public string email { get; set; }

        public string fax { get; set; }
    }
}
