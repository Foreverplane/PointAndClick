using System;

internal class ServerLogger : Test.ILogger {
	public void Log(string message) {
		Console.WriteLine(message);
	}
}
