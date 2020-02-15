using System;
using System.Collections.Generic;
using System.IO;



namespace Program_Schedule.FileManagement
{
    public class ReadTextFile
    {
        private string Path { get; set; }
        public ReadTextFile(string path)
        {
            Path = path;
        }

        public List<string> ReadTextFileToList()
        {
            var fileDataToList = new List<string>();
            string ln; 
            using (StreamReader file = new StreamReader(Path))
            {
                while (((ln= file.ReadLine()) != null))
                {
                    fileDataToList.Add(ln);
                }
            }
            return fileDataToList;
        }
    }
}