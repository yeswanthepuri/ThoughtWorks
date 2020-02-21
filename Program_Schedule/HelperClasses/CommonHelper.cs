using System;
using System.Collections.Generic;
using System.Linq;
using Program_Schedule.Model;

namespace Program_Schedule.HelperClass
{
    public static class CommonHelper
    {
        public static string GetFileName()
        {
            string stringPath = string.Empty;
            while (true)
            {
                System.Console.WriteLine("Please Enter a file Path");
                stringPath = Console.ReadLine();
                if (stringPath != string.Empty)
                    break;
            }
            return stringPath;
        }
        //This Method is use to compute the Output
        public static void Display(List<Talk> talks)
        {
            // var groupedTalks=talks.GroupBy(x => x.Day);
            // try
            // {
            // foreach (var item in groupedTalks)
            // {
            //     System.Console.WriteLine($"Track{item.Key}");
            //     var talksperdays = item.GroupBy(x => x.AssignedDuring);
            //     foreach (var talkperday in talksperdays)
            //     {
            //         foreach (var talk in talkperday)
            //         {
            //             System.Console.WriteLine($"\t\t{talk.TimeDisplay} {talk.Title}");
            //         }
            //         if (talkperday.Key == SlotType.Morning)
            //         {
            //             System.Console.WriteLine($"\t\t12PM Lunch");
            //         }
            //         else
            //         {
            //             System.Console.WriteLine($"\t\t5PM Network Event");
            //         }
            //  }
            // }
            //}
            //     catch(Exception ex)
            //     {
            //         ExceptionHandling.Excep = ex;
            //          throw ExceptionHandling.Excep;
            //     }
            //    Console.ReadKey();
        }

    }

}