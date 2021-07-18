using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Entities;

namespace AIUtil
{
  public interface IAiService
  {
      Vehicle DisplayVehicleInfo(string registrationNumber, string model);



  }
}
