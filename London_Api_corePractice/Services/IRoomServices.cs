using London_Api_corePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice.Services
{
   public interface IRoomServices
    {
        Task<Room> GetRoomByIdAsync(int id);
    }
}
