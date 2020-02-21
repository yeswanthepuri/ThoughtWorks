using System;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public interface ITalk
    {
        string Title { get; set; }
        int Duration { get; set; }
    }
}