using System;
using System.Collections.Generic;
using System.Linq;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{

    public class Event
    {
        ITrack currentTrack = new Track();

        Int16 trackCount = 0;

        public void Schedule(List<ITalk> talksList)
        {
            var slottimeLeft = false;
            SlotType currentRunningSlot = new SlotType();
            Slot currentSlot = new MorningSlot();
            while (talksList.Any())
            {
                if (currentTrack.GetSlotCount() == 2 && !slottimeLeft)
                    currentTrack.ResetSlots();

                if (currentTrack.GetSlotCount() == 0 && !slottimeLeft)
                {
                    trackCount++;
                    AllocateItem.Item($"Track{trackCount}");
                    currentTrack.AddSlot(currentSlot);
                    currentSlot = new MorningSlot();
                    currentRunningSlot = SlotType.Morning;
                }
                else if (currentTrack.GetSlotCount() == 1 && !slottimeLeft)
                {
                    currentSlot = new EveningSlot();
                    currentTrack.AddSlot(currentSlot);
                    currentRunningSlot = SlotType.Evening;
                }
                //Assign Talks
                foreach (var item in talksList)
                {
                    if (currentSlot.GetDuration() >= item.Duration && item.Duration > 5)
                    {
                        AllocateItem.Item($"{currentSlot.AllotedSlot()} {item.Title}");
                        currentSlot.SlotDuration = currentSlot.AllotDurationforTalk(item.Duration);
                        talksList.Remove(item);
                        break;
                    }
                    else if (currentSlot.GetDuration() >= item.Duration &&
                    currentRunningSlot == SlotType.Evening)
                    {
                        AllocateItem.Item($"{currentSlot.AllotedSlot()} {item.Title}");
                        currentSlot.SlotDuration = currentSlot.AllotDurationforTalk(item.Duration);
                        talksList.Remove(item);
                        break;
                    }
                }

                slottimeLeft = (talksList.Count > 0 && currentSlot.GetDuration() > talksList.Min(x => x.Duration));

                if (currentRunningSlot == SlotType.Morning && !slottimeLeft)
                {
                    AllocateItem.Item("Lunch");
                }
                else if (!slottimeLeft)
                {
                    AllocateItem.Item($"{currentSlot.AllotedSlot()} Network");
                }
            }
        }
    }
}
