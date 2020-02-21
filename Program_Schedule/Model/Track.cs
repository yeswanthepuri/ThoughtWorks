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

        public Slot GetSlot(SlotType slotType)
        {
            if (slotType == SlotType.Morning)
            {
                return slots[0];
            }
            else
                return slots[1];
        }

        public bool IsTrackFull()
        {
            return GetSlotCount() >= 2;
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
