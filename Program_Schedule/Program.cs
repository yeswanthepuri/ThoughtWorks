using Program_Schedule.FileManagement;
using Program_Schedule.Handlers;
using Program_Schedule.HelperClass;

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
                var totalTalksLength = normalizeDatatoTalks.TotalEventTimeInMin;
                //Get the talks and Assign them and assign them as per slots
                TalksToDays TrackstoDisplay = new TalksToDays(talksList, totalTalksLength);
                var talks = TrackstoDisplay.AssignTracks();
                //Display the slots as per user expecter O/P
                CommonHelper.Display(talks);
            }
            catch
            {
                System.Console.WriteLine(ExceptionHandling.Excep.Message);
            }
        }
    }
}
