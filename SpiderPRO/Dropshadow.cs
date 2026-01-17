using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SpiderPRO;

public class Dropshadow : Form
{
	private Bitmap _shadowBitmap;

	private Color _shadowColor;

	private int _shadowH;

	private byte _shadowOpacity = 90;

	private int _shadowV;

	public int ShadowBlur { get; set; }

	public int ShadowSpread { get; set; }

	public int ShadowRadius { get; set; }

	public Color ShadowColor
	{
		get
		{
			return _shadowColor;
		}
		set
		{
			_shadowColor = value;
			_shadowOpacity = _shadowColor.A;
		}
	}

	public Bitmap ShadowBitmap
	{
		get
		{
			return _shadowBitmap;
		}
		set
		{
			_shadowBitmap = value;
			SetBitmap(_shadowBitmap, ShadowOpacity);
		}
	}

	public byte ShadowOpacity
	{
		get
		{
			return _shadowOpacity;
		}
		set
		{
			_shadowOpacity = value;
			SetBitmap(ShadowBitmap, _shadowOpacity);
		}
	}

	public int ShadowH
	{
		get
		{
			return _shadowH;
		}
		set
		{
			_shadowH = value;
			RefreshShadow(redraw: false);
		}
	}

	public int OffsetX => ShadowH - (ShadowBlur + ShadowSpread);

	public int OffsetY => ShadowV - (ShadowBlur + ShadowSpread);

	public new int Width => base.Owner.Width + (ShadowSpread + ShadowBlur) * 2;

	public new int Height => base.Owner.Height + (ShadowSpread + ShadowBlur) * 2;

	public int ShadowV
	{
		get
		{
			return _shadowV;
		}
		set
		{
			_shadowV = value;
			RefreshShadow(redraw: false);
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 524288;
			obj.ExStyle |= 32;
			return obj;
		}
	}

	public Dropshadow(Form owner)
	{
		base.Owner = owner;
		ShadowColor = Color.Black;
		base.FormBorderStyle = FormBorderStyle.None;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		ShadowBlur = 15;
		ShadowSpread = 3;
		ShadowRadius = 3;
		ShadowH = 0;
		ShadowV = 0;
		base.Width = base.Owner.Width + (ShadowSpread + ShadowBlur) * 2;
		base.Height = base.Owner.Height + (ShadowSpread + ShadowBlur) * 2;
		base.Owner.LocationChanged += delegate
		{
			UpdateLocation();
		};
		base.Owner.SizeChanged += delegate
		{
			RefreshShadow();
		};
		base.Owner.FormClosing += delegate
		{
			Close();
		};
		base.Owner.VisibleChanged += delegate
		{
			if (base.Owner != null)
			{
				base.Visible = base.Owner.Visible;
			}
		};
		base.Owner.Activated += delegate
		{
			base.Owner.BringToFront();
		};
		base.Load += delegate
		{
			RefreshShadow();
		};
	}

	public void UpdateLocation(object sender = null, EventArgs eventArgs = null)
	{
		if (base.Owner != null)
		{
			Point pos = base.Owner.Location;
			pos.Offset(OffsetX, OffsetY);
			base.Location = pos;
			base.Owner.BringToFront();
		}
	}

	public void RefreshShadow(bool redraw = true)
	{
		if (base.Owner != null)
		{
			base.Width = base.Owner.Width + (ShadowSpread + ShadowBlur) * 2;
			base.Height = base.Owner.Height + (ShadowSpread + ShadowBlur) * 2;
			if (redraw)
			{
				ShadowBitmap = DrawShadowBitmap(base.Owner.Width, base.Owner.Height, 0, ShadowBlur, ShadowSpread, ShadowColor);
			}
			UpdateLocation();
			Region r = Region.FromHrgn(Win32.CreateRoundRectRgn(0, 0, Width, Height, ShadowRadius, ShadowRadius));
			Region ownerRegion = base.Owner.Region?.Clone() ?? new Region(base.Owner.ClientRectangle);
			ownerRegion.Translate(-OffsetX, -OffsetY);
			r.Exclude(ownerRegion);
			base.Region = r;
			base.Owner.Refresh();
		}
	}

	public void SetBitmap(Bitmap bitmap, byte opacity = byte.MaxValue)
	{
		if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
		{
			throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
		}
		IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
		IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
		IntPtr hBitmap = IntPtr.Zero;
		IntPtr oldBitmap = IntPtr.Zero;
		try
		{
			hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
			oldBitmap = Win32.SelectObject(memDc, hBitmap);
			Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
			Win32.Point pointSource = new Win32.Point(0, 0);
			Win32.Point topPos = new Win32.Point(base.Left, base.Top);
			Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION
			{
				BlendOp = 0,
				BlendFlags = 0,
				SourceConstantAlpha = opacity,
				AlphaFormat = 1
			};
			Win32.UpdateLayeredWindow(base.Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, 2);
		}
		finally
		{
			Win32.ReleaseDC(IntPtr.Zero, screenDc);
			if (hBitmap != IntPtr.Zero)
			{
				Win32.SelectObject(memDc, oldBitmap);
				Win32.DeleteObject(hBitmap);
			}
			Win32.DeleteDC(memDc);
		}
	}

	public static Bitmap DrawShadowBitmap(int width, int height, int borderRadius, int blur, int spread, Color color)
	{
		int ex = blur + spread;
		int w = width + ex * 2;
		int h = height + ex * 2;
		int solidW = width + spread * 2;
		int solidH = height + spread * 2;
		Bitmap bitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);
		using (Graphics g = Graphics.FromImage(bitmap))
		{
			using SolidBrush solidBrush = new SolidBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.FillRectangle(solidBrush, blur, blur, solidW, solidH);
			if (blur > 0)
			{
				using (LinearGradientBrush leftBrush = new LinearGradientBrush(new Point(0, blur), new Point(blur, blur), Color.Transparent, color))
				{
					g.FillRectangle(leftBrush, 0, blur, blur, solidH);
				}
				using (LinearGradientBrush topBrush = new LinearGradientBrush(new Point(blur, 0), new Point(blur, blur), Color.Transparent, color))
				{
					g.FillRectangle(topBrush, blur, 0, solidW, blur);
				}
				using (LinearGradientBrush rightBrush = new LinearGradientBrush(new Point(w - blur, blur), new Point(w, blur), color, Color.Transparent))
				{
					g.FillRectangle(rightBrush, w - blur, blur, blur, solidH);
				}
				using (LinearGradientBrush bottomBrush = new LinearGradientBrush(new Point(blur, h - blur), new Point(blur, h), color, Color.Transparent))
				{
					g.FillRectangle(bottomBrush, blur, h - blur, solidW, blur);
				}
				DrawBlurredCorners(g, blur, w, h, color);
			}
		}
		return bitmap;
	}

	private static void DrawBlurredCorners(Graphics g, int blur, int totalW, int totalH, Color color)
	{
		using (GraphicsPath topLeftPath = new GraphicsPath())
		{
			topLeftPath.AddEllipse(0, 0, blur * 2, blur * 2);
			using PathGradientBrush topLeftBrush = new PathGradientBrush(topLeftPath);
			topLeftBrush.CenterColor = color;
			topLeftBrush.SurroundColors = new Color[1] { Color.Transparent };
			g.FillPie(topLeftBrush, 0, 0, blur * 2, blur * 2, 180, 90);
		}
		using (GraphicsPath topRightPath = new GraphicsPath())
		{
			topRightPath.AddEllipse(totalW - blur * 2, 0, blur * 2, blur * 2);
			using PathGradientBrush topRightBrush = new PathGradientBrush(topRightPath);
			topRightBrush.CenterColor = color;
			topRightBrush.SurroundColors = new Color[1] { Color.Transparent };
			g.FillPie(topRightBrush, totalW - blur * 2, 0, blur * 2, blur * 2, 270, 90);
		}
		using (GraphicsPath bottomRightPath = new GraphicsPath())
		{
			bottomRightPath.AddEllipse(totalW - blur * 2, totalH - blur * 2, blur * 2, blur * 2);
			using PathGradientBrush bottomRightBrush = new PathGradientBrush(bottomRightPath);
			bottomRightBrush.CenterColor = color;
			bottomRightBrush.SurroundColors = new Color[1] { Color.Transparent };
			g.FillPie(bottomRightBrush, totalW - blur * 2, totalH - blur * 2, blur * 2, blur * 2, 0, 90);
		}
		using GraphicsPath bottomLeftPath = new GraphicsPath();
		bottomLeftPath.AddEllipse(0, totalH - blur * 2, blur * 2, blur * 2);
		using PathGradientBrush bottomLeftBrush = new PathGradientBrush(bottomLeftPath);
		bottomLeftBrush.CenterColor = color;
		bottomLeftBrush.SurroundColors = new Color[1] { Color.Transparent };
		g.FillPie(bottomLeftBrush, 0, totalH - blur * 2, blur * 2, blur * 2, 90, 90);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		RefreshShadow();
	}

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Dropshadow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Dropshadow";
            this.Load += new System.EventHandler(this.Dropshadow_Load);
            this.ResumeLayout(false);

    }

    private void Dropshadow_Load(object sender, EventArgs e)
    {

    }
}
