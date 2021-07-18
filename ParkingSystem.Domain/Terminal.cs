using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Domain
{
    public class Terminal: ITerminal
    {
        public byte TerminalNumber { get; set; }
        public IParkingSlot ParkingSlot { get; set; }
        public Ticket Ticket { get; set; }

    }
}
