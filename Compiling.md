# Introduction #

Source code is provided with a Visual Studio 2008 solution file, which is the easiest way to compile the source code.

An alternate (recommended) way to build is to use NAnt. A build file is provided.


# Compiling with NAnt #

The default build target will compile and generate XML documentation files, but will not run unit tests.

  * **To run unit tests using NUnit**, run `nant test`. Requires `NUnit.console.exe` to be in the system path.
  * **To generate unit test coverage files using NCover**, run `nant cover`. Requires the `NCoverExplorer.NAntTasks.dll` added to your NAnt extensions.
  * **To generate unit test coverage files and visualize them using NCoverExplorer**, run `nant coverex`. Requires the `NCoverExplorer.NAntTasks.dll` added to your NAnt extensions.

The easiest way to get NUnit, NCover, and NCoverExplorer is by downloading [TestDriven.net](http://www.testdriven.net). To get the NCover add-in to NAnt, go to http://www.kiwidude.com/dotnet/DownloadPage.html.