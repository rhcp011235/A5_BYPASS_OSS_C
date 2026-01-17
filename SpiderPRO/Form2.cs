using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpiderPRO
{
    public partial class Form2 : Form
    {
        // Сплошной цвет фона (Блюр сделает его прозрачным сам)
        private readonly Color _backColor = Color.FromArgb(30, 30, 32);
        private readonly Color _accentColor = Color.FromArgb(255, 45, 85);
        private readonly Color _textColor = Color.FromArgb(242, 242, 247);

        #region WinAPI & Structures
        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public int AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }
        #endregion

        public Form2(string nameApp, string message, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            InitializeComponent();

            // Настройки окна для отображения в трее/панели задач
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = _backColor;
            this.ShowInTaskbar = true; // Появляется внизу
            this.ShowIcon = true;
            this.TopMost = true;

            // Безопасная установка текста
            if (LabelNameApp != null) LabelNameApp.Text = nameApp.ToUpper();
            if (LabelMessage != null) LabelMessage.Text = message;

            LoadAppIcon(icon);
            ApplyModernTheme();
            SetupDragging();
        }

        private void LoadAppIcon(MessageBoxIcon icon)
        {
            if (pictureBox1 == null) return;

            try
            {
                // Пытаемся взять иконку из ресурсов проекта (Form1)
                var rm = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                Icon appIcon = (Icon)rm.GetObject("$this.Icon");

                if (appIcon != null)
                {
                    this.Icon = appIcon;
                    pictureBox1.Image = appIcon.ToBitmap();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                // Если не вышло, ставим стандартную системную
                if (icon == MessageBoxIcon.Error) pictureBox1.Image = SystemIcons.Error.ToBitmap();
                else pictureBox1.Image = SystemIcons.Information.ToBitmap();
            }
        }

        private void ApplyModernTheme()
        {
            if (LabelNameApp != null) LabelNameApp.ForeColor = _accentColor;
            if (LabelMessage != null) LabelMessage.ForeColor = _textColor;

            if (ActivateButton != null)
            {
                ActivateButton.FillColor = _accentColor;
                ActivateButton.BorderRadius = 12;
                ActivateButton.ForeColor = Color.White;
            }

            EnableBlur(this.Handle);
        }

        private void EnableBlur(IntPtr handle)
        {
            int accentStructSize = Marshal.SizeOf(typeof(AccentPolicy));
            AccentPolicy accent = new AccentPolicy
            {
                AccentState = 3, // ACCENT_ENABLE_BLURBEHIND
                GradientColor = 0x00FFFFFF
            };

            IntPtr accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData
            {
                Attribute = 19,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(handle, ref data);
            Marshal.FreeHGlobal(accentPtr);
        }

        private void SetupDragging()
        {
            this.MouseDown += (s, e) => { DoDrag(e); };
            if (LabelNameApp != null)
                LabelNameApp.MouseDown += (s, e) => { DoDrag(e); };
        }

        private void DoDrag(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        // Исправленная перегрузка Show (теперь принимает 3 аргумента)
        public static void Show(string title, string text, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            using (Form2 f = new Form2(title, text, icon))
            {
                f.ShowDialog();
            }
        }

        private void ActivateButton_Click(object sender, EventArgs e) => this.Close();

        // Рисуем рамку, чтобы окно не сливалось с фоном
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(60, 60, 62), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}