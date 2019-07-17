// ReSharper disable StringLiteralTypo
namespace TeamCity.dotCover
{
    using System.Collections.Generic;
    using System.IO;
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
            IFileSystem fileSystem)
        {
            _environment = environment;
            _settings = settings;
            _fileSystem = fileSystem;
        }

        public string ToolPath => Path.GetFullPath($@"{BaseDirectory}\..\..\..\..\jetbrains.dotcover.commandlinetools\{GetDotCoverVersion()}\lib\netcoreapp2.0\dotnet-dotcover.exe");

        public string CommandArgs => $"vstest {string.Join(" ", GetArgs())}";

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
}