using System;

namespace SpiderPRO;

public class ProcessKilledEventArgs : EventArgs
{
	public string ProcessName { get; }

	public int ProcessId { get; }

	public string Reason { get; }

	public ProcessKilledEventArgs(string processName, int processId, string reason)
	{
		ProcessName = processName;
		ProcessId = processId;
		Reason = reason;
	}
}
