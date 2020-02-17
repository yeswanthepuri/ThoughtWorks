using System;
using System.Collections.Generic;
using System.IO;



namespace Program_Schedule.FileManagement
{
    public class ReadTextFile : IReadFile
    {
        public string Path { get; set; }
        public ReadTextFile(string path)
        {
            Path = path;
        }

        public List<string> ReadFileToList()
        {
            var fileDataToList = new List<string>();
            string ln;
            try
            {
                using (StreamReader file = new StreamReader(Path))
                {
                    while (((ln = file.ReadLine()) != null))
                    {
                        fileDataToList.Add(ln);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.Excep = ex;
                throw new Exception();
            }
            return fileDataToList;
        }
    }
}