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
    public class ParkingLotController : ControllerBase
    {

        // This API is used to create a new parking Lot
        public IActionResult CreateParkingLot()
        {

            return StatusCode(201);

        }

        // This is to update any optional parameters of parking lot
        public IActionResult  UpdateParkingLot()
        {
            return Ok(true);
        }

        
    }
}
