using System;

namespace Program_Schedule.Model
{
    public class Track
    {
       public int FirstOrSecond { get; set; }
       public int TrackNumber { get; set; }
        
        public DateTime StartingTime_for_Track
        {
            get
            {
                DateTime today = DateTime.Today;
                return new DateTime(today.Year, today.Month, today.Day, 9, 0, 0);
            }
        }
         public DateTime LunchStartTime_for_Track
        {
            get
            {
                DateTime today = DateTime.Today;
                return new DateTime(today.Year, today.Month, today.Day, 12, 0, 0);
            }
        }
        public DateTime LunchEndTime_for_Track
        {
            get
            {
                DateTime today = DateTime.Today;
                return new DateTime(today.Year, today.Month, today.Day, 13, 0, 0);
            }
        }
        public DateTime EndTime_for_Track
        {
            get
            {
                DateTime today = DateTime.Today;
                return new DateTime(today.Year, today.Month, today.Day, 17, 0, 0);
            }
        }

    }
}