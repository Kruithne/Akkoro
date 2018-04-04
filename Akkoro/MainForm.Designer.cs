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
            this.uiEmptyPrompt = new System.Windows.Forms.Label();
            this.uiFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.uiHeader = new System.Windows.Forms.Panel();
            this.uiOpenButton = new System.Windows.Forms.Button();
            this.uiMinimizeButton = new System.Windows.Forms.Button();
            this.uiCloseButton = new System.Windows.Forms.Button();
            this.uiLogo = new System.Windows.Forms.PictureBox();
            this.uiHeaderDivide = new System.Windows.Forms.Panel();
            this.uiKillTip = new System.Windows.Forms.Label();
            this.uiBackground.SuspendLayout();
            this.uiInnerBackdrop.SuspendLayout();
            this.uiHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.Filter = "Lua Scripts|*.lua";
            this.dialogOpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dialogOpenFile_FileOk);
            // 
            // uiBackground
            // 
            this.uiBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(82)))), ((int)(((byte)(105)))));
            this.uiBackground.Controls.Add(this.uiInnerBackdrop);
            this.uiBackground.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.uiBackground.Location = new System.Drawing.Point(1, 1);
            this.uiBackground.Margin = new System.Windows.Forms.Padding(0);
            this.uiBackground.Name = "uiBackground";
            this.uiBackground.Size = new System.Drawing.Size(726, 665);
            this.uiBackground.TabIndex = 0;
            // 
            // uiInnerBackdrop
            // 
            this.uiInnerBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiInnerBackdrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.uiInnerBackdrop.Controls.Add(this.uiEmptyPrompt);
            this.uiInnerBackdrop.Controls.Add(this.uiFlow);
            this.uiInnerBackdrop.Controls.Add(this.uiHeader);
            this.uiInnerBackdrop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.uiInnerBackdrop.Location = new System.Drawing.Point(1, 1);
            this.uiInnerBackdrop.Margin = new System.Windows.Forms.Padding(0);
            this.uiInnerBackdrop.Name = "uiInnerBackdrop";
            this.uiInnerBackdrop.Size = new System.Drawing.Size(724, 663);
            this.uiInnerBackdrop.TabIndex = 0;
            // 
            // uiEmptyPrompt
            // 
            this.uiEmptyPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEmptyPrompt.BackColor = System.Drawing.Color.Transparent;
            this.uiEmptyPrompt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiEmptyPrompt.ForeColor = System.Drawing.Color.White;
            this.uiEmptyPrompt.Location = new System.Drawing.Point(-1, 107);
            this.uiEmptyPrompt.Name = "uiEmptyPrompt";
            this.uiEmptyPrompt.Size = new System.Drawing.Size(726, 76);
            this.uiEmptyPrompt.TabIndex = 2;
            this.uiEmptyPrompt.Text = "You haven\'t loaded any scripts yet. Click the button in the top-right to do that." +
    "\r\nFor information on the API, check the GitHub project page!";
            this.uiEmptyPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiFlow
            // 
            this.uiFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uiFlow.Location = new System.Drawing.Point(21, 98);
            this.uiFlow.Margin = new System.Windows.Forms.Padding(14);
            this.uiFlow.Name = "uiFlow";
            this.uiFlow.Size = new System.Drawing.Size(689, 544);
            this.uiFlow.TabIndex = 1;
            // 
            // uiHeader
            // 
            this.uiHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(41)))), ((int)(((byte)(69)))));
            this.uiHeader.Controls.Add(this.uiKillTip);
            this.uiHeader.Controls.Add(this.uiOpenButton);
            this.uiHeader.Controls.Add(this.uiMinimizeButton);
            this.uiHeader.Controls.Add(this.uiCloseButton);
            this.uiHeader.Controls.Add(this.uiLogo);
            this.uiHeader.Controls.Add(this.uiHeaderDivide);
            this.uiHeader.Location = new System.Drawing.Point(0, 0);
            this.uiHeader.Margin = new System.Windows.Forms.Padding(0);
            this.uiHeader.Name = "uiHeader";
            this.uiHeader.Size = new System.Drawing.Size(724, 81);
            this.uiHeader.TabIndex = 0;
            this.uiHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiHeader_MouseDown);
            this.uiHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiHeader_MouseMove);
            this.uiHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiHeader_MouseUp);
            // 
            // uiOpenButton
            // 
            this.uiOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOpenButton.BackgroundImage = global::Akkoro.Properties.Resources.button_open;
            this.uiOpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uiOpenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiOpenButton.FlatAppearance.BorderSize = 0;
            this.uiOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiOpenButton.Location = new System.Drawing.Point(686, 39);
            this.uiOpenButton.Name = "uiOpenButton";
            this.uiOpenButton.Size = new System.Drawing.Size(31, 34);
            this.uiOpenButton.TabIndex = 5;
            this.uiOpenButton.UseVisualStyleBackColor = true;
            this.uiOpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiMinimizeButton
            // 
            this.uiMinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiMinimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiMinimizeButton.BackgroundImage")));
            this.uiMinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiMinimizeButton.FlatAppearance.BorderSize = 0;
            this.uiMinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiMinimizeButton.Location = new System.Drawing.Point(684, 10);
            this.uiMinimizeButton.Name = "uiMinimizeButton";
            this.uiMinimizeButton.Size = new System.Drawing.Size(11, 11);
            this.uiMinimizeButton.TabIndex = 4;
            this.uiMinimizeButton.UseVisualStyleBackColor = true;
            this.uiMinimizeButton.Click += new System.EventHandler(this.uiMinimizeButton_Click);
            // 
            // uiCloseButton
            // 
            this.uiCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiCloseButton.BackgroundImage")));
            this.uiCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCloseButton.FlatAppearance.BorderSize = 0;
            this.uiCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiCloseButton.Location = new System.Drawing.Point(703, 10);
            this.uiCloseButton.Name = "uiCloseButton";
            this.uiCloseButton.Size = new System.Drawing.Size(11, 11);
            this.uiCloseButton.TabIndex = 3;
            this.uiCloseButton.UseVisualStyleBackColor = true;
            this.uiCloseButton.Click += new System.EventHandler(this.uiCloseButton_Click);
            // 
            // uiLogo
            // 
            this.uiLogo.Image = ((System.Drawing.Image)(resources.GetObject("uiLogo.Image")));
            this.uiLogo.Location = new System.Drawing.Point(0, 0);
            this.uiLogo.Name = "uiLogo";
            this.uiLogo.Size = new System.Drawing.Size(161, 80);
            this.uiLogo.TabIndex = 2;
            this.uiLogo.TabStop = false;
            this.uiLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiHeader_MouseDown);
            this.uiLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiHeader_MouseMove);
            this.uiLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiHeader_MouseUp);
            // 
            // uiHeaderDivide
            // 
            this.uiHeaderDivide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHeaderDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(82)))), ((int)(((byte)(105)))));
            this.uiHeaderDivide.Location = new System.Drawing.Point(-1, 80);
            this.uiHeaderDivide.Name = "uiHeaderDivide";
            this.uiHeaderDivide.Size = new System.Drawing.Size(725, 1);
            this.uiHeaderDivide.TabIndex = 1;
            // 
            // uiKillTip
            // 
            this.uiKillTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiKillTip.BackColor = System.Drawing.Color.Transparent;
            this.uiKillTip.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiKillTip.ForeColor = System.Drawing.Color.White;
            this.uiKillTip.Location = new System.Drawing.Point(262, 41);
            this.uiKillTip.Name = "uiKillTip";
            this.uiKillTip.Size = new System.Drawing.Size(425, 39);
            this.uiKillTip.TabIndex = 2;
            this.uiKillTip.Text = "Tip: Pressing F1 twice in quick succession will terminate all scripts";
            this.uiKillTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(728, 667);
            this.Controls.Add(this.uiBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Akkoro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
        private System.Windows.Forms.Button uiCloseButton;
        private System.Windows.Forms.Button uiMinimizeButton;
        private System.Windows.Forms.FlowLayoutPanel uiFlow;
        private System.Windows.Forms.Button uiOpenButton;
        private System.Windows.Forms.Label uiEmptyPrompt;
        private System.Windows.Forms.Label uiKillTip;
    }
}

