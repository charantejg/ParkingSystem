using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Domain
{
    public class ParkingCore : IParkingCore
    {

        private readonly Dictionary<int, IParkingSlot> _compactSlotsInUse;
        private readonly SortedList<int, IParkingSlot> _compactSlotsAvailable;
        private readonly Dictionary<int, IParkingSlot> _smallSlotsInUse;
        private readonly SortedList<int, IParkingSlot> _smallSlotsAvailable;
    
        public ParkingCore()
        {
            _smallSlotsAvailable = new SortedList<int, IParkingSlot>();
            _smallSlotsInUse = new Dictionary<int, IParkingSlot>();
            _compactSlotsInUse = new Dictionary<int, IParkingSlot>();
            _compactSlotsAvailable = new SortedList<int, IParkingSlot>();
           
            InitializeCompactSlots();
            InitializeSmallSlots();

        }

        /// <summary>
        /// In the realtime application this method is initialized once at the time of
        /// bootstrap and data is fetched from the DB
        /// </summary>
        private void InitializeSmallSlots()
        {
            //Constant , to be retrieved from DB
            // number of floor and available slots for each floor

            var slotsAvailable = new int[5][];
            slotsAvailable[0] = new int[5];
            slotsAvailable[1] = new int[10];
            slotsAvailable[2] = new int[10];
            slotsAvailable[3] = new int[10];
            slotsAvailable[4] = new int[10];


            //initialize the free slots  - all these logic are for demo purpose
            byte id = 1;
            byte floorCount = 0;
            const byte maxReserve = 2;
            foreach (var floor in slotsAvailable)
            {
                var startPosition = 1;
                var row = 1;
                foreach (var item in floor)
                {

                    var slot = new SmallSlot(id, startPosition, row, floorCount, false, true)
                    {
                        Id = id,
                        ParkingFloor = {FloorId = floorCount},
                        IsAvailable = true,
                        Position = startPosition,
                        Row = row,
                        NoOfSlots = 1
                    };


                    if (startPosition <= maxReserve)
                        slot.Reserved = true;

                    _smallSlotsAvailable.Add(id, slot);

                    id++;
                    startPosition++;
                }
                floorCount++;
            }

            //Initialize Occupied slots
            // Get list of occupied slots from db
            //Constant -sample data

            _smallSlotsInUse.Add(1, new MediumSlot(1, 1, 1, 0, false, true));
            _smallSlotsInUse.Add(2, new MediumSlot(2, 1, 2, 0, false, true));
            _smallSlotsInUse.Add(3, new MediumSlot(3, 1, 3, 0, false, true));
            _smallSlotsInUse.Add(4, new MediumSlot(4, 1, 4, 0, false, true));
            _smallSlotsInUse.Add(5, new MediumSlot(5, 2, 1, 1, false, true));

        }


        private void InitializeCompactSlots()
        {
            //Constant , to be retrieved from DB
            // number of floor and available slots for each floor
            var slotsAvailable = new int[5][];
            slotsAvailable[0] =  new int[5];
            slotsAvailable[1] = new int[10];
            slotsAvailable[2] = new int[10];
            slotsAvailable[3] = new int[10];
            slotsAvailable[4] = new int[10];
            

            //initialize the free slots  - all these logic are for demo purpose
            var id =  1;
            var floorCount = 0;
            const byte maxReserve = 2;
            foreach (var floor in slotsAvailable)
            {
                var startPosition = 1;
                var row = 1;
               
                    
                foreach (var item in floor)
                {

                    var slot = new MediumSlot(id, startPosition, row, floorCount, false, true)
                    {
                        Id = id,
                        ParkingFloor = {FloorId = floorCount},
                        IsAvailable = true,
                        Position = startPosition,
                        Row = row,
                        NoOfSlots = 1
                    };
                    
                    if (startPosition <= maxReserve)
                        slot.Reserved = true;

                    _compactSlotsAvailable.Add(id, slot);

                    id++;
                    startPosition++;
                }
                floorCount++;
            }

            //Initialize Occupied slots
            // Get list of occupied slots from db
            //Constant -sample data

            _compactSlotsInUse.Add(1, new MediumSlot(1, 1, 1, 0, false, true));
            _compactSlotsInUse.Add(2, new MediumSlot(2, 1, 2, 0, false, true));
            _compactSlotsInUse.Add(3, new MediumSlot(3, 1, 3, 0, false, true));
            _compactSlotsInUse.Add(4, new MediumSlot(4, 1, 4, 0, false, true));
            _compactSlotsInUse.Add(5, new MediumSlot(5, 2, 1, 1, false, true));


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parkingSlot"></param>
        /// <param name="ticket"></param>
        public bool Park(IParkingSlot parkingSlot, ITicket ticket)
        {
            switch (parkingSlot)
            {
                case MediumSlot slot:
                    return AllocateCompactSlot(slot, ticket);
                case SmallSlot slot:
                    {
                        if (!IsSmallSlotFull())
                            return AllocateSmallSlot(slot, ticket);
                        slot.IsCompactSlotUsed = true;
                        return AllocateCompactSlot(slot, ticket);
                    }
                case LargeSlot slot:
                    return AllocateLargeSlot(slot, ticket);
            }

            return false;
        }

        public void UnPark(string ticket)
        {
            var parkingSlot = _compactSlotsInUse.Values.FirstOrDefault(x => x.TicketNumber.Equals(ticket));

            switch (parkingSlot)
            {
                case MediumSlot slot:
                    _compactSlotsInUse.Remove(slot.Id);
                    slot.IsAvailable = true;
                    slot.TicketNumber = string.Empty;
                    _compactSlotsAvailable.Add(slot.Id, parkingSlot);
                    break;
                case SmallSlot slot:
                    _smallSlotsInUse.Remove(slot.Id);
                    slot.IsAvailable = true;
                    slot.TicketNumber = string.Empty;
                    _smallSlotsAvailable.Add(slot.Id, parkingSlot);
                    break;
                case LargeSlot slot:

                    for (int i = 0; i < 5; i++)
                    {
                        _compactSlotsInUse.Remove(slot.Id + i);
                        slot.IsAvailable = true;
                        slot.TicketNumber = string.Empty;
                        _compactSlotsAvailable.Add(slot.Id + i, parkingSlot);

                    }
                    break;

            }


        }



        /// <summary>
        /// This method checks if both bike(small)  and car (compact) available slots are full or not
        /// </summary>
        /// <returns>bool</returns>
        public bool IsParkingFull()
        {
            return _smallSlotsAvailable.Count == 0 && _compactSlotsAvailable.Count == 0;
        }


        public bool IsSmallSlotFull()
        {
            throw new NotImplementedException();
        }

        public bool IsLargeSlotFull()
        {
            throw new NotImplementedException("Not implemented");
        }

        public int GetNearestParkingSlot(string ticket)
        {

            // this logic to be implemented 
            return 1;

        }

        private bool AllocateCompactSlot(IParkingSlot slot, ITicket ticket)
        {
            var freeCompactSlotValue = _compactSlotsAvailable.Values.FirstOrDefault(
                x => x.ParkingFloor.FloorId > 0 && x.IsAvailable &&
                     x.Reserved == (ticket.Vehicle.Type is Employee));

            if (freeCompactSlotValue == null)
                return false;

            _compactSlotsAvailable.Remove(freeCompactSlotValue.Id);
            slot.IsAvailable = false;
            slot.TicketNumber = ticket.TicketNumber;
            _compactSlotsInUse.Add(slot.Id, slot);
            return true;
        }

        private bool AllocateSmallSlot(IParkingSlot slot, ITicket ticket)
        {
            var freeSmallSlotValue = _compactSlotsAvailable.Values.FirstOrDefault(
                x => x.IsAvailable &&
                     x.Reserved == (ticket.Vehicle.Type is Employee));

            if (freeSmallSlotValue == null)
                return false;

            _compactSlotsAvailable.Remove(freeSmallSlotValue.Id);
            slot.IsAvailable = false;
            _compactSlotsInUse.Add(slot.Id, slot);
            return true;
        }

        private bool AllocateLargeSlot(IParkingSlot slot, ITicket ticket)
        {
            var allSlots = _compactSlotsAvailable.Values.ToList().FindAll
            (x => x.ParkingFloor.FloorId == 0 && x.IsAvailable &&
                  x.Reserved == (ticket.Vehicle.Type is Employee));

            var freeSlotRow = from f
                    in allSlots.GroupBy(d => d.Row)

                              select new
                              {
                                  count = f.Count(),
                                  f.First().Row

                              };

            var largeConsecutiveRows = freeSlotRow.First(d => d.count >= 4);
            var freeSlots = allSlots.
                Where(x => x.Row == largeConsecutiveRows.Row).Take(4).ToList();

            if (freeSlots.Count < 4)
                return false;


            foreach (var freeSlot in freeSlots)
            {
                _compactSlotsAvailable.Remove(freeSlot.Id);
                freeSlot.IsAvailable = false;
                freeSlot.TicketNumber = ticket.TicketNumber;
                _compactSlotsInUse.Add(freeSlot.Id, freeSlot);

            }

            return true;
        }


    }
}
