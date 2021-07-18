using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Domain
{
    
    public abstract class Vehicle: IVehicle
    {
        public string  Model { get; set; }
        public string VehicleNumber { get; set; }
        public User Type { get; set; }
 
    }

   
    public class Car : Vehicle
    {
      
        public byte CompactSlot { get; set; } = 1;
        
    }

    public class AutoRickshaw : Vehicle
    {
        public byte CompactSlot { get; set; } = 1;

    }

    public class MotorCycle : Vehicle
    {
        public byte BikeSlot { get; set; } = 1;
        public byte CompactSlot { get; set; } = 1;
        

    }

    public class Truck : Vehicle
    {
        public byte CompactSlot { get; set; } = 4;
    }

}
