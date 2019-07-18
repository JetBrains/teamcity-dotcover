namespace TeamCity.dotCover;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal class ProcessRunner : IProcessRunner
{
    private readonly IToolProcess _process;
    private readonly IConsole _console;
    private readonly ITrace _trace;

    public ProcessRunner(
        IToolProcess process,
        IConsole console,
        ITrace trace)
    {
        _process = process;
        _console = console;
        _trace = trace;
    }

    public int Run()
    { 
        void OnOutputDataReceived(object sender, DataReceivedEventArgs args) => _console.WriteStdLine(args.Data);
        void OnErrorDataReceived(object sender, DataReceivedEventArgs args) => _console.WriteErrLine(args.Data);

        var process = _process.CreateProcess();
        process.OutputDataReceived += OnOutputDataReceived;
        process.ErrorDataReceived += OnErrorDataReceived;

        _trace.WriteLine($"Starting process: {process.StartInfo.FileName} {process.StartInfo.Arguments}");
        _trace.WriteLine($"From directory: {process.StartInfo.WorkingDirectory}");

        process.Start();
        try
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }
        finally
        {
            process.WaitForExit();
            process.OutputDataReceived -= OnOutputDataReceived;
            process.ErrorDataReceived -= OnErrorDataReceived;
        }

        return process.ExitCode;
    }

    public void Dispose() => _process.Dispose();
}