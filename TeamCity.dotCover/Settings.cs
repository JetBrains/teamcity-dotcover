namespace TeamCity.dotCover
{
    internal class Settings : ISettings
    {
        private readonly string? _toolPath;
        private readonly string? _traceFile;

        public Settings(
            IEnvironment environment)
        {
            environment.TryGetEnvironmentVariable("TCDC_TOOL_PATH", out _toolPath);
            environment.TryGetEnvironmentVariable("TCDC_TRACE_FILE", out _traceFile);
        }

        public string? ToolPath => _toolPath;

        public string? TraceFile => _traceFile;
    }
}