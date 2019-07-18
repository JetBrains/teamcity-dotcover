namespace TeamCity.dotCover;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal class Console : IConsole
{
    public void WriteStdLine(string? text)
    {
        if (text == default)
        {
            return;
        }

        System.Console.Out.WriteLine(text);
    }

    public void WriteErrLine(string? error)
    {
        if (error == default)
        {
            return;
        }

        System.Console.Error.WriteLine(error);
    }
}