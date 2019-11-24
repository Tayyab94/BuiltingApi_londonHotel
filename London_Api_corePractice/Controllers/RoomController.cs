using London_Api_corePractice.Models;
using London_Api_corePractice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice.Controllers
{
    [ApiController]
    [Route("/{controller}")]
    public class RoomController:ControllerBase
    {
        private readonly IRoomServices _roomServices;

        public RoomController(IRoomServices roomServices)
        {
            this._roomServices = roomServices;
        }

        [HttpGet(Name =nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }


        // get /Room/id
        [HttpGet("{id}",Name =nameof(GetRoomById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var entity =await _roomServices.GetRoomByIdAsync(id);
            if(entity==null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}
