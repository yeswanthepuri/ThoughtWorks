using System.Collections.Generic;

namespace Program_Schedule.FileManagement
{
    public interface IReadFile
    {
        string Path { get; set; }
        List<string> ReadFileToList();
    }
}