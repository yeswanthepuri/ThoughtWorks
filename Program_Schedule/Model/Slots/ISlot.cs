using System;
using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public interface ISlot
    {
        SlotType TypeOfSlot{get;set;}
        string AllotedSlot();
        int GetDuration();
        int AllotDurationforTalk(int talkDuration);
    }
}