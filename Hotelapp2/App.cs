using Hotelapp2.HotelController.Booking;
using Hotelapp2.HotelController.Guest;
using Hotelapp2.HotelController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelapp2.HotelController.Room;

namespace Hotelapp2
{
   
        public class App
        {

            public void Run()
            {

                var newBuilder = new Builder();
                var DbContext = newBuilder.Build();


                while (true)
                {
                    var selectionOf = MenuG.ManyMenu();

                    switch (selectionOf)
                    {

                        case 1:
                            var actionB = new bMenu(DbContext);
                            actionB.Run();
                            break;

                        case 2:
                            var actionG = new gMenu(DbContext);
                            actionG.Run();
                            break;

                        case 3:
                            var actionR = new RoomMenu(DbContext);
                            actionR.Run();
                            break;


                        default:
                            break;
                    }
                }


            }


        }
    
}
