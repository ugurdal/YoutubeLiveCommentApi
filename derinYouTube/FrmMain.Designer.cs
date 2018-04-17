namespace derinYouTube
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.textBoxVideoId = new System.Windows.Forms.TextBox();
            this.buttonGetVideo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tabPageKanal = new System.Windows.Forms.TabPage();
            this.richTextBoxTitle = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabelChannelId = new System.Windows.Forms.LinkLabel();
            this.dtPublishDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxVideoId
            // 
            this.textBoxVideoId.Location = new System.Drawing.Point(82, 57);
            this.textBoxVideoId.Name = "textBoxVideoId";
            this.textBoxVideoId.Size = new System.Drawing.Size(260, 22);
            this.textBoxVideoId.TabIndex = 0;
            this.textBoxVideoId.Text = "8cNecDk6DMc";
            // 
            // buttonGetVideo
            // 
            this.buttonGetVideo.Location = new System.Drawing.Point(82, 95);
            this.buttonGetVideo.Name = "buttonGetVideo";
            this.buttonGetVideo.Size = new System.Drawing.Size(89, 23);
            this.buttonGetVideo.TabIndex = 1;
            this.buttonGetVideo.Text = "Get Video";
            this.buttonGetVideo.UseVisualStyleBackColor = true;
            this.buttonGetVideo.Click += new System.EventHandler(this.buttonGetVideo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "get playlists";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "get comments";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(232, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "FLij86fVGteEkVkL3cvzV1lg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Video ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Playlist ID";
            // 
            // dgw
            // 
            this.dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Location = new System.Drawing.Point(24, 140);
            this.dgw.Name = "dgw";
            this.dgw.Size = new System.Drawing.Size(639, 437);
            this.dgw.TabIndex = 7;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCount.Location = new System.Drawing.Point(371, 78);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(14, 13);
            this.labelCount.TabIndex = 8;
            this.labelCount.Text = "0";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTime.Location = new System.Drawing.Point(79, 17);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(13, 15);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(170, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "get live chat";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dgw);
            this.splitContainerMain.Panel2.Controls.Add(this.labelCount);
            this.splitContainerMain.Panel2.Controls.Add(this.button4);
            this.splitContainerMain.Panel2.Controls.Add(this.textBox2);
            this.splitContainerMain.Panel2.Controls.Add(this.button3);
            this.splitContainerMain.Panel2.Controls.Add(this.label2);
            this.splitContainerMain.Panel2.Controls.Add(this.button2);
            this.splitContainerMain.Size = new System.Drawing.Size(1117, 589);
            this.splitContainerMain.SplitterDistance = 360;
            this.splitContainerMain.SplitterWidth = 3;
            this.splitContainerMain.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVideo);
            this.tabControl1.Controls.Add(this.tabPageKanal);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(358, 587);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageVideo.Controls.Add(this.label6);
            this.tabPageVideo.Controls.Add(this.labelTime);
            this.tabPageVideo.Controls.Add(this.dtPublishDate);
            this.tabPageVideo.Controls.Add(this.linkLabelChannelId);
            this.tabPageVideo.Controls.Add(this.label5);
            this.tabPageVideo.Controls.Add(this.label4);
            this.tabPageVideo.Controls.Add(this.richTextBoxDescription);
            this.tabPageVideo.Controls.Add(this.label3);
            this.tabPageVideo.Controls.Add(this.richTextBoxTitle);
            this.tabPageVideo.Controls.Add(this.buttonClear);
            this.tabPageVideo.Controls.Add(this.label1);
            this.tabPageVideo.Controls.Add(this.textBoxVideoId);
            this.tabPageVideo.Controls.Add(this.buttonGetVideo);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(350, 561);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Video Details";
            // 
            // buttonClear
            // 
            this.buttonClear.AutoEllipsis = true;
            this.buttonClear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonClear.Location = new System.Drawing.Point(250, 95);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(92, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonTemizle_Click);
            // 
            // tabPageKanal
            // 
            this.tabPageKanal.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageKanal.Location = new System.Drawing.Point(4, 22);
            this.tabPageKanal.Name = "tabPageKanal";
            this.tabPageKanal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKanal.Size = new System.Drawing.Size(341, 561);
            this.tabPageKanal.TabIndex = 1;
            this.tabPageKanal.Text = "My Channel";
            // 
            // richTextBoxTitle
            // 
            this.richTextBoxTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTitle.Location = new System.Drawing.Point(82, 153);
            this.richTextBoxTitle.Name = "richTextBoxTitle";
            this.richTextBoxTitle.ReadOnly = true;
            this.richTextBoxTitle.Size = new System.Drawing.Size(260, 47);
            this.richTextBoxTitle.TabIndex = 7;
            this.richTextBoxTitle.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Title";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Location = new System.Drawing.Point(82, 206);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(260, 69);
            this.richTextBoxDescription.TabIndex = 9;
            this.richTextBoxDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Channel ID";
            // 
            // linkLabelChannelId
            // 
            this.linkLabelChannelId.AutoSize = true;
            this.linkLabelChannelId.Location = new System.Drawing.Point(79, 321);
            this.linkLabelChannelId.Name = "linkLabelChannelId";
            this.linkLabelChannelId.Size = new System.Drawing.Size(64, 13);
            this.linkLabelChannelId.TabIndex = 13;
            this.linkLabelChannelId.TabStop = true;
            this.linkLabelChannelId.Text = "Channel ID";
            this.linkLabelChannelId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelChannelId_LinkClicked);
            // 
            // dtPublishDate
            // 
            this.dtPublishDate.Enabled = false;
            this.dtPublishDate.Location = new System.Drawing.Point(82, 282);
            this.dtPublishDate.Name = "dtPublishDate";
            this.dtPublishDate.Size = new System.Drawing.Size(260, 22);
            this.dtPublishDate.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 34);
            this.label6.TabIndex = 15;
            this.label6.Text = "Published Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 589);
            this.Controls.Add(this.splitContainerMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouTube Chat & Comment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageVideo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxVideoId;
        private System.Windows.Forms.Button buttonGetVideo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TabPage tabPageKanal;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RichTextBox richTextBoxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabelChannelId;
        private System.Windows.Forms.DateTimePicker dtPublishDate;
        private System.Windows.Forms.Label label6;
    }
}