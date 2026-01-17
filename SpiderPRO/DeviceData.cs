using System;

namespace SpiderPRO;

public class DeviceData
{
	public string Guid { get; set; }

	public string Udid { get; set; }

	public string Model { get; set; }

	public string SerialNumber { get; set; }

	public DateTime LastUpdated { get; set; }

	public DeviceData()
	{
		LastUpdated = DateTime.Now;
	}

	public void Clear()
	{
		Guid = null;
		Udid = null;
		Model = null;
		SerialNumber = null;
		LastUpdated = DateTime.Now;
	}

	public override string ToString()
	{
		return "GUID: " + Guid + ", UDID: " + Udid + ", Model: " + Model + ", SN: " + SerialNumber;
	}
}
