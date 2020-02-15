using System;
using System.Collections.Generic;
using System.Linq;

namespace Program_Schedule.Model
{
    public class Slot
    {
        public Guid ID { get; set; }
        public SlotType MorningOrEvening { get; set; }
        public int PeriodInMin { get; set; }
        public int DayNumber { get; set; }
        public static string GetTime(int min,int hours)
        {

                DateTime today = DateTime.Today;
                return new DateTime(today.Year, today.Month, today.Day, hours, 0, 0).AddMinutes(min).ToString("hh:mm");
        }

        public static List<Slot> GetSlots(int NumberOfTracksNeeded)
        {
            List<Slot> result = new List<Slot>();
            var track = 1;
            for (int slotAlotment = 1; slotAlotment <= NumberOfTracksNeeded * 2; slotAlotment++)
            {
                //Morning Slots
                if (slotAlotment % 2 != 0)
                {
                    result.Add(new Slot()
                    {
                        MorningOrEvening = SlotType.Morning,
                        PeriodInMin = (int)Period.Morning,
                        DayNumber = track,
                        ID = Guid.NewGuid()
                    });
                }
                else if (slotAlotment % 2 == 0)
                {
                    result.Add(new Slot()
                    {
                        MorningOrEvening = SlotType.Evening,
                        PeriodInMin = (int)Period.Evening,
                        DayNumber = track,
                        ID = Guid.NewGuid()
                    });
                    track++;
                }
            }
            return result.OrderBy(x => x.PeriodInMin).ToList();
        }
    }
    public enum SlotType
    {
        Morning,
        Evening
    }

    public enum Period
    {

        Morning = 180,
        Evening = 240
    }
}