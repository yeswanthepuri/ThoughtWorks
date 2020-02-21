using System;

namespace Program_Schedule.Model
{
    public class LighteningTalk : ITalk
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public LighteningTalk(string title, int duration)
        {
            Title=title;
            Duration=duration;
        }
    }
}