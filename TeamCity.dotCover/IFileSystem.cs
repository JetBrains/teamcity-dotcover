namespace TeamCity.dotCover;

internal interface IFileSystem
{
    bool FileExists(string path);

    IEnumerable<string> ReadFileLines(string path);
}