using Hotelapp2.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Booking
{
    public class ReadB : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }

        public ReadB(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" \t\t\t\tBOOKING INFO ");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n\tGuest\t\tFrom\t\tTo\t\tRoom ID");
            Console.WriteLine("       ---------------------------------------------------------- ");

            if (DbContext.Bookings.Count() == 0)
                Console.WriteLine("\nNo bookings found");
            else
            {
                var bookingData = DbContext.Bookings.Include(r => r.Rooms).Include(g => g.Guests);

                foreach (var booking in bookingData.OrderBy(b => b.BookingID))
                    Console.WriteLine($"\n\t{booking.Guests.Name}\t\t{booking.StartDate.ToShortDateString()}\t{booking.EndDate.ToShortDateString()}\t  {booking.Rooms.ID}");

            }

            Console.ReadLine();
        }


    }
}
