namespace TeamCity.dotCover
{
    internal interface ISettings
    {
        string? ToolPath { get; }

        string? TraceFile { get; }
    }
}
