using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.DATA
{
    public class Booking
    {
        [Key]

        public int BookingID { get; set; }

        public Room Rooms { get; set; }

        public Guest Guests { get; set; }


        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
