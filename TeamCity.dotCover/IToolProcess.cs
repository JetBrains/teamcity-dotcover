namespace TeamCity.dotCover;

internal interface IToolProcess: IDisposable
{
    Process CreateProcess();
}