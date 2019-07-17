namespace TeamCity.dotCover
{
    using System.Collections.Generic;

    internal interface IEnvironment
    {
        string ExecutablePath { get; }

        IEnumerable<string> Arguments { get; }

        IEnumerable<string> EnvironmentVariables { get; }

        bool TryGetEnvironmentVariable(string name, out string value);
    }
}