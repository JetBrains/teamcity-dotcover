// ReSharper disable UnusedMember.Global
namespace TeamCity.dotCover;

internal interface IProcessRunner: IDisposable
{
    int Run();
}