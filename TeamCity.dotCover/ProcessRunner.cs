namespace TeamCity.dotCover
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class ProcessRunner : IProcessRunner
    {
        private readonly IToolProcess _process;
        private readonly IConsole _console;

        public ProcessRunner(
            IToolProcess process,
            IConsole console)
        {
            _process = process;
            _console = console;
        }

        public int Run()
        { 
            void OnOutputDataReceived(object sender, DataReceivedEventArgs args) => _console.WriteStdLine(args.Data);
            void OnErrorDataReceived(object sender, DataReceivedEventArgs args) => _console.WriteErrLine(args.Data);

            var process = _process.CreateProcess();
            process.OutputDataReceived += OnOutputDataReceived;
            process.ErrorDataReceived += OnErrorDataReceived;

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
}
