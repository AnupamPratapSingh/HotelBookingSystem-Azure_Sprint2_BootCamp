using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingSystem_Azure.Models
{
    public class User
    {
        [Key]

        public int user_id { get; set; }

        public string password { get; set; }

        public string role { get; set; }

        public string user_name { get; set; }

        public int mobile_num { get; set; }

        public string address { get; set; }

        public string email { get; set; }
    }
}
