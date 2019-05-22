// ReSharper disable StringLiteralTypo
namespace TeamCity.dotCover
{
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class DotCoverInfo : IDotCoverInfo
    {
        private static readonly Regex PackageVersion = new Regex("<PackageReference.*Version=\"(.+)\".*\\/>");
        private readonly IEnvironment _environment;
        private readonly IFileSystem _fileSystem;

        public DotCoverInfo(
            IEnvironment environment,
            IFileSystem fileSystem)
        {
            _environment = environment;
            _fileSystem = fileSystem;
        }

        public string ToolPath => Path.GetFullPath($@"{BaseDirectory}\..\..\..\..\jetbrains.dotcover.commandlinetools\{GetDotCoverVersion()}\lib\netcoreapp2.0\dotnet-dotcover.exe");

        public string CommandArgs => $"vstest {string.Join(" ", _environment.Arguments.Select(i => $"\"{i}\""))}";

        private string BaseDirectory => Path.GetDirectoryName(_environment.ExecutablePath);

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

            return "2019.1.0";
        }
    }
}