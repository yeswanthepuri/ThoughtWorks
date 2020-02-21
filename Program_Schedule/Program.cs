using System.Collections.Generic;
using System.Linq;
using Program_Schedule.FileManagement;
using Program_Schedule.Handlers;
using Program_Schedule.HelperClass;
using Program_Schedule.Model;

namespace Program_Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Get the input from user and user Path
                string stringPath = CommonHelper.GetFileName();
                //Read the file
                IReadFile readFile = new ReadTextFile(stringPath);
                var rawData = readFile.ReadFileToList();
                //Get the input form file and make them as Talks
                NormalizeDatatoTalks normalizeDatatoTalks = new NormalizeDatatoTalks(rawData);
                var talksList = normalizeDatatoTalks.GetTalks();
                Event program = new Event();
                program.Schedule(talksList);
            }
            catch
            {
                System.Console.WriteLine(ExceptionHandling.Excep.Message);
            }
        }
    }
}
