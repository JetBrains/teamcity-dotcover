namespace TeamCity.dotCover
{
    using System;
    using System.Diagnostics;

    internal interface IToolProcess: IDisposable
    {
        Process CreateProcess();
    }
}
