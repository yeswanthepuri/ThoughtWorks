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
    }

}
