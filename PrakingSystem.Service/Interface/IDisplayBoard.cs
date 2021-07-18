using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Service.Interface
{
   public interface IDisplayBoard
   {

  

       IParkingSlot SuggestNearestParking();
       int AvailableParkingSlots();




   }
}
