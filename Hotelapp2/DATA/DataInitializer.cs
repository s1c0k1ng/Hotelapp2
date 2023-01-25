using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelapp2.DATA
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            RoomSeed(dbContext);
            GuestSeed(dbContext);
            
            dbContext.SaveChanges();
              
        }


        public void RoomSeed(ApplicationDbContext dbContext)
        {

            if (!dbContext.Rooms.Any(r => r.ID == 1))
            {
                dbContext.Rooms.Add(new Room()
                {

                    Type = "Double",
                    Bed = 2
               
                });
            }

            if (!dbContext.Rooms.Any(r => r.ID == 2))
            {
                dbContext.Rooms.Add(new Room()
                {
                    Type = "Single",
                    Bed = 1
                });
            }
            if (!dbContext.Rooms.Any(r => r.ID == 3))
            {
                dbContext.Rooms.Add(new Room()
                {

                    Type = "Double",
                    Bed = 1
                });
            }
            if (!dbContext.Rooms.Any(r => r.ID == 4))
            {
                dbContext.Rooms.Add(new Room()
                {

                    Type = "Single",
                    Bed = 2

                });
            }

        }

        public void GuestSeed(ApplicationDbContext dbContext)
        {


            if (!dbContext.Guests.Any(g => g.ID == 1))
            {
                dbContext.Guests.Add(new Guest()
                {

                    Name = "Haylei",
                    SureName = "Bieber"

                });
            }


            if (!dbContext.Guests.Any(g => g.ID == 2))
            {
                dbContext.Guests.Add(new Guest()
                {

                    Name = "Bella",
                    SureName = "Hadid"

                });
            }

            if (!dbContext.Guests.Any(g => g.ID == 3))
            {
                dbContext.Guests.Add(new Guest()
                {

                    Name = "Kendall",
                    SureName = "Jenner"

                });
            }

            if (!dbContext.Guests.Any(g => g.ID == 4))
            {
                dbContext.Guests.Add(new Guest()
                {

                    Name = "Josie",
                    SureName = "Canseco"

                });
            }
        }
    }
}
