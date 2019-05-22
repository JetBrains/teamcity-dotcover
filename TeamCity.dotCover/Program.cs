namespace TeamCity.dotCover
{
    using System;
    using IoC;

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Program: IDisposable
    {
        public static int Main()
        {
            using var container = Container.Create().Using<IoCConfiguration>();
            using var program = container.BuildUp<Program>();
            return program.Run();
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
}
