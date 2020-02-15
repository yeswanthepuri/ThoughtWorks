using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Program_Schedule.Model;

namespace Program_Schedule.Handlers
{
    public class NormalizeDatatoTalks
    {
        private List<string> conferenceDataInput { get; set; }
        private List<Talk> Talks { get; set; }
        private int totalEventTimeInMin=0;
        public int TotalEventTimeInMin
        {
            get
            {
                return totalEventTimeInMin;
            }
            set
            {
                totalEventTimeInMin += value;
            }
        }
        public NormalizeDatatoTalks(List<string> ConferenceDataInput)
        {
            this.conferenceDataInput = ConferenceDataInput;
        }

        public List<Talk> GetTalks()
        {
            List<Talk> Talks = new List<Talk>();
            foreach (var item in conferenceDataInput)
            {
                Match timeinMin = Regex.Match(item, "(\\s\\d{1,2}min)$");
                if (timeinMin.Success)
                {
                    var duration = Convert.ToInt16(timeinMin.Value.Replace("min", ""));
                    Talks.Add(new Talk()
                    {
                        Title = item.Trim(),
                        Duration = duration
                    });
                    TotalEventTimeInMin =+ duration;
                }
                else if (item.ToLower().Contains("lightning"))
                {
                    Talks.Add(new Talk()
                    {
                        Title = item.Trim(),
                        Duration = 5
                    });
                    TotalEventTimeInMin =+ 5;
                }
            }
            return Talks;
        }
    }
}