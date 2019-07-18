// ReSharper disable StringLiteralTypo
namespace TeamCity.dotCover;

using System.Text.RegularExpressions;

// ReSharper disable once ClassNeverInstantiated.Global
internal class DotCoverInfo : IDotCoverInfo
{
    private static readonly Regex PackageVersion = new Regex("<PackageReference.*Version=\"(.+)\".*\\/>");
    private readonly IEnvironment _environment;
    private readonly ISettings _settings;
    private readonly IFileSystem _fileSystem;

    public DotCoverInfo(
        IEnvironment environment,
        ISettings settings,
        IFileSystem fileSystem,
        ITrace trace)
    {
        _environment = environment;
        _settings = settings;
        _fileSystem = fileSystem;
        trace.WriteLine($"Packages Path: {PackagesPath}");
        trace.WriteLine($"Tool Path: {ToolPath}");
    }

    public string ToolPath => Path.GetFullPath($"{BinPath}{Path.PathSeparator}dotnet-dotcover.dll");

    private string BinPath => Path.GetFullPath($"{PackagesPath}{Path.PathSeparator}jetbrains.dotcover.dotnetclitool{Path.PathSeparator}{GetDotCoverVersion()}{Path.PathSeparator}lib{Path.PathSeparator}netcoreapp2.0");

    private string PackagesPath => Path.GetFullPath($"{BaseDirectory}{Path.PathSeparator}..{Path.PathSeparator}..{Path.PathSeparator}..{Path.PathSeparator}.."); 

    public string CommandArgs => $"{_environment.DotnetPath} --additional-deps {BinPath}{Path.PathSeparator}DotNetCliTool.deps.json --additionalprobingpath {PackagesPath} vstest {string.Join(" ", GetArgs())}";

    private string BaseDirectory => Path.GetDirectoryName(_environment.ExecutablePath) ?? string.Empty;

    private string GetDotCoverVersion()
    {
        var projFile = BaseDirectory + @"\dotCoverRestore.csproj";
        foreach (var line in _fileSystem.ReadFileLines(projFile))
        {
            var match = PackageVersion.Match(line);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
        }

        throw new InvalidOperationException($"Cannot get dotCover version from project file \"{projFile}\".");
    }

    private IEnumerable<string> GetArgs()
    {
        foreach (var environmentArgument in _environment.Arguments)
        {
            yield return $"\"{environmentArgument}\"";
        }

        foreach (var dotCoverArgument in _settings.DotCoverArgs)
        {
            yield return $"\"--dc{dotCoverArgument.Key}={dotCoverArgument.Value}\"";
        }
    }
}