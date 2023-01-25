using Hotelapp2.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.HotelController.Room
{
    public class RoomMenu : MenuInterface
    {
        public ApplicationDbContext DbContext { get; set; }
        public RoomMenu(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
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
                    Console.WriteLine(" ROOM MENU ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("\n1. Register a new room");
                    Console.WriteLine("2. All The Rooms");
                    Console.WriteLine("3. Upgrade or Make Change");
                    Console.WriteLine("4. Delete a Room");
                    Console.WriteLine("\n0. Exit");

                    var selectionOf = Convert.ToInt32(Console.ReadLine());

                    if (selectionOf < 1 || selectionOf > 4)
                    {
                        break;
                    }

                    switch (selectionOf)
                    {

                        case 1:

                            var actionC = new CreateRoom(DbContext);
                            actionC.Run();
                            break;
                        case 2:

                            var actionR = new ReadRoom(DbContext);
                            actionR.Run();
                            break;
                        case 3:

                            var actionU = new UpdateRoom(DbContext);
                            actionU.Run();
                            break;

                        case 4:

                            var actionD = new DeleteRoom(DbContext);
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
