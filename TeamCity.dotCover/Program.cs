namespace TeamCity.dotCover;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Program: IDisposable
{
    public static int Main()
    {
        try
        {
            return Composer.ResolveProgram().Run();
        }
        finally
        {
            Composer.FinalDispose();
        }
    }

    private readonly IProcessRunner _processRunner;
    private readonly IConsole _console;

    internal Program(
        IProcessRunner processRunner,
        IConsole console)
    {
        _processRunner = processRunner;
        _console = console;
    }

    void IDisposable.Dispose()
    {
        _processRunner.Dispose();
    }

    private int Run()
    {
        try
        {
            return _processRunner.Run();
        }
        catch (ToolException toolException)
        {
            _console.WriteErrLine(toolException.Message);
            return 1;
        }
    }
}