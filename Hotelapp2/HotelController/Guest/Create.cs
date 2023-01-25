using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Guest
{
    public class Create : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }

        public Create(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public void Run()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" REGISTER NEW GUEST ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" --------- ");
            try
            {
                Console.WriteLine("First Name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Last Name: ");
                var lastName = Console.ReadLine();

                DbContext.Guests.Add(new DATA.Guest()
                {

                    Name = name,
                    SureName = lastName,

                });

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
