using Program_Schedule.HelperClass;

namespace Program_Schedule.Model
{
    public class EveningSlot : Slot
    {
        public EveningSlot()
        {
            SlotDuration = (int)Period.Evening;
            TypeOfSlot = SlotType.Evening;
        }
        public override int SlotDuration { get; set; }
        public override SlotType TypeOfSlot { get; set; }

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
            return string.Join(" ", GetTime((int)Period.Evening - SlotDuration, 13), "PM");
        }
    }
}
