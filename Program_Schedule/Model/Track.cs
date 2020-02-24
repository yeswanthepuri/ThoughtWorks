using System;
using System.Collections.Generic;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public class Track : ITrack
    {
        public int NumberofSlots { get; set; } = 2;
        private List<Slot> slots = new List<Slot>();

        public void AddSlot(Slot slot)
        {
            slots.Add(slot);
        }

        public Slot GetSlot()
        {
            return slots[slots.Count - 1];
        }

        public bool IsTrackFull()
        {
            return GetSlotCount() >= 2 || GetSlotCount() == 0;
        }

        public int GetSlotCount()
        {
            return slots.Count;
        }

        public void ResetSlots()
        {
            slots = new List<Slot>();
        }

    }
}
