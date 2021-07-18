using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;


namespace ParkingSystem.Domain
{
    class MediumSlot: ParkingSlot
    {
        public byte NumberOfSlots { get; set; }
       
        public MediumSlot(byte noOfSlot,  IParkingCore parkingCore) : base(parkingCore)
        {
            NumberOfSlots = noOfSlot;
        }
        

        public MediumSlot(int id, int position, int row, byte floor, bool reserved, bool available) : base()
        {
            Id = id;
            Position = position;
            Row = row;
            ParkingFloor = new ParkingFloor
            {
                FloorId = floor
            };
            Reserved = reserved;
            IsAvailable = available;

        }
    }
}
