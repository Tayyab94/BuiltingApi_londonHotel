using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using London_Api_corePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace London_Api_corePractice.Services
{
    public class RoomSerives : IRoomServices
    {
        private readonly HotelAPIDbContext context;
        private readonly IMapper mapper;

        public RoomSerives(HotelAPIDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            var entity = await context.Rooms.SingleOrDefaultAsync(s => s.ID == id);

            if (entity == null)
            {
                return null;
            }


            // this Line of code is use when you are using AutoMapper to Map the Database entity
            //  return mapper.Map<Room>(entity);

            var resource = new Room
            {
                Href = "Nothing", //Url.Link(nameof(GetRoomById), new { id = entity.ID }),
                Name = entity.Name,
                Rate = entity.Rate / 100.0m
            };
            return resource;
        }
    }
}
