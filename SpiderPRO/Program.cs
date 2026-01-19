using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SpiderPRO;

internal 
	class Program
{
	private static Mutex singleton = new Mutex(initiallyOwned: true, "SPiderPRO");

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool SetDllDirectory(string lpPathName);

	[STAThread]
	private static void Main()
	{
		ConfigureNativeDllPaths();
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		if (!singleton.WaitOne(TimeSpan.Zero, exitContext: true))
		{
			MessageBox.Show("A5 already running!", "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Process.GetCurrentProcess().Kill();
		}
		else
		{
			Application.Run(new Form1());
		}
	}

	private static void ConfigureNativeDllPaths()
	{
		try
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			bool is64Bit = Environment.Is64BitProcess;
			string nativeFolder = (is64Bit ? "win-x64" : "win-x86");
			string nativePath = Path.Combine(baseDirectory, nativeFolder);
			if (!Directory.Exists(nativePath))
			{
				MessageBox.Show("Native libraries folder not found:\n\n" + nativePath + "\n\nPlease ensure the win-x86 or win-x64 folder exists with the required DLLs.", "Missing Libraries", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (SetDllDirectory(nativePath))
			{
			}
			else
			{
			}
			string currentPath = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
			if (!currentPath.Contains(nativePath))
			{
				Environment.SetEnvironmentVariable("PATH", nativePath + ";" + currentPath);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error loading native libraries:\n\n" + ex.Message + "\n\nThe application may not work correctly.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
