using System;
using System.Collections.Generic;
using System.Linq;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public abstract class Slot : ISlot
    {
        public abstract int SlotDuration { get; set; }
        public abstract SlotType TypeOfSlot { get; set; }

        public abstract int GetDuration();
        public abstract int AllotDurationforTalk(int talkDuration);
        public abstract string AllotedSlot();
        internal string GetTime(int min, int hours)
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, today.Day, hours, 0, 0).AddMinutes(min).ToString("hh:mm");
        }
    }
}