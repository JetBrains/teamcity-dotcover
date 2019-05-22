## dotCover intergation with [<img src="https://cdn.worldvectorlogo.com/logos/teamcity.svg" height="20" align="center"/>](https://www.jetbrains.com/teamcity/)

[![NuGet TeamCity.dotCover](https://buildstats.info/nuget/TeamCity.dotCover?includePreReleases=false)](https://www.nuget.org/packages/TeamCity.dotCover) [![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0) [<img src="http://teamcity.jetbrains.com/app/rest/builds/buildType:(id:TeamCityPluginsByJetBrains_TeamCitydotCover_Build)/statusIcon.svg"/>](http://teamcity.jetbrains.com/viewType.html?buildTypeId=TeamCityPluginsByJetBrains_TeamCitydotCover_Build&guest=1)

Provides the [<img src="https://cdn.worldvectorlogo.com/logos/teamcity.svg" height="20" align="center" alt="TeamCity" />](https://www.jetbrains.com/teamcity/) integration with [dotCover](https://www.jetbrains.com/dotcover/) via the [Visual Studio Test Platform](https://github.com/Microsoft/vstest). This package is an alternative way to run .NET tests under dotCover described in this [post](https://blog.jetbrains.com/dotnet/2018/08/01/dotnet-dotcover-test/).

<img src="https://github.com/JetBrains/teamcity-dotcover/blob/master/RunTests.gif"/>

### Supported SDK

* .NET Core SDK 2.0+


### Supported Platforms

* .NET 4.5+
* [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) 2.0+

### Usage scenarios

For each test project:

* Add a NuGet reference to the [Visual Studio Test Platform](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/).
   
   ```
   dotnet add package Microsoft.NET.Test.Sdk
   ```
   
* Add NuGet references to NuGet packages of the selected test framework and coresponding test adapter which supports [Visual Studio Test Platform](https://github.com/Microsoft/vstest). For example:
   * MSTest [Framework](https://www.nuget.org/packages/MSTest.TestFramework/) and [Adapter](https://www.nuget.org/packages/MSTest.TestAdapter/)
   
   ```
   dotnet add package MSTest.TestFramework   
   dotnet add package MSTest.TestAdapter
   ```
   
   * XUnit [Framework](https://www.nuget.org/packages/xunit/) and [Adapter](https://www.nuget.org/packages/xunit.runner.visualstudio/)
   
   ```
   dotnet add package xunit   
   dotnet add package xunit.runner.visualstudio
   ```
   
   * NUnit [Framework](https://www.nuget.org/packages/NUnit/) and [Adapter](https://www.nuget.org/packages/NUnit3TestAdapter/)
   
   ```
   dotnet add package NUnit   
   dotnet add package NUnit3TestAdapter
   ```
   
   or others. 
  
Alternatively to two steps above, you could create the a test project from the command line using the specified [template](https://docs.microsoft.com/en-us/dotnet/articles/core/tools/dotnet-new):

   ```
   dotnet new mstest
   ```

   or

   ```
   dotnet new xunit
   ```

   or

   ```
   dotnet new nunit
   ```

* To support the TeamCity integration with dotCover add a NuGet reference to the [TeamCity dotCover package](https://www.nuget.org/packages/TeamCity.dotCover).

   ```
   dotnet add package TeamCity.dotCover
   ```
   
Thus, the final project file could look like the following:

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

To run tests under dotCover use the .NET CLI plugin for [<img src="https://cdn.worldvectorlogo.com/logos/teamcity.svg" height="20" align="center" alt="TeamCity" />](https://www.jetbrains.com/teamcity/) or other TeamCity runners with command equivalent to:

`dotnet test`

or

`dotnet msbuild /t:VSTest`

:warning: It is important to note you should avoid specifying code coverage options in these runners because of the current NuGet package already runs your tests under dotCover.