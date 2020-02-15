using System;
using Program_Schedule.FileManagement;
using Program_Schedule.Handlers;
using System.Linq;
using Program_Schedule.Model;
using System.Collections.Generic;

namespace Program_Schedule
{
    class Program
    {
        static void Main(string[] args)
        {

            string stringPath = string.Empty;
            while (true)
            {
                System.Console.WriteLine("Please Enter a file Path");
                stringPath = Console.ReadLine();
                if (stringPath != string.Empty)
                    break;
            }
            ReadTextFile readFile = new ReadTextFile(stringPath);
            var rawData = readFile.ReadTextFileToList();
            NormalizeDatatoTalks normalizeDatatoTalks = new NormalizeDatatoTalks(rawData);
            var talksList = normalizeDatatoTalks.GetTalks();
            var totalTalksLength = normalizeDatatoTalks.TotalEventTimeInMin;
            TalksToDays TrackstoDisplay = new TalksToDays(talksList, totalTalksLength);
            //var countofTracks = TrackstoDisplay.NumberOfTracksNeeded;
            var TALKS = TrackstoDisplay.AssignTracks().GroupBy(x => x.Day);
            Display(TALKS);
            Console.ReadKey();
        }

        private static void Display(IEnumerable<IGrouping<int, Talk>> TALKS)
        {
            foreach (var item in TALKS)
            {
                System.Console.WriteLine($"Track{item.Key}");
                var talksperdays = item.GroupBy(x => x.AssignedDuring);
                foreach (var talkperday in talksperdays)
                {
                    //System.Console.WriteLine($"\t{talkperday.Key} {talkperday.Sum(x => x.Duration)}");
                    foreach (var talk in talkperday)
                    {
                        System.Console.WriteLine($"\t\t{talk.TimeDisplay} {talk.Title}");
                    }
                    if (talkperday.Key == SlotType.Morning)
                    {
                        System.Console.WriteLine($"\t\t12PM Lunch");
                    }
                    else
                    {
                        System.Console.WriteLine($"\t\t5PM Network Event");
                    }
                }
            }
        }
    }
}
