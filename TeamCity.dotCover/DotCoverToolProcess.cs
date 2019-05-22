namespace TeamCity.dotCover
{
    using System.Diagnostics;

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class DotCoverToolProcess : IToolProcess
    {
        private readonly IDotCoverInfo _dotCoverInfo;
        private readonly IFileSystem _fileSystem;
        private readonly ISettings _settings;

        public DotCoverToolProcess(
            IDotCoverInfo dotCoverInfo,
            IFileSystem fileSystem,
            ISettings settings)
        {
            _dotCoverInfo = dotCoverInfo;
            _fileSystem = fileSystem;
            _settings = settings;
        }

        public Process CreateProcess()
        {
            var toolPath = TryGetToolPath(_settings.ToolPath) ?? TryGetToolPath(_dotCoverInfo.ToolPath);
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = toolPath,
                    Arguments = _dotCoverInfo.CommandArgs
                }
            };
        }

        public void Dispose() { }

        private string? TryGetToolPath(string? path)
        {
            if (path == default)
            {
                return default;
            }

            if (!_fileSystem.FileExists(path))
            {
                throw new ToolException($"\"{path}\" was not found.");
            }

            return path;
        }
    }
}