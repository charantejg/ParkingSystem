using System;
using ParkingSystem.Entities;


namespace AIUtil
{
    public class AiService : IAiService
    {
        public Vehicle DisplayVehicleInfo(string registrationNumber, string model)
        {
            // In realtime this will be an API call to the 
            // AI Tool 
            switch (model)
            {
                case "Car":
                    return new Car() {VehicleNumber = registrationNumber};
                case "AutoRikshaw":
                    return new AutoRickshaw() {VehicleNumber = registrationNumber};
                case "MotorCycle":
                    return new MotorCycle() {VehicleNumber = registrationNumber};
                case "Truck":
                    return new Truck() {VehicleNumber = registrationNumber};
                default:
                    return null;
            }

        }
    }
}

       
    
