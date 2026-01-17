using System;
using System.Runtime.InteropServices;

namespace SpiderPRO;

internal static class NativeMethods
{
	public const int WM_NCLBUTTONDOWN = 161;

	public const int HT_CAPTION = 2;

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();
}
