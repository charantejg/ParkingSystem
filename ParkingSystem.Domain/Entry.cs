using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Entities;
using ITokenGenerator = ParkingSystem.Domain.Interfaces.ITokenGenerator;


namespace ParkingSystem.Domain
{
   public class Entry: Terminal
    {
       private readonly IParkingCore _parkingCore;
       private readonly ITokenGenerator _tokenGenerator;

       public Entry(IParkingCore parkingCore, ITokenGenerator tokenGenerator)
       {
           _parkingCore = parkingCore;
           _tokenGenerator = tokenGenerator;
       }

        public Ticket ParkVehicle(Vehicle vehicleInfo)
        {
            if(_parkingCore.IsParkingFull())
                throw new Exception("Parking slot is full");

            try
            {
                Ticket.EntryTime = DateTime.Now;
                Ticket.TicketNumber = _tokenGenerator.GetNewToken();
                Ticket.VehicleInfo = vehicleInfo;

                ParkingSlot = GetSlotType(vehicleInfo);

                _parkingCore.Park(ParkingSlot, Ticket);
                  return Ticket;
            }
            catch (Exception e)
            {
                throw new Exception("Parking slot is not available");
            }
           
            
        }


        public IParkingSlot GetSlotType(Vehicle vehicle)
        {
            return vehicle switch
            {
                Car or AutoRickshaw => new MediumSlot(1, _parkingCore),
                MotorCycle => new SmallSlot(1, _parkingCore),
                Truck => new LargeSlot(4, _parkingCore),
                _ => new MediumSlot(1, _parkingCore)
            };
        }
       
       
    }
}
