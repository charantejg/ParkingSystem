using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Domain.Interfaces
{
    public interface IParkingFloor
    {
        int FloorId { get; set; }
        ParkingLot ParkingLot { get; set; }
        int TotalNoOfSmallSlots { get; set; }
        int TotalNoOfMediumSlots { get; set; }
        bool IsCovered { get; set; }
    }
}
