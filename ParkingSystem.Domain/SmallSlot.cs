using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;


namespace ParkingSystem.Domain
{
  public  class SmallSlot: ParkingSlot
    {

        public byte NumberOfSlots { get; set; }
        public bool IsCompactSlotUsed { get; set; }

        public SmallSlot(byte noOfSlot,  IParkingCore parkingCore) : base(parkingCore)
        {
            NumberOfSlots = noOfSlot;
        }

        public SmallSlot(int id, int position, int row, byte floor, bool reserved, bool available) : base()
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
