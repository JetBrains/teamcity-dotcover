namespace TeamCity.dotCover
{
    using System;
    using System.Collections.Generic;
    using Castle.DynamicProxy;
    using IoC;
    using IoC.Features;
    using static IoC.Lifetime;

    internal class IoCConfiguration: IConfiguration
    {
        public IEnumerable<IDisposable> Apply(IContainer container)
        {
            yield return container.Bind<ISettings>().As(Singleton).To<Settings>();
            yield return container.Bind<IEnvironment>().As(Singleton).To<Environment>();
            yield return container.Bind<IConsole>().As(Singleton).To<Console>();
            yield return container.Bind<ITrace>().As(Singleton).To<Trace>();
            yield return container.Bind<IFileSystem>().As(Singleton).To<FileSystem>();
            yield return container.Bind<IProcessRunner>().To<ProcessRunner>();
            yield return container.Bind<IDotCoverInfo>().As(Singleton).To<DotCoverInfo>();
            yield return container.Bind<IToolProcess>().As(Singleton).To<DotCoverToolProcess>();
            yield return container.Bind<IInterceptor>().As(Singleton).To<LoggingInterceptor>();

            yield return container.Apply(new InterceptionFeature());
            yield return container.Intercept(key => key.Type != typeof(IInterceptor) && key.Type != typeof(ITrace)  && key.Type != typeof(Program), container.Resolve<IInterceptor>());
        }
    }
}
