using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public class MorningSlot : Slot
    {
        public MorningSlot()
        {
            SlotDuration  = (int)Period.Morning;
            TypeOfSlot  = SlotType.Morning;
        }
        public override int SlotDuration { get; set; }
        public override SlotType TypeOfSlot { get;  set; }

        public override int AllotDurationforTalk(int talkDuration)
        {
            return SlotDuration - talkDuration;
        }
        public override int GetDuration()
        {
            return SlotDuration;
        }

        public override string AllotedSlot()
        {
            return string.Join(" ",GetTime((int)Period.Morning-SlotDuration, 9),"PM");
        }
    }
}
