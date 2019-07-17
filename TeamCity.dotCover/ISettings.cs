namespace TeamCity.dotCover
{
    using System.Collections.Generic;

    internal interface ISettings
    {
        string? ToolPath { get; }

        string? TraceFile { get; }

        IReadOnlyDictionary<string, string> DotCoverArgs { get; }
    }
}
