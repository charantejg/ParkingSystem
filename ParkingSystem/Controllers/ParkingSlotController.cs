using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSlotController : ControllerBase
    {
        // Public Api
        public ActionResult<bool> UpdateParkingSlotStatus(IParkingSlot parkingSlot)
        {
            //This can query with the Sensor external system and keep the DB up to date 
            return Ok(true);

        }

#region "Private Internal API"

        [Authorize]
        public ActionResult<IList<IParkingSlot>> CreateParkingSlot()
        {

            return Ok();
        }
        [Authorize]
        public ActionResult<IParkingSlot> UpdateParkingSlot(IParkingSlot parkingSlots)
        {

            return Ok();
        }
        [Authorize]
        public ActionResult<IList<IParkingSlot>> UpdateParkingManySlots(IList<IParkingSlot> parkingSlots)
        {

            return Ok();
        }
        [Authorize]
        public ActionResult DeleteParkingSlot(IParkingSlot parkingSlots)
        {

            return Ok();
        }

       #endregion

    }
}
