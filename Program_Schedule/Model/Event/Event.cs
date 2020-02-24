using System;
using System.Collections.Generic;
using System.Linq;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public class Event
    {
        List<Track> tracks = new List<Track>();
        private void AddTrack()
        {
            var morningSlot = new Track();
            morningSlot.AddSlot(new MorningSlot());
            tracks.Add(morningSlot);
            AllocateItem.Item($"Track{TrackCount()}");
        }
        private ITrack GetTrack()
        {
            if (TrackCount() == 0)
                AddTrack();
            return tracks[tracks.Count() - 1];
        }
        private int TrackCount()
        {
            return tracks.Count();
        }
        //ITrack currentTrack = new Track();
        public void Schedule(List<ITalk> talksList)
        {
            var slottimeLeft = true;
            try
            {
                ITrack currentTrack = GetTrack();
                Slot currentSlot = currentTrack.GetSlot();
                while (talksList.Any())
                {
                    if (!slottimeLeft)
                    {
                        if (currentTrack.IsTrackFull())
                            AddTrack();
                        else
                            currentTrack.AddSlot(new EveningSlot());

                        currentTrack = GetTrack();
                        currentSlot = currentTrack.GetSlot();
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
                        currentSlot.TypeOfSlot == SlotType.Evening)
                        {
                            AllocateItem.Item($"{currentSlot.AllotedSlot()} {item.Title}");
                            currentSlot.SlotDuration = currentSlot.AllotDurationforTalk(item.Duration);
                            talksList.Remove(item);
                            break;
                        }
                    }

                    slottimeLeft = (talksList.Count > 0 && currentSlot.GetDuration() > talksList.Min(x => x.Duration));

                    if (currentSlot.TypeOfSlot == SlotType.Morning && !slottimeLeft)
                    {
                        AllocateItem.Item("Lunch");
                    }
                    else if (!slottimeLeft)
                    {
                        AllocateItem.Item($"{currentSlot.AllotedSlot()} Network");
                        slottimeLeft = false;
                    }
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}
