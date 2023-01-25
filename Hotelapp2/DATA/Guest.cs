using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.DATA
{
    public class Guest
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string SureName { get; set; }

    }
}
