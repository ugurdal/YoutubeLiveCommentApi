namespace derinYouTube
{
    partial class frmGetChats
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVideoId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLiveChatId = new System.Windows.Forms.TextBox();
            this.pbWorking = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxChatCount = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.textBoxPollingIntervalMillis = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxChatCountInPackage = new System.Windows.Forms.TextBox();
            this.textBoxRequestCount = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxServiceNo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxLastChatTime = new System.Windows.Forms.TextBox();
            this.textBoxFirstChatTime = new System.Windows.Forms.TextBox();
            this.buttonGetChats = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timerViewerCount = new System.Windows.Forms.Timer(this.components);
            this.labelShowError = new System.Windows.Forms.Label();
            this.timerException = new System.Windows.Forms.Timer(this.components);
            this.timerChatCount = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video Id";
            // 
            // textBoxVideoId
            // 
            this.textBoxVideoId.Location = new System.Drawing.Point(109, 18);
            this.textBoxVideoId.Name = "textBoxVideoId";
            this.textBoxVideoId.Size = new System.Drawing.Size(234, 22);
            this.textBoxVideoId.TabIndex = 1;
            this.textBoxVideoId.TextChanged += new System.EventHandler(this.TextBoxVideoId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Live Chat Id";
            // 
            // textBoxLiveChatId
            // 
            this.textBoxLiveChatId.Location = new System.Drawing.Point(109, 46);
            this.textBoxLiveChatId.Name = "textBoxLiveChatId";
            this.textBoxLiveChatId.Size = new System.Drawing.Size(234, 22);
            this.textBoxLiveChatId.TabIndex = 3;
            this.textBoxLiveChatId.TextChanged += new System.EventHandler(this.TextBoxLiveChatId_TextChanged);
            // 
            // pbWorking
            // 
            this.pbWorking.Image = global::derinYouTube.Properties.Resources.ajax_loader;
            this.pbWorking.Location = new System.Drawing.Point(327, 77);
            this.pbWorking.Name = "pbWorking";
            this.pbWorking.Size = new System.Drawing.Size(16, 16);
            this.pbWorking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWorking.TabIndex = 29;
            this.pbWorking.TabStop = false;
            this.pbWorking.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Chat Sayısı";
            // 
            // textBoxChatCount
            // 
            this.textBoxChatCount.Location = new System.Drawing.Point(109, 74);
            this.textBoxChatCount.Name = "textBoxChatCount";
            this.textBoxChatCount.ReadOnly = true;
            this.textBoxChatCount.Size = new System.Drawing.Size(98, 22);
            this.textBoxChatCount.TabIndex = 31;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 254);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 30);
            this.label31.TabIndex = 45;
            this.label31.Text = "Polling Interval Millis";
            // 
            // textBoxPollingIntervalMillis
            // 
            this.textBoxPollingIntervalMillis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPollingIntervalMillis.Location = new System.Drawing.Point(109, 256);
            this.textBoxPollingIntervalMillis.Name = "textBoxPollingIntervalMillis";
            this.textBoxPollingIntervalMillis.ReadOnly = true;
            this.textBoxPollingIntervalMillis.Size = new System.Drawing.Size(98, 22);
            this.textBoxPollingIntervalMillis.TabIndex = 44;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label24.Location = new System.Drawing.Point(12, 225);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 28);
            this.label24.TabIndex = 41;
            this.label24.Text = "Paketteki Yorum Sayısı";
            // 
            // textBoxChatCountInPackage
            // 
            this.textBoxChatCountInPackage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxChatCountInPackage.Location = new System.Drawing.Point(109, 228);
            this.textBoxChatCountInPackage.Name = "textBoxChatCountInPackage";
            this.textBoxChatCountInPackage.ReadOnly = true;
            this.textBoxChatCountInPackage.Size = new System.Drawing.Size(98, 22);
            this.textBoxChatCountInPackage.TabIndex = 40;
            // 
            // textBoxRequestCount
            // 
            this.textBoxRequestCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxRequestCount.Location = new System.Drawing.Point(109, 116);
            this.textBoxRequestCount.Name = "textBoxRequestCount";
            this.textBoxRequestCount.ReadOnly = true;
            this.textBoxRequestCount.Size = new System.Drawing.Size(98, 22);
            this.textBoxRequestCount.TabIndex = 39;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label23.Location = new System.Drawing.Point(12, 119);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "İstek Sayısı";
            // 
            // textBoxServiceNo
            // 
            this.textBoxServiceNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxServiceNo.Location = new System.Drawing.Point(109, 144);
            this.textBoxServiceNo.Name = "textBoxServiceNo";
            this.textBoxServiceNo.ReadOnly = true;
            this.textBoxServiceNo.Size = new System.Drawing.Size(98, 22);
            this.textBoxServiceNo.TabIndex = 37;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(12, 147);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 13);
            this.label22.TabIndex = 36;
            this.label22.Text = "Servis No";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(12, 206);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Son Yorum Tarihi";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(12, 179);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "İlk Yorum Tarihi";
            // 
            // textBoxLastChatTime
            // 
            this.textBoxLastChatTime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLastChatTime.Location = new System.Drawing.Point(109, 200);
            this.textBoxLastChatTime.Name = "textBoxLastChatTime";
            this.textBoxLastChatTime.ReadOnly = true;
            this.textBoxLastChatTime.Size = new System.Drawing.Size(131, 22);
            this.textBoxLastChatTime.TabIndex = 33;
            // 
            // textBoxFirstChatTime
            // 
            this.textBoxFirstChatTime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFirstChatTime.Location = new System.Drawing.Point(109, 172);
            this.textBoxFirstChatTime.Name = "textBoxFirstChatTime";
            this.textBoxFirstChatTime.ReadOnly = true;
            this.textBoxFirstChatTime.Size = new System.Drawing.Size(131, 22);
            this.textBoxFirstChatTime.TabIndex = 32;
            // 
            // buttonGetChats
            // 
            this.buttonGetChats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGetChats.Image = global::derinYouTube.Properties.Resources.FormRunHS;
            this.buttonGetChats.Location = new System.Drawing.Point(109, 290);
            this.buttonGetChats.Name = "buttonGetChats";
            this.buttonGetChats.Size = new System.Drawing.Size(173, 52);
            this.buttonGetChats.TabIndex = 46;
            this.buttonGetChats.Text = "Servisi Başlat";
            this.buttonGetChats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonGetChats.UseVisualStyleBackColor = false;
            this.buttonGetChats.Click += new System.EventHandler(this.ButtonGetChats_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStop.Image = global::derinYouTube.Properties.Resources.StopHS;
            this.buttonStop.Location = new System.Drawing.Point(288, 290);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(55, 53);
            this.buttonStop.TabIndex = 47;
            this.buttonStop.Text = "Servisi Durdur";
            this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // timerViewerCount
            // 
            this.timerViewerCount.Enabled = true;
            this.timerViewerCount.Interval = 60000;
            this.timerViewerCount.Tick += new System.EventHandler(this.TimerViewerCount_Tick);
            // 
            // labelShowError
            // 
            this.labelShowError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelShowError.BackColor = System.Drawing.Color.DarkRed;
            this.labelShowError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelShowError.ForeColor = System.Drawing.SystemColors.Window;
            this.labelShowError.Location = new System.Drawing.Point(2, 348);
            this.labelShowError.Name = "labelShowError";
            this.labelShowError.Size = new System.Drawing.Size(393, 105);
            this.labelShowError.TabIndex = 48;
            this.labelShowError.Visible = false;
            // 
            // timerException
            // 
            this.timerException.Enabled = true;
            this.timerException.Interval = 5000;
            this.timerException.Tick += new System.EventHandler(this.TimerException_Tick);
            // 
            // timerChatCount
            // 
            this.timerChatCount.Enabled = true;
            this.timerChatCount.Interval = 5000;
            this.timerChatCount.Tick += new System.EventHandler(this.TimerChatCount_Tick);
            // 
            // frmGetChats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 459);
            this.Controls.Add(this.labelShowError);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonGetChats);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.textBoxPollingIntervalMillis);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBoxChatCountInPackage);
            this.Controls.Add(this.textBoxRequestCount);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBoxServiceNo);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxLastChatTime);
            this.Controls.Add(this.textBoxFirstChatTime);
            this.Controls.Add(this.textBoxChatCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbWorking);
            this.Controls.Add(this.textBoxLiveChatId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxVideoId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGetChats";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGetChats_FormClosing);
            this.Load += new System.EventHandler(this.FrmGetChats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVideoId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLiveChatId;
        private System.Windows.Forms.PictureBox pbWorking;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxChatCount;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBoxPollingIntervalMillis;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxChatCountInPackage;
        private System.Windows.Forms.TextBox textBoxRequestCount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxServiceNo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxLastChatTime;
        private System.Windows.Forms.TextBox textBoxFirstChatTime;
        private System.Windows.Forms.Button buttonGetChats;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timerViewerCount;
        private System.Windows.Forms.Label labelShowError;
        private System.Windows.Forms.Timer timerException;
        private System.Windows.Forms.Timer timerChatCount;
    }
}