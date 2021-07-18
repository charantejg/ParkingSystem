﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ParkingSystem.Domain;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        
        private readonly ITerminal _terminal;
        
        public TerminalController(ITerminal terminal)
        {
            _terminal = terminal;
        }


        /// <summary>
        /// Vehicle info to be fetched from the AI external system
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public ActionResult<Ticket> MakeEntry(Vehicle vehicle)
        {

            try
            {
                
                var entry = (Entry)_terminal;
                var result = entry.ParkVehicle(vehicle);
                return Ok(result);
            }
            catch 
            {
                return NotFound("Parking Lot is full!");
            }
           

        }


        public ActionResult<bool> MakeExit(string ticket)
        {
            try
            {
                var exit = (Exit)_terminal;
                exit.UnPark(ticket);
                return Ok(true);
            }
            catch 
            {
                return NotFound("Error occurred");
            }
           
        }

       

        public ActionResult<IParkingSlot> NeaParkingSlot(Vehicle vehicle)
        {
            return null;
        }


    }
}
