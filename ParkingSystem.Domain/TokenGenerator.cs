using System;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Domain
{
    public class TokenGenerator: ITokenGenerator
    {

        public string GetNewToken()
        {
            return "ParkTicket-" + Guid.NewGuid();
        }


    }
}
