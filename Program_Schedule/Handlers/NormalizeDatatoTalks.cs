using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Program_Schedule.HelperClass;
using Program_Schedule.Model;

namespace Program_Schedule.Handlers
{
    public class NormalizeDatatoTalks
    {
        private List<string> conferenceDataInput { get; set; }
        private List<ITalk> talks { get; set; } 
        public NormalizeDatatoTalks(List<string> ConferenceDataInput)
        {
            this.conferenceDataInput = ConferenceDataInput;
            talks=new List<ITalk>();
        }
        public List<ITalk> GetTalks()
        {
            foreach (var item in conferenceDataInput)
            {
                Match timeinMin = Regex.Match(item, Const.PATTERN);
                if (timeinMin.Success)
                {
                    var duration = Convert.ToInt16(timeinMin.Value.Replace(Const.MIN, ""));
                    talks.Add(new Talk(item.Trim(),duration));
                }
                else if (item.ToLower().Contains(Const.LIGHTING))
                {
                     talks.Add(new LighteningTalk(item.Trim(),5));
                }
            }
            return talks;
        }
    }
}