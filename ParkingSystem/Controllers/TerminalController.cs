using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AIUtil;
using ParkingSystem.Domain;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        
        private readonly IEntry _entry;
        private readonly IExit _exit;
        
        public TerminalController(IEntry entry, IExit exit)
        {
            _entry = entry;
            _exit = exit;
        }


        /// <summary>
        /// Vehicle info to be fetched from the AI external system
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost("Enter")]
        public ActionResult<ITicket> MakeEntry(VehicleInfo vehicle)
        {

            try
            {
                

                var result = _entry.ParkVehicle(vehicle);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Parking Lot is full!");
            }
           

        }

        [HttpPost("Exit")]
        public ActionResult<bool> MakeExit(string ticket)
        {
            try
            {

                _exit.UnPark(ticket);
                return Ok(true);
            }
            catch 
            {
                return NotFound("Error occurred");
            }
           
        }

        [HttpPost("SuggestSlot")]
        public ActionResult<IParkingSlot> NeaParkingSlot(Vehicle vehicle)
        {
            return null;
        }


    }
}
