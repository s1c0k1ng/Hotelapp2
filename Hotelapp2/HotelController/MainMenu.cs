using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController
{
    public class MenuG
    {
        public ApplicationDbContext DbContext { get; set; }

        public MenuG(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public static int ManyMenu()
        {
            Console.Clear();


            Console.WriteLine("\n1. Bookings");
            Console.WriteLine("2. Guests Management");
            Console.WriteLine("3. Check Rooms");



            var selectionOf = Convert.ToInt32(Console.ReadLine());



            return selectionOf;
            ;
        }

    }
}
