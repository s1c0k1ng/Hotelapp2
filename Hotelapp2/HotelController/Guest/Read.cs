using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Guest
{
    public class Read : MenuInterface
    {

        public ApplicationDbContext DbContext { get; set; }

        public Read(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ALL THE GUESTS ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" --------- ");

            foreach (var guest in DbContext.Guests.OrderBy(g => g.ID))
            {

                Console.WriteLine($"\nID: {guest.ID}");
                Console.WriteLine($"Name: {guest.Name}");
                Console.WriteLine($"Surename: {guest.SureName}");
               

                Console.WriteLine(" --------- ");



            }
            Console.WriteLine("\nPress to continue");
            Console.ReadLine();
        }
    }
}
