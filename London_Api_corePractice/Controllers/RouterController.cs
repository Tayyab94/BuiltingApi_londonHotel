using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RouterController : ControllerBase
    {

        [HttpGet(Name = nameof(GetRout))]
        [ProducesResponseType(200)]
        public IActionResult GetRout()
        {
            var respose = new
            {
                href = Url.Link(nameof(GetRout), null),
                rooms = Url.Link(nameof(RoomController.GetRooms), null),
                info=Url.Link(nameof(InfoController.GetInfo),null)
            };

            return Ok(respose);
        }
    }
}
