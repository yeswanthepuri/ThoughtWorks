using System;
using System.Collections.Generic;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public interface ITrack
    {
        int NumberofSlots { get; set; }
        Slot GetSlot();
        int GetSlotCount();
        void AddSlot(Slot slot);
        bool IsTrackFull();
        void ResetSlots();

    }
}
