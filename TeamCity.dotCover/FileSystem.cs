namespace TeamCity.dotCover
{
    using System.Collections.Generic;
    using System.IO;

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class FileSystem : IFileSystem
    {
        public bool FileExists(string path) => System.IO.File.Exists(path);

        public IEnumerable<string> ReadFileLines(string path) => File.ReadLines(path);
    }
}