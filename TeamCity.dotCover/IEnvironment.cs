namespace TeamCity.dotCover
{
    using System.Collections.Generic;

    internal interface IEnvironment
    {
        string ExecutablePath { get; }

        IEnumerable<string> Arguments { get; }

        bool TryGetEnvironmentVariable(string name, out string value);
    }
}