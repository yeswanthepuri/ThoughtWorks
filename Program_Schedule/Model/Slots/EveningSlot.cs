using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public class EveningSlot : Slot
    {
        public override int SlotDuration { get; set; } = (int)Period.Evening;
        public override SlotType TypeOfSlot { get; set; } = SlotType.Evening;

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
            return string.Join(" ",GetTime((int)Period.Evening - SlotDuration, 13), "PM");
        }
    }
}