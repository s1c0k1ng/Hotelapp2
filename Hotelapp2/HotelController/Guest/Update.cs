using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Guest
{
    public class Update : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }

        public Update(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" UPDATE GUEST INFO ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ---------- ");

            foreach (var guest in DbContext.Guests)
            {
                Console.WriteLine($"Guest ID: {guest.ID}");
                Console.WriteLine($"Guest Name and Surname: {guest.Name} {guest.SureName}");
                Console.WriteLine(" ---------- ");
            }

            try
            {
                Console.WriteLine(" Type in the guest ID you want to update: ");
                var idUpdate = Convert.ToInt32(Console.ReadLine());
                var guestUpdate = DbContext.Guests.First(g => g.ID == idUpdate);


                Console.WriteLine("Type in Name: ");
                var nameUpdate = Console.ReadLine();
                Console.WriteLine("Type in Surname: ");
                var surnameUpdate = Console.ReadLine();

                guestUpdate.Name = nameUpdate;
                guestUpdate.SureName = surnameUpdate;

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
