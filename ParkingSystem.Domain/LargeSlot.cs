using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;


namespace ParkingSystem.Domain
{
  public class LargeSlot: ParkingSlot
    {

        public byte NumberOfSlots { get; set; }
        public int EndPosition { get; set; }

        public LargeSlot(byte noOfSlot, IParkingCore parkingCore) : base(parkingCore)
        {
            NumberOfSlots = noOfSlot;
        }
        public LargeSlot(int id, int startPosition, int endPosition, int row, byte floor, bool reserved, bool available) : base()
        {
            Id = id;
            Position = startPosition;
            EndPosition = endPosition;
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
