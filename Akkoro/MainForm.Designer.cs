namespace Akkoro
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.uiBackground = new System.Windows.Forms.Panel();
            this.uiInnerBackdrop = new System.Windows.Forms.Panel();
            this.uiHeader = new System.Windows.Forms.Panel();
            this.uiHeaderDivide = new System.Windows.Forms.Panel();
            this.uiLogo = new System.Windows.Forms.PictureBox();
            this.uiBackground.SuspendLayout();
            this.uiInnerBackdrop.SuspendLayout();
            this.uiHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.Filter = "Lua Scripts|*.lua";
            // 
            // uiBackground
            // 
            this.uiBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(82)))), ((int)(((byte)(105)))));
            this.uiBackground.Controls.Add(this.uiInnerBackdrop);
            this.uiBackground.Location = new System.Drawing.Point(1, 1);
            this.uiBackground.Margin = new System.Windows.Forms.Padding(0);
            this.uiBackground.Name = "uiBackground";
            this.uiBackground.Size = new System.Drawing.Size(608, 540);
            this.uiBackground.TabIndex = 0;
            // 
            // uiInnerBackdrop
            // 
            this.uiInnerBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiInnerBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.uiInnerBackdrop.Controls.Add(this.uiHeader);
            this.uiInnerBackdrop.Location = new System.Drawing.Point(1, 1);
            this.uiInnerBackdrop.Margin = new System.Windows.Forms.Padding(0);
            this.uiInnerBackdrop.Name = "uiInnerBackdrop";
            this.uiInnerBackdrop.Size = new System.Drawing.Size(606, 538);
            this.uiInnerBackdrop.TabIndex = 0;
            this.uiInnerBackdrop.Paint += new System.Windows.Forms.PaintEventHandler(this.uiInnerBackdrop_Paint);
            // 
            // uiHeader
            // 
            this.uiHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(41)))), ((int)(((byte)(69)))));
            this.uiHeader.Controls.Add(this.uiLogo);
            this.uiHeader.Controls.Add(this.uiHeaderDivide);
            this.uiHeader.Location = new System.Drawing.Point(0, 0);
            this.uiHeader.Margin = new System.Windows.Forms.Padding(0);
            this.uiHeader.Name = "uiHeader";
            this.uiHeader.Size = new System.Drawing.Size(606, 81);
            this.uiHeader.TabIndex = 0;
            // 
            // uiHeaderDivide
            // 
            this.uiHeaderDivide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHeaderDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(82)))), ((int)(((byte)(105)))));
            this.uiHeaderDivide.Location = new System.Drawing.Point(-1, 80);
            this.uiHeaderDivide.Name = "uiHeaderDivide";
            this.uiHeaderDivide.Size = new System.Drawing.Size(607, 1);
            this.uiHeaderDivide.TabIndex = 1;
            // 
            // uiLogo
            // 
            this.uiLogo.Image = global::Akkoro.Properties.Resources.akkoro_header;
            this.uiLogo.Location = new System.Drawing.Point(0, 0);
            this.uiLogo.Name = "uiLogo";
            this.uiLogo.Size = new System.Drawing.Size(161, 80);
            this.uiLogo.TabIndex = 2;
            this.uiLogo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(610, 542);
            this.Controls.Add(this.uiBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Akkoro";
            this.uiBackground.ResumeLayout(false);
            this.uiInnerBackdrop.ResumeLayout(false);
            this.uiHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.Panel uiBackground;
        private System.Windows.Forms.Panel uiInnerBackdrop;
        private System.Windows.Forms.Panel uiHeader;
        private System.Windows.Forms.Panel uiHeaderDivide;
        private System.Windows.Forms.PictureBox uiLogo;
    }
}

