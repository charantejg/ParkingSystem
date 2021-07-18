using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;


namespace ParkingSystem.Domain
{
   
    public abstract class ParkingSlot: IParkingSlot
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }
        public IParkingFloor ParkingFloor { get; set; }
        public bool Reserved { get; set; }
        public bool IsAvailable { get; set; }
        public byte NoOfSlots { get; set; }
        public string TicketNumber { get; set; }
       
        private IParkingCore _parkingCore;


        protected ParkingSlot(IParkingCore parkingCore)
        {
            _parkingCore = parkingCore;
            
        }

        protected ParkingSlot()
        {
        }
    }
}
