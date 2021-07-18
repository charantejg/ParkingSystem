using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Domain.Interfaces
{
   public interface IParkingSlot
    {
        int Id { get; set; } 
        int Position { get; set; }
        int Row { get; set; }
        IParkingFloor ParkingFloor { get; set; }
        bool Reserved { get; set; }
        bool IsAvailable { get; set; }

        public string TicketNumber { get; set; }

    }
}
