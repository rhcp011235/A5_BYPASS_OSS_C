using System;

namespace SpiderPRO
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ActivateButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.LabelMessage = new System.Windows.Forms.Label();
            this.LabelNameApp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.5D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ActivateButton
            // 
            this.ActivateButton.Animated = true;
            this.ActivateButton.BackColor = System.Drawing.Color.Transparent;
            this.ActivateButton.BorderColor = System.Drawing.Color.Transparent;
            this.ActivateButton.BorderRadius = 3;
            this.ActivateButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.ActivateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ActivateButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ActivateButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ActivateButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ActivateButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ActivateButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ActivateButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.ActivateButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(210)))));
            this.ActivateButton.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.ActivateButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.ActivateButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.ActivateButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ActivateButton.ImageSize = new System.Drawing.Size(25, 25);
            this.ActivateButton.IndicateFocus = true;
            this.ActivateButton.Location = new System.Drawing.Point(24, 260);
            this.ActivateButton.Name = "ActivateButton";
            this.ActivateButton.PressedColor = System.Drawing.Color.Transparent;
            this.ActivateButton.ShadowDecoration.BorderRadius = 4;
            this.ActivateButton.ShadowDecoration.Depth = 6;
            this.ActivateButton.ShadowDecoration.Enabled = true;
            this.ActivateButton.Size = new System.Drawing.Size(281, 30);
            this.ActivateButton.TabIndex = 826;
            this.ActivateButton.Text = "OK";
            this.ActivateButton.UseTransparentBackground = true;
            this.ActivateButton.Click += new System.EventHandler(this.ActivateButton_Click);
            // 
            // LabelMessage
            // 
            this.LabelMessage.BackColor = System.Drawing.Color.Transparent;
            this.LabelMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelMessage.Font = new System.Drawing.Font("Ebrima", 9.818182F);
            this.LabelMessage.ForeColor = System.Drawing.Color.White;
            this.LabelMessage.Location = new System.Drawing.Point(20, 145);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(285, 103);
            this.LabelMessage.TabIndex = 825;
            this.LabelMessage.Text = "LabelMessage\r\n";
            this.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelNameApp
            // 
            this.LabelNameApp.BackColor = System.Drawing.Color.Transparent;
            this.LabelNameApp.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelNameApp.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameApp.ForeColor = System.Drawing.Color.White;
            this.LabelNameApp.Location = new System.Drawing.Point(9, 117);
            this.LabelNameApp.Name = "LabelNameApp";
            this.LabelNameApp.Size = new System.Drawing.Size(309, 19);
            this.LabelNameApp.TabIndex = 823;
            this.LabelNameApp.Text = "LabelNameApp";
            this.LabelNameApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(125, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 824;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(330, 308);
            this.Controls.Add(this.ActivateButton);
            this.Controls.Add(this.LabelMessage);
            this.Controls.Add(this.LabelNameApp);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        internal Guna.UI2.WinForms.Guna2GradientButton ActivateButton;
        private System.Windows.Forms.Label LabelMessage;
        private System.Windows.Forms.Label LabelNameApp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}