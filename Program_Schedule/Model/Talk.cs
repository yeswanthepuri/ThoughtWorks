using System;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public class Talk
    {
        public string TimeDisplay { get; set; }
        public int Day { get; set; }
        public SlotType AssignedDuring { get; set; }
        public Guid SessionAssigned { get; set; }
        public bool IsAssigned { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
    }
}