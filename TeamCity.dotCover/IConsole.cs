namespace TeamCity.dotCover
{
    internal interface IConsole
    {
        void WriteStdLine(string? text);

        void WriteErrLine(string? error);
    }
}
