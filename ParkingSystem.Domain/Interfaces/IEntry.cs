using AIUtil;

namespace ParkingSystem.Domain.Interfaces
{
    public interface IEntry
    {
        int EntryId { get; set; }
        ITicket ParkVehicle(VehicleInfo vehicleInfo);


    }
}