using UnityEngine;
public class UnityLogger : Test.ILogger {

	public void Log(string message) {
		Debug.Log($"<color=green>UnityLogger</color>: {message}");
	}
}
