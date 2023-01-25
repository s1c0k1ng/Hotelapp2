using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.DATA
{
    public class Room
    {
        [Key]

        public int ID { get; set; }


        [Required]

        public string Type { get; set; }

        [Required]

        public int Bed { get; set; }


    }
}
