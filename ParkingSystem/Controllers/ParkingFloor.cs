using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingFloor : ControllerBase
    {
        [HttpPost("Create")]
        public IActionResult CreateFloor()
        {
            return StatusCode(201);
        }
        [HttpPost("Update")]
        public IActionResult UpdateFloor()
        {
            return StatusCode(200);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteFloor()
        {
            return Ok(true);
        }



    }
}
