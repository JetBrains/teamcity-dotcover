namespace TeamCity.dotCover;

// ReSharper disable once ClassNeverInstantiated.Global
internal class FileSystem : IFileSystem
{
    public bool FileExists(string path) => File.Exists(path);

    public IEnumerable<string> ReadFileLines(string path) => File.ReadLines(path);
}