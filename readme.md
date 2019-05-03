# Events Demo
A sample .NET Core console application making use of asynchronous event-handling.

## Built With
* .NET Core 2.1
* C#
* Visual Studio 2017

## Usage
1. Clone the source code.
2. Compile the solution with the DotNet Core CLI or within Visual Studio.
    1. Navigate to the project folder.
	2. Run `dotnet build EventsDemo.sln`
3. Run via the CLI or debug within Visual Studio.
    * `dotnet run --project EventsDemo`

The primary benefit from this project will be from viewing the source code in your editor of choice. The code provides a simple example of handling a custom event along with some asynchronous tasks.

## Notes
1. "Core" in `EventsDemo.Core` refers to the domain objects, a la "Clean" architecture (though admittedly not a great example of such), not .NET Core itself.