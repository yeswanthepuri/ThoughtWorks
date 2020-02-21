using System.Collections.Generic;
using Program_Schedule.Model;

namespace ProgramSchedule_Test
{
    public static class MockTalkData
    {
        public static List<string> GetMockUnNormalizedTalkData()
        {
            var returnTalks = new List<string>();
            returnTalks.Add("Writing Fast tests Against Enterprise Rails 60min");
            returnTalks.Add("OverDoing in Python 45min");
            returnTalks.Add("Lua for the Masses for 30min");
            returnTalks.Add("Ruby Errors from Mismatched Gem Versions 45min");
            returnTalks.Add("Common Ruby Errors 45min");
            returnTalks.Add("Rails for python Developers lightning");
            returnTalks.Add("Communicating Over Distance 60min");
            returnTalks.Add("Accounting-Driven Development 45min");
            returnTalks.Add("Woah 30min");
            returnTalks.Add("Sit Down and Write 30min");
            returnTalks.Add("Pair Programming vs Noise 45min");
            returnTalks.Add("Ralls magic 60min");
            returnTalks.Add("Ruby on Rails:Why we Should Move on 60min");
            returnTalks.Add("clojure Ate Scala(on my project) 45min");
            returnTalks.Add("Programming in the Boondocks of seattle 30min");
            returnTalks.Add("Ruby vs clojure for Back-End Development 30min");
            returnTalks.Add("Ruby on Rails Legacy App Maintainance 60min");
            returnTalks.Add("A world without HackerNews 30min");
            returnTalks.Add("User Interface CSS in Rails Apps 30min");
            return returnTalks;
        }
        public static List<Talk> GetMockTalkData()
        {
            var returnTalks = new List<Talk>();
            //returnTalks.Add(new Talk(){Title ="Writing Fast tests Against Enterprise Rails",Duration=60});
            //returnTalks.Add(new Talk(){Title ="OverDoing in Python",Duration=45});
            return returnTalks;
        }
    }
}