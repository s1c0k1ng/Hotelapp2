using Hotelapp2.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Booking
{
    public class CreateB : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }

        public CreateB(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {

            var createBooking = new DATA.Booking();

            Console.Clear();
            try
            {

                Console.WriteLine("How many nights are you staying?: ");
                int nights = Convert.ToInt32(Console.ReadLine());

                createBooking.StartDate = new DateTime(2000, 01, 01, 23, 59, 59);

                while (createBooking.StartDate < DateTime.UtcNow)
                {
                    Console.WriteLine("\n Type in your arrival date (yyyy-mm-dd): ");
                    createBooking.StartDate = Convert.ToDateTime(Console.ReadLine());
                }

                if (nights == 1) createBooking.EndDate = createBooking.StartDate;
                else if (nights > 1) createBooking.EndDate = createBooking.StartDate.AddDays(nights);


                List<DateTime> allDatesForBooking = new List<DateTime>();
                for (var dateTime = createBooking.StartDate; dateTime <= createBooking.EndDate; dateTime = dateTime.AddDays(1))
                {
                    allDatesForBooking.Add(dateTime);
                }

                List<DATA.Room> availability = new List<DATA.Room>();

                foreach (var rooms in DbContext.Rooms.ToList())
                {
                    bool freeRoom = true;
                    foreach (var booking in DbContext.Bookings.Include(b => b.Rooms).Where(b => b.Rooms == rooms))
                    {
                        for (var dateTime = booking.StartDate; dateTime <= booking.EndDate; dateTime = dateTime.AddDays(1))
                        {
                            if (allDatesForBooking.Contains(dateTime)) freeRoom = false;
                        }
                        if (!freeRoom) break;
                    }

                    if (freeRoom) availability.Add(rooms);

                }


                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" BOOKING DETAILS ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" --------------- ");
                Console.WriteLine(" Check in\tCheck out\t Total Nights");
                Console.WriteLine($" {createBooking.StartDate.ToShortDateString()}\t{createBooking.EndDate.ToShortDateString()}\t {nights}");


                if (availability.Count() < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" There are no rooms available this dates ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("Press to continue");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\t\t --Available rooms--");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("\n\tID \t\tRoom\t\tBeds");
                    Console.WriteLine("\t ---------------------------------- ");

                    foreach (var bed in availability.OrderBy(r => r.ID))
                    {
                        Console.WriteLine($"\t{bed.ID} \t\t{bed.Type}\t\t{bed.Bed}");
                        Console.WriteLine("\t ---------------------------------- ");
                    }
                }

                Console.WriteLine("\n Choose an available room (ID): ");
                int roomForBooking = Convert.ToInt32(Console.ReadLine());

                createBooking.Rooms = DbContext.Rooms.Where(c => c.ID == roomForBooking).FirstOrDefault();

                Console.WriteLine("\n Which guest is staying? (ID) ");

                foreach (var guest in DbContext.Guests)
                {
                    Console.WriteLine($"{guest.ID} {guest.Name} {guest.SureName}");
                    Console.WriteLine(" ------- ");
                }

                var selectionOf = Convert.ToInt32(Console.ReadLine());
                createBooking.Guests = DbContext.Guests.Where(c => c.ID == selectionOf).FirstOrDefault();




                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine(" Your booking has been made ");
                Console.WriteLine(" -------------------- ");
                Console.WriteLine(" From\t\tTo\t\tNights");
                Console.WriteLine($"{createBooking.StartDate.ToShortDateString()}\t{createBooking.EndDate.ToShortDateString()}\t{nights}");
                Console.ForegroundColor = ConsoleColor.Gray;

                DbContext.Bookings.Add(createBooking);
                DbContext.SaveChanges();

                Console.WriteLine("\n Press to continue");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
            }

        }
    }
}
