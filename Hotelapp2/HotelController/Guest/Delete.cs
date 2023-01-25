using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Guest
{
    public class Delete : MenuInterface
    {
        public ApplicationDbContext  DbContext { get; set; }

        public Delete(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" REMOVE A GUEST ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" -------- ");

            foreach (var guest in DbContext.Guests)
            {
                Console.WriteLine($"\nID: {guest.ID}");
                Console.WriteLine($" Name and Surename: {guest.Name} {guest.SureName}");
                Console.WriteLine(" -------- ");
            }
            try
            {
                Console.WriteLine("Type in guest ID: ");
                var guestID = Convert.ToInt32(Console.ReadLine());
                var guestName = DbContext.Guests.First(g => g.ID == guestID);
                DbContext.Guests.Remove(guestName);

                DbContext.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDONE");
                Console.ForegroundColor = ConsoleColor.Gray;
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
