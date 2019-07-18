namespace TeamCity.dotCover;

// ReSharper disable once ClassNeverInstantiated.Global
[Serializable]
internal class ToolException: Exception
{
    public ToolException(string message) : base(message) { }
}