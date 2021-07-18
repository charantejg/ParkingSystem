using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIUtil;
using ParkingSystem.Domain.Interfaces;
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

        public ITicket ParkVehicle(VehicleInfo vehicleInfo)
        {
            if(_parkingCore.IsParkingFull())
                throw new Exception("Parking slot is full");

            try
            {
               

                
                ITicket ticket = new Ticket()
                {
                    EntryTime = DateTime.Now,
                    TicketNumber = _tokenGenerator.GetNewToken(),
                    RegistrationNumber = vehicleInfo.RegistrationNumber,
                    Vehicle =  GetVehicleType(vehicleInfo.Model)
                    
                };
                ticket.Vehicle.Type = GetUserType(vehicleInfo.UserType);
                var parkingSlot = GetSlotType(vehicleInfo.Model);
                _parkingCore.Park(parkingSlot, ticket);
                return ticket;
            }
            catch (Exception e)
            {
                throw new Exception("Parking slot is not available");
            }
           
            
        }


        public IParkingSlot GetSlotType(string type)
        {
            switch (type)
            {
                case "car":
                case "AutoRickShaw":
                    return new MediumSlot(1, _parkingCore);
                case "Truck":
                    return new LargeSlot(4, _parkingCore);
                case "MotorCycle":
                    return new SmallSlot(1, _parkingCore);
                default:
                    return new MediumSlot(1, _parkingCore);
            }
        }

        public IVehicle GetVehicleType(string vehicleType)
        {
            switch (vehicleType)
            {
                case "car":
                    return new Car();
                case "AutoRickShaw":
                    return new AutoRickshaw();
                case "Truck":
                    return new Truck();
                case "MotorCycle":
                    return new MotorCycle();
                default:
                    return new Car();
            }
        }

        public User GetUserType(string  userType)
        {
            
            switch (userType)
            {
                case "Employee":
                    return new Employee();
                default:
                    return new Visitor();
            }
        }

    }
}
