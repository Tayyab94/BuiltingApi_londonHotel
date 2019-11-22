using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name =nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
