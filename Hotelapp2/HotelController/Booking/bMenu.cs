using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Booking
{
    public class bMenu
    {
        public ApplicationDbContext DbContext { get; set; }
        public bMenu(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Run()
        {
            var newBuilder = new Builder();
            var DbContext = newBuilder.Build();

            while (true)
            {
                try
                {


                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" BOOKING MENU ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("\n1. Create New");
                    Console.WriteLine("2. See Bookings");
                    Console.WriteLine("\n0. Exit");


                    var selectionOf = Convert.ToInt32(Console.ReadLine());
                    if (selectionOf < 1 || selectionOf > 4)
                    {
                        break;
                    }

                    switch (selectionOf)
                    {

                        case 1:

                            var actionCB = new CreateB(DbContext);
                            actionCB.Run();
                            break;
                        case 2:

                            var actionRB = new ReadB(DbContext);
                            actionRB.Run();
                            break;

                    }

                }
                catch(Exception) { continue; }
            }
        }
    }
}
