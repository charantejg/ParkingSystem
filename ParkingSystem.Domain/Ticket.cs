using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;


namespace ParkingSystem.Domain
{
   public class Ticket : ITicket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public  string RegistrationNumber { get; set; }
        public IVehicle Vehicle { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
