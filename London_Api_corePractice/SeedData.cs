using London_Api_corePractice.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice
{
    public static class SeedData
    {

        public static async Task initializeAsync(IServiceProvider service)
        {
            await AddTestData(service.GetRequiredService<HotelAPIDbContext>());
        }

        public static async Task AddTestData(HotelAPIDbContext context)
        {
            if(context.Rooms.Any())
            {
                // Already has data
                return;

            }

            context.Rooms.Add(new RoomEntity
            {

                 ID=1,
                  Name="Oxford Suite.",
                   Rate=1129 
            });

            context.Rooms.Add(new RoomEntity
            {

                ID = 2,
                Name = "Lahoree Roome",
                Rate = 1124
            });

            context.Rooms.Add(new RoomEntity
            {

                ID = 3,
                Name = "The Gujranwala Rooms",
                Rate = 1344
            });

            await context.SaveChangesAsync();
        }
    }
}
