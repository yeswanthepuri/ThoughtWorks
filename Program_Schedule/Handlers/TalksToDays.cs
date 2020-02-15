using System;
using System.Collections.Generic;
using System.Linq;
using Program_Schedule.Model;

namespace Program_Schedule.Handlers
{
    public class TalksToDays
    {
        private List<Talk> talks { get; set; }

        private Decimal numberOfTracksNeeded;
        private int totalTimeinMin { get; set; }

        public TalksToDays(List<Talk> talks, int totalTimeinMin)
        {
            this.talks = talks;
            NumberOfTracksNeeded = this.totalTimeinMin = totalTimeinMin;
        }

        public List<Talk> AssignTracks()
        {
            //Total Number of Tracks based on the Total RunTime
            List<Slot> slots = Slot.GetSlots((int)NumberOfTracksNeeded);
            var talksOrderbyPeriod = talks.OrderByDescending(x => x.Duration).ToList();
            var assigned_Slots = talks;

            for (int slot = 0; slot < slots.Count(); slot++)
            {
                for (int talk = 0; talk < talksOrderbyPeriod.Count(); talk++)
                {
                    if (!talksOrderbyPeriod[talk].IsAssigned && talksOrderbyPeriod[talk].Duration <= slots[slot].PeriodInMin)
                    {
                        if (slots[slot].MorningOrEvening == SlotType.Morning)
                        {
                           var time = Slot.GetTime((int)Period.Morning-slots[slot].PeriodInMin, 9);
                           talksOrderbyPeriod[talk].TimeDisplay=time+("AM") ;
                        }
                        else
                        {
                          var time =   Slot.GetTime((int)Period.Evening-slots[slot].PeriodInMin, 13);
                          talksOrderbyPeriod[talk].TimeDisplay=time+("PM");
                        }
                        talksOrderbyPeriod[talk].SessionAssigned = slots[slot].ID;
                        talksOrderbyPeriod[talk].Day = slots[slot].DayNumber;
                        talksOrderbyPeriod[talk].IsAssigned = true;
                        talksOrderbyPeriod[talk].AssignedDuring = slots[slot].MorningOrEvening;
                        slots[slot].PeriodInMin -= talksOrderbyPeriod[talk].Duration;

                        
                    }
                }
            }
            return talksOrderbyPeriod;

        }
        public Decimal NumberOfTracksNeeded
        {
            get
            {
                return numberOfTracksNeeded;
            }
            set
            {
                //60 min per hour and 7 working hours per track
                decimal mintoTracks = (value / 60) / 7;
                numberOfTracksNeeded = Math.Ceiling(mintoTracks);
            }
        }
    }
}