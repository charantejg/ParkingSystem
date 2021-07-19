using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Domain
{
   public class ParkingFloor: IParkingFloor
    {
        public int FloorId { get; set; }
        public int Rows { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public int TotalNoOfSmallSlots { get; set; }
        public int TotalNoOfMediumSlots { get; set; }
        public bool IsCovered { get; set; }

     
    }
}
