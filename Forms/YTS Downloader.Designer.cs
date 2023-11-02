namespace YifyFileDownloader.Forms
{
    partial class YTS_Downloader
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
            btnDownload = new Button();
            pnlMenuStrip = new Panel();
            btnClose = new Button();
            btnMinimize = new Button();
            rtbStatus = new RichTextBox();
            pnlMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.White;
            btnDownload.FlatAppearance.BorderColor = Color.White;
            btnDownload.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnDownload.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDownload.Location = new Point(325, 100);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(150, 60);
            btnDownload.TabIndex = 1;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // pnlMenuStrip
            // 
            pnlMenuStrip.BackColor = Color.White;
            pnlMenuStrip.Controls.Add(btnClose);
            pnlMenuStrip.Controls.Add(btnMinimize);
            pnlMenuStrip.Location = new Point(0, 0);
            pnlMenuStrip.Name = "pnlMenuStrip";
            pnlMenuStrip.Size = new Size(800, 40);
            pnlMenuStrip.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.CloseIcon;
            btnClose.Location = new Point(740, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.White;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Image = Properties.Resources.MinimizeIcon;
            btnMinimize.Location = new Point(694, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "__";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // rtbStatus
            // 
            rtbStatus.Location = new Point(20, 220);
            rtbStatus.Name = "rtbStatus";
            rtbStatus.Size = new Size(760, 260);
            rtbStatus.TabIndex = 5;
            rtbStatus.Text = "";
            // 
            // YTS_Downloader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 12, 48);
            ClientSize = new Size(800, 500);
            Controls.Add(rtbStatus);
            Controls.Add(pnlMenuStrip);
            Controls.Add(btnDownload);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(0, 30);
            MaximizeBox = false;
            Name = "YTS_Downloader";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YTS_Downloader";
            MouseDown += YTS_Downloader_MouseDown;
            MouseMove += YTS_Downloader_MouseMove;
            MouseUp += YTS_Downloader_MouseUp;
            pnlMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnDownload;
        private Panel pnlMenuStrip;
        private RichTextBox rtbStatus;
        private Button btnClose;
        private Button btnMinimize;
    }
}