using System;

namespace ParkingSystem.Domain.Interfaces
{
    public interface IExit
    {
        int ExitId { get; set; }
        DateTime ExitTime { get; set; }
        bool UnPark(string ticketNumber);
    }
}