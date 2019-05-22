namespace TeamCity.dotCover
{
    internal interface IDotCoverInfo
    {
        string ToolPath { get; }

        string CommandArgs { get; }
    }
}
