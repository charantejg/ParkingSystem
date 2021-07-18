namespace ParkingSystem.Domain.Interfaces
{
   public interface IParkingCore
   {
      bool Park(IParkingSlot parkingSlot, ITicket ticket);

      void UnPark(string ticket);

      int GetNearestParkingSlot(string ticket);

      bool IsParkingFull();
      bool IsSmallSlotFull();
      bool IsLargeSlotFull();

    }
}
