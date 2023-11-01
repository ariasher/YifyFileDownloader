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
            infoLabel = new Label();
            btnDownload = new Button();
            SuspendLayout();
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(39, 239);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(42, 20);
            infoLabel.TabIndex = 0;
            infoLabel.Text = "INFO";
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(288, 95);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(177, 56);
            btnDownload.TabIndex = 1;
            btnDownload.Text = "Start Downloading";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // YTS_Downloader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDownload);
            Controls.Add(infoLabel);
            Name = "YTS_Downloader";
            Text = "YTS_Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label infoLabel;
        private Button btnDownload;
    }
}