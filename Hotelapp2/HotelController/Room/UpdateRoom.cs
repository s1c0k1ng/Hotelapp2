using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Room
{
    public class UpdateRoom : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }

        public UpdateRoom(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" UPDATE ROOMS ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ------- ");

            foreach (var room in DbContext.Rooms)
            {
                Console.WriteLine($"Room ID: {room.ID}");
                Console.WriteLine($"Room type: {room.Type}");
                Console.WriteLine($"Beds: {room.Bed}");
                Console.WriteLine(" ------ ");
            }

            try
            {
                Console.WriteLine(" Type in the room ID you want to update: ");
                var idUpdate = Convert.ToInt32(Console.ReadLine());
                var roomUpdate = DbContext.Rooms.First(r => r.ID == idUpdate);


                Console.WriteLine(" Type in room type 'single or double': ");
                var rUpdate = Console.ReadLine().ToLower();

                Console.WriteLine(" Type in how many beds: ");
                var bedsUpdate = Convert.ToInt32(Console.ReadLine());

                roomUpdate.Type = rUpdate;
                roomUpdate.Bed = bedsUpdate;

                DbContext.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDONE");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadLine();
            }
            catch (Exception) { Console.WriteLine("Invalid input"); Console.ReadLine(); }
        }
    }
}
