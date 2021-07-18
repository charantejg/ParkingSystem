namespace ParkingSystem.Domain.Interfaces
{
   public interface IParkingCore
   {
      bool Park(IParkingSlot parkingSlot, Ticket ticket);

      void UnPark(string ticket);

      ParkingSlot GetNearestParkingSlot(ITicket ticket);

      bool IsParkingFull();
      bool IsSmallSlotFull();
      bool IsLargeSlotFull();

    }
}
