namespace ParkingSystem.Domain
{
    public interface IParkingLot
    {
         int Id { get; set; }
         byte NoOfFloors { get; set; }
         string Address { get; set; }
    }
}