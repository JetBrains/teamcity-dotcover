namespace TeamCity.dotCover
{
    using System.Collections.Generic;

    internal interface IFileSystem
    {
        bool FileExists(string path);

        IEnumerable<string> ReadFileLines(string path);
    }
}
