using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Domain
{
   public class Exit: Terminal
    {
        public DateTime ExitTime { get; set; }
        private readonly IParkingCore _parkingCore;
        public Exit(IParkingCore parkingCore)
        {
            _parkingCore = parkingCore;
        }

        float GenerateFare(IParkingSlot parkingSlot)
        {
            // Not current requirement 
            return 1.0f;
        }

        public bool UnPark(string ticketNumber)
        {

            try
            {
                _parkingCore.UnPark(ticketNumber);
            }
            catch
            {

                throw new Exception("Error occurred during exit!");
            }
           
            
            return true;
        }

        //TODO
       
    }
}
