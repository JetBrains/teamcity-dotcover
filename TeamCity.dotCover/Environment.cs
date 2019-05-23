namespace TeamCity.dotCover
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class Environment : IEnvironment
    {
        public string ExecutablePath => Path.GetFullPath(System.Environment.GetCommandLineArgs()[0]);

        public IEnumerable<string> Arguments => System.Environment.GetCommandLineArgs().Skip(1);

        public bool TryGetEnvironmentVariable(string name, out string? value) => (value = System.Environment.GetEnvironmentVariable(name)) != default;
    }
}
