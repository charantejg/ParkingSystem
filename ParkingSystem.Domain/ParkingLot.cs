using System;

namespace ParkingSystem.Domain
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public byte NoOfFloors { get; set; }
        public string Address { get; set; }

        private static ParkingLot _parkingLot;
        private ParkingLot()
        {
        }

        public static ParkingLot GetSingleInstance(int id, byte floors, string address)
        {
            if (_parkingLot != null)
                _parkingLot = new ParkingLot
                {
                    Id = id, NoOfFloors = floors, Address = address
                };
            return _parkingLot;
        }
      
    }
}
