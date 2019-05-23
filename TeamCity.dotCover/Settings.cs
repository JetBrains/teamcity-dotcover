namespace TeamCity.dotCover
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Settings : ISettings
    {
        private readonly string? _toolPath;
        private readonly string? _traceFile;

        public Settings(
            IEnvironment environment)
        {
            environment.TryGetEnvironmentVariable("TC_TOOL_PATH", out _toolPath);
            environment.TryGetEnvironmentVariable("TC_TRACE_FILE", out _traceFile);
        }

        public string? ToolPath => _toolPath;

        public string? TraceFile => _traceFile;
    }
}