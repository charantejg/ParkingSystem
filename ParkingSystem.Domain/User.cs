using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Domain
{
   public abstract class User
    {
        public string ContactNumber { get; set; }
    }

   public class Employee : User
   {
       public int EmployeeId { get; set; }
   }

   public class Visitor : User
   {

   }

}
