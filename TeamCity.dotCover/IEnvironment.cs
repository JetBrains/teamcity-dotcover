namespace TeamCity.dotCover;

internal interface IEnvironment
{
    string ExecutablePath { get; }

    IEnumerable<string> Arguments { get; }

    IEnumerable<string> EnvironmentVariables { get; }

    string DotnetPath { get; }

    bool TryGetEnvironmentVariable(string name, [MaybeNullWhen(false)] out string value);
}