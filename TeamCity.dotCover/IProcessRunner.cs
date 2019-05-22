namespace TeamCity.dotCover
{
    using System;

    internal interface IProcessRunner: IDisposable
    {
        int Run();
    }
}