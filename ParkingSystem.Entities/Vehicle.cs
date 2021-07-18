namespace ParkingSystem.Entities
{
    
    public abstract class Vehicle
    {
        public string  Model { get; set; }
        public string VehicleNumber { get; set; }
 
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
