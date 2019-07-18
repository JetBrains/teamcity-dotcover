namespace TeamCity.dotCover;

internal interface ISettings
{
    string? ToolPath { get; }

    string? TraceFile { get; }

    IReadOnlyDictionary<string, string> DotCoverArgs { get; }
}