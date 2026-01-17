using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SpiderPRO.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("SpiderPRO.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap device_recovery => (Bitmap)ResourceManager.GetObject("device_recovery", resourceCulture);

	internal static Bitmap icons8_unlock_32 => (Bitmap)ResourceManager.GetObject("icons8-unlock-32", resourceCulture);

	internal static Bitmap iSkorpionxx => (Bitmap)ResourceManager.GetObject("xxx", resourceCulture);

    public static Icon MyErrorIcon { get; internal set; }

    internal Resources()
	{
	}
}
