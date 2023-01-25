using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Guest
{
    public class gMenu : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }
        public gMenu(ApplicationDbContext dbContext)
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
                    Console.WriteLine(" GUEST MENU ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("\n1. Add a New");
                    Console.WriteLine("2. Show");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Remove");
                    Console.WriteLine("\n0. Exit");

                    var selectionOf = Convert.ToInt32(Console.ReadLine());
                    if (selectionOf < 1 || selectionOf > 4)
                    {
                        break;
                    }

                    switch (selectionOf)
                    {

                        case 1:

                            var actionC = new Create(DbContext);
                            actionC.Run();
                            break;
                        case 2:

                            var actionR = new Read(DbContext);
                            actionR.Run();
                            break;
                        case 3:

                            var actionU = new Update(DbContext);
                            actionU.Run();
                            break;

                        case 4:

                            var actionD = new Delete(DbContext);
                            actionD.Run();
                            break;




                    }

                }
                catch(Exception)
                {
                    continue;
                }
            }
        }
    }
}
