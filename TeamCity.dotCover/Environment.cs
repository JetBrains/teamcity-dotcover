namespace TeamCity.dotCover;

using Microsoft.DotNet.Cli.Utils;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal class Environment : IEnvironment
{
    public string ExecutablePath => Path.GetFullPath(System.Environment.GetCommandLineArgs()[0]);

    public IEnumerable<string> Arguments => System.Environment.GetCommandLineArgs().Skip(1);

    public IEnumerable<string> EnvironmentVariables => System.Environment.GetEnvironmentVariables().Keys.OfType<string>();

    public string DotnetPath => new Muxer().MuxerPath;

    public bool TryGetEnvironmentVariable(string name, [MaybeNullWhen(false)] out string value) =>
        (value = System.Environment.GetEnvironmentVariable(name)) != default;
}