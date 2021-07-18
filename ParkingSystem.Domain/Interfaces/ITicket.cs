using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Domain.Interfaces
{
   public interface ITicket
    {
         int Id { get; set; }
         string TicketNumber { get; set; }
         string RegistrationNumber { get; set; }
         IVehicle Vehicle { get; set; }
        DateTime EntryTime { get; set; }
    }
}
