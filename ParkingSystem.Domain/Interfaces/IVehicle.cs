namespace ParkingSystem.Domain.Interfaces
{
    public interface IVehicle
    {
         string Model { get; set; }
         string VehicleNumber { get; set; }
         User Type { get; set; }
    }
}