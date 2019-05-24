## dotCover intergation with [<img src="https://cdn.worldvectorlogo.com/logos/teamcity.svg" height="20" align="center"/>](https://www.jetbrains.com/teamcity/)

[![NuGet TeamCity.dotCover](https://buildstats.info/nuget/TeamCity.dotCover?includePreReleases=false)](https://www.nuget.org/packages/TeamCity.dotCover) [![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0) [<img src="http://teamcity.jetbrains.com/app/rest/builds/buildType:(id:TeamCityPluginsByJetBrains_TeamCitydotCover_Build)/statusIcon.svg"/>](http://teamcity.jetbrains.com/viewType.html?buildTypeId=TeamCityPluginsByJetBrains_TeamCitydotCover_Build&guest=1)

Provides the [<img src="https://cdn.worldvectorlogo.com/logos/teamcity.svg" height="20" align="center" alt="TeamCity" />](https://www.jetbrains.com/teamcity/) integration with [dotCover](https://www.jetbrains.com/dotcover/) via the [Visual Studio Test Platform](https://github.com/Microsoft/vstest). This package is an alternative way to run .NET tests under dotCover described in this [post](https://blog.jetbrains.com/dotnet/2018/08/01/dotnet-dotcover-test/).

<img src="https://github.com/JetBrains/teamcity-dotcover/blob/master/RunTests.gif"/>

### Supported SDK

* .NET Core SDK 2.0+

### Supported platforms

* .NET 4.5+
* [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) 2.0+

### Supported OS

* Windows

### Usage scenarios

In brief, you can create a test project and run tests collecting code coverage statistics in 3 lines:

```
dotnet new mstest
dotnet add package TeamCity.dotCover
dotnet test
```

where _mstest_ is the one of dotnet [project templates](https://github.com/dotnet/docs/blob/master/docs/core/tools/dotnet-new.md).

The command `dotnet add package TeamCity.dotCover` adds the TeamCity integration with dotCover by referencing the [TeamCity dotCover integration package](https://www.nuget.org/packages/TeamCity.dotCover).
   
The final test project might look like the following:

``` xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>    
    <TargetFrameworks>net45;netcoreapp2.0</TargetFrameworks>    
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.0.1" />
    <PackageReference Include="MSTest.TestAdapter" Version="1.4.0" />
    <PackageReference Include="MSTest.TestFramework" Version="1.4.0" />
    <PackageReference Include="TeamCity.dotCover" Version="2019.1.1" />    
  </ItemGroup>  
</Project>
```

To run tests under dotCover use the [.NET CLI plugin](https://github.com/JetBrains/teamcity-dotnet-plugin) for [<img src="https://cdn.worldvectorlogo.com/logos/teamcity.svg" height="20" align="center" alt="TeamCity" />](https://www.jetbrains.com/teamcity/) or any other TeamCity runners which allow running a command equivalent to:

`dotnet test`

or

`dotnet msbuild /t:VSTest`

### Important notes

* Avoid specifying code coverage options in runners because the [TeamCity dotCover integration package](https://www.nuget.org/packages/TeamCity.dotCover) already runs your tests under dotCover.
* The gathering of code coverage statistics is turned off when tests are not running under TeamCity (for instance when tests are running locally).
