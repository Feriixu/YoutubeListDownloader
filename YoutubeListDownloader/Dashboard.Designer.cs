namespace YoutubeListDownloader
{
    partial class Dashboard
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxVideos = new System.Windows.Forms.ListBox();
            this.textBoxAdd = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonAdd = new MetroFramework.Controls.MetroButton();
            this.metroButtonClear = new MetroFramework.Controls.MetroButton();
            this.metroButtonImportList = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.metroButtonCancel = new MetroFramework.Controls.MetroButton();
            this.checkBoxDelete = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxConvert = new MetroFramework.Controls.MetroCheckBox();
            this.metroButtonStart = new MetroFramework.Controls.MetroButton();
            this.progressBarDownloads = new MetroFramework.Controls.MetroProgressBar();
            this.metroCheckBoxPlaylistMode = new MetroFramework.Controls.MetroCheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.listBoxVideos);
            this.groupBox1.Controls.Add(this.textBoxAdd);
            this.groupBox1.Controls.Add(this.metroButtonAdd);
            this.groupBox1.Controls.Add(this.metroButtonClear);
            this.groupBox1.Controls.Add(this.metroButtonImportList);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 426);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. List";
            // 
            // listBoxVideos
            // 
            this.listBoxVideos.FormattingEnabled = true;
            this.listBoxVideos.Location = new System.Drawing.Point(7, 77);
            this.listBoxVideos.Name = "listBoxVideos";
            this.listBoxVideos.Size = new System.Drawing.Size(338, 342);
            this.listBoxVideos.TabIndex = 8;
            // 
            // textBoxAdd
            // 
            // 
            // 
            // 
            this.textBoxAdd.CustomButton.Image = null;
            this.textBoxAdd.CustomButton.Location = new System.Drawing.Point(243, 1);
            this.textBoxAdd.CustomButton.Name = "";
            this.textBoxAdd.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxAdd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxAdd.CustomButton.TabIndex = 1;
            this.textBoxAdd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxAdd.CustomButton.UseSelectable = true;
            this.textBoxAdd.CustomButton.Visible = false;
            this.textBoxAdd.Lines = new string[0];
            this.textBoxAdd.Location = new System.Drawing.Point(7, 47);
            this.textBoxAdd.MaxLength = 32767;
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.PasswordChar = '\0';
            this.textBoxAdd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxAdd.SelectedText = "";
            this.textBoxAdd.SelectionLength = 0;
            this.textBoxAdd.SelectionStart = 0;
            this.textBoxAdd.ShortcutsEnabled = true;
            this.textBoxAdd.Size = new System.Drawing.Size(265, 23);
            this.textBoxAdd.Style = MetroFramework.MetroColorStyle.Red;
            this.textBoxAdd.TabIndex = 7;
            this.textBoxAdd.UseSelectable = true;
            this.textBoxAdd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxAdd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAdd_KeyDown_1);
            // 
            // metroButtonAdd
            // 
            this.metroButtonAdd.Location = new System.Drawing.Point(278, 47);
            this.metroButtonAdd.Name = "metroButtonAdd";
            this.metroButtonAdd.Size = new System.Drawing.Size(67, 23);
            this.metroButtonAdd.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButtonAdd.TabIndex = 6;
            this.metroButtonAdd.Text = "Add";
            this.metroButtonAdd.UseSelectable = true;
            this.metroButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // metroButtonClear
            // 
            this.metroButtonClear.Location = new System.Drawing.Point(242, 20);
            this.metroButtonClear.Name = "metroButtonClear";
            this.metroButtonClear.Size = new System.Drawing.Size(104, 23);
            this.metroButtonClear.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButtonClear.TabIndex = 5;
            this.metroButtonClear.Text = "Clear";
            this.metroButtonClear.UseSelectable = true;
            this.metroButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // metroButtonImportList
            // 
            this.metroButtonImportList.Location = new System.Drawing.Point(7, 20);
            this.metroButtonImportList.Name = "metroButtonImportList";
            this.metroButtonImportList.Size = new System.Drawing.Size(228, 23);
            this.metroButtonImportList.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButtonImportList.TabIndex = 4;
            this.metroButtonImportList.Text = "Import List";
            this.metroButtonImportList.UseSelectable = true;
            this.metroButtonImportList.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listBoxLog);
            this.groupBox2.Controls.Add(this.metroButtonCancel);
            this.groupBox2.Controls.Add(this.checkBoxDelete);
            this.groupBox2.Controls.Add(this.checkBoxConvert);
            this.groupBox2.Controls.Add(this.metroButtonStart);
            this.groupBox2.Location = new System.Drawing.Point(370, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 426);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Download";
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(6, 50);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(406, 368);
            this.listBoxLog.TabIndex = 8;
            // 
            // metroButtonCancel
            // 
            this.metroButtonCancel.Location = new System.Drawing.Point(282, 18);
            this.metroButtonCancel.Name = "metroButtonCancel";
            this.metroButtonCancel.Size = new System.Drawing.Size(130, 23);
            this.metroButtonCancel.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButtonCancel.TabIndex = 7;
            this.metroButtonCancel.Text = "Cancel";
            this.metroButtonCancel.UseSelectable = true;
            this.metroButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Enabled = false;
            this.checkBoxDelete.Location = new System.Drawing.Point(131, 29);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(144, 15);
            this.checkBoxDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.checkBoxDelete.TabIndex = 6;
            this.checkBoxDelete.Text = "Delete after conversion";
            this.checkBoxDelete.UseSelectable = true;
            // 
            // checkBoxConvert
            // 
            this.checkBoxConvert.AutoSize = true;
            this.checkBoxConvert.Location = new System.Drawing.Point(131, 10);
            this.checkBoxConvert.Name = "checkBoxConvert";
            this.checkBoxConvert.Size = new System.Drawing.Size(106, 15);
            this.checkBoxConvert.Style = MetroFramework.MetroColorStyle.Red;
            this.checkBoxConvert.TabIndex = 6;
            this.checkBoxConvert.Text = "Convert to mp3";
            this.checkBoxConvert.UseSelectable = true;
            this.checkBoxConvert.CheckedChanged += new System.EventHandler(this.CheckBoxConvert_CheckedChanged);
            // 
            // metroButtonStart
            // 
            this.metroButtonStart.Location = new System.Drawing.Point(6, 18);
            this.metroButtonStart.Name = "metroButtonStart";
            this.metroButtonStart.Size = new System.Drawing.Size(110, 23);
            this.metroButtonStart.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButtonStart.TabIndex = 5;
            this.metroButtonStart.Text = "Start";
            this.metroButtonStart.UseSelectable = true;
            this.metroButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // progressBarDownloads
            // 
            this.progressBarDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDownloads.Location = new System.Drawing.Point(12, 494);
            this.progressBarDownloads.Name = "progressBarDownloads";
            this.progressBarDownloads.Size = new System.Drawing.Size(776, 24);
            this.progressBarDownloads.Style = MetroFramework.MetroColorStyle.Red;
            this.progressBarDownloads.TabIndex = 9;
            // 
            // metroCheckBoxPlaylistMode
            // 
            this.metroCheckBoxPlaylistMode.AutoSize = true;
            this.metroCheckBoxPlaylistMode.Location = new System.Drawing.Point(501, 42);
            this.metroCheckBoxPlaylistMode.Name = "metroCheckBoxPlaylistMode";
            this.metroCheckBoxPlaylistMode.Size = new System.Drawing.Size(94, 15);
            this.metroCheckBoxPlaylistMode.Style = MetroFramework.MetroColorStyle.Red;
            this.metroCheckBoxPlaylistMode.TabIndex = 6;
            this.metroCheckBoxPlaylistMode.Text = "Playlist Mode";
            this.metroCheckBoxPlaylistMode.UseSelectable = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.progressBarDownloads);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.metroCheckBoxPlaylistMode);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Youtube List Downloader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroTextBox textBoxAdd;
        private MetroFramework.Controls.MetroButton metroButtonAdd;
        private MetroFramework.Controls.MetroButton metroButtonClear;
        private MetroFramework.Controls.MetroButton metroButtonImportList;
        private MetroFramework.Controls.MetroCheckBox checkBoxDelete;
        private MetroFramework.Controls.MetroCheckBox checkBoxConvert;
        private MetroFramework.Controls.MetroButton metroButtonStart;
        private MetroFramework.Controls.MetroButton metroButtonCancel;
        private MetroFramework.Controls.MetroProgressBar progressBarDownloads;
        private System.Windows.Forms.ListBox listBoxVideos;
        private System.Windows.Forms.ListBox listBoxLog;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxPlaylistMode;
    }
}

