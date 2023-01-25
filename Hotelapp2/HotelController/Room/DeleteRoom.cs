using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Room
{
    public class DeleteRoom : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }

        public DeleteRoom(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" DELETE A ROOM ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" -------- ");

            foreach (var room in DbContext.Rooms)
            {
                Console.WriteLine($" ID: {room.ID}");
                Console.WriteLine($" Type: {room.Type}");
                Console.WriteLine($" Beds: {room.Bed}");
                Console.WriteLine(" -------- ");
            }
            try
            {
                Console.WriteLine("Type in Room ID: ");
                var roomID = Convert.ToInt32(Console.ReadLine());
                var roomType = DbContext.Rooms.First(r => r.ID == roomID);

                DbContext.Rooms.Remove(roomType);

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
