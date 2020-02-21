using System;

namespace Program_Schedule.Model
{
    public class Talk : ITalk
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public Talk(string title, int duration)
        {
            Title=title;
            Duration=duration;
        }
    }
}