using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ParkingSystem.Domain;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingLot _parkingLot;
        public ParkingLotController(IParkingLot parkingLot)
        {
            _parkingLot = parkingLot;
        }


        [HttpPost("Create")]
       public IActionResult CreateParkingLot()
        {
            
            // This API is used to create a new parking Lot
            return StatusCode(201);

        }

       [HttpPost("Update")]
        public IActionResult  UpdateParkingLot()
        {
            // This is to update any optional parameters of parking lot
            return Ok(true);
        }

        
    }
}
