namespace TeamCity.dotCover
{
    using System.IO;

    // ReSharper disable once UnusedMember.Global
    internal class Trace : ITrace
    {
        private readonly string? _traceFile;

        public Trace(ISettings settings)
        {
            _traceFile = settings.TraceFile;
        }

        public void WriteLine(string? text)
        {
            if (_traceFile == default || text == default)
            {
                return;
            }

            File.AppendAllText(_traceFile, text + "\n");
        }
    }
}