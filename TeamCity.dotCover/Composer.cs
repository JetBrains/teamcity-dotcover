// ReSharper disable UnusedMember.Local
namespace TeamCity.dotCover;

using Pure.DI;

internal static partial class Composer
{
    private static void Setup() => DI.Setup()
        .Default(Lifetime.Singleton)
        .Bind<Program>().To<Program>()
        .Bind<ISettings>().To<Settings>()
        .Bind<IEnvironment>().To<Environment>()
        .Bind<IConsole>().To<Console>()
        .Bind<ITrace>().To<Trace>()
        .Bind<IFileSystem>().To<FileSystem>()
        .Bind<IProcessRunner>().To<ProcessRunner>()
        .Bind<IDotCoverInfo>().To<DotCoverInfo>()
        .Bind<IToolProcess>().To<DotCoverToolProcess>();
}