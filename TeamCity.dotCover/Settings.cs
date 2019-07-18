namespace TeamCity.dotCover;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Settings : ISettings
{
    private const string VarPrefix = "TC_DC_";
    private readonly Dictionary<string, string> _vars = new Dictionary<string, string>();

    public Settings(
        IEnvironment environment)
    {
        foreach (var name in environment.EnvironmentVariables.Where(i => i.ToUpper().StartsWith(VarPrefix)))
        {
            if (name.Length > VarPrefix.Length && environment.TryGetEnvironmentVariable(name, out var val))
            {
                var key = name.Substring(VarPrefix.Length, name.Length - VarPrefix.Length);
                switch (key.ToUpper())
                {
                    case "TOOL_PATH":
                        ToolPath = val;
                        break;

                    case "TRACE_FILE":
                        TraceFile = val;
                        break;

                    default:
                        _vars[key] = val;
                        break;
                }
            }
        }
    }

    public string? ToolPath { get; }

    public string? TraceFile { get; }

    public IReadOnlyDictionary<string, string> DotCoverArgs => _vars;
}