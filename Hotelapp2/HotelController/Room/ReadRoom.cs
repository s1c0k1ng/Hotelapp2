using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Room
{
    public class ReadRoom : MenuInterface
    {

        public ApplicationDbContext DbContext { get; set; }

        public ReadRoom(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ALL THE ROOMS ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n -------- ");


            foreach (var room in DbContext.Rooms.OrderBy(r => r.ID))
            {
                Console.WriteLine($"\n ID: {room.ID}");
                Console.WriteLine($" Room: {room.Type}");
                Console.WriteLine($" Beds: {room.Bed}");
                Console.WriteLine(" -------- ");

            }
            Console.WriteLine("\nPress to continue");
            Console.ReadLine();
        }
    }
}
