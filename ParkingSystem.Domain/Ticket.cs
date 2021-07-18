using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Entities;

namespace ParkingSystem.Domain
{
   public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public Vehicle VehicleInfo { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
