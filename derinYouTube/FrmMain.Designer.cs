﻿namespace derinYouTube
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.MessageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsVerified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsChatOwner = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsChatSponsor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsChatModerator = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.labelCount = new System.Windows.Forms.Label();
            this.splitContainerDikey = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.textBoxLiveChatId = new System.Windows.Forms.RichTextBox();
            this.textBoxVideoId = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pbWorking = new System.Windows.Forms.PictureBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonAsync = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxEndTime = new System.Windows.Forms.RichTextBox();
            this.richTextBoxStartTime = new System.Windows.Forms.RichTextBox();
            this.richTextBoxPuslishedAt = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabelChannelId = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxTitle = new System.Windows.Forms.RichTextBox();
            this.splitContainerYatay = new System.Windows.Forms.SplitContainer();
            this.checkBoxLiveOnly = new System.Windows.Forms.CheckBox();
            this.buttonGetLiveBroadCasts = new System.Windows.Forms.Button();
            this.dgwLiveVideos = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearAnswers = new System.Windows.Forms.Button();
            this.dgwCevap = new System.Windows.Forms.DataGridView();
            this.buttonFindWinner = new System.Windows.Forms.Button();
            this.textBoxStopAt = new System.Windows.Forms.TextBox();
            this.textBoxStartAt = new System.Windows.Forms.TextBox();
            this.buttonCampStop = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonCampStart = new System.Windows.Forms.Button();
            this.richTextBoxScheduledStartTime = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LiveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LiveChatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduledStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDikey)).BeginInit();
            this.splitContainerDikey.Panel1.SuspendLayout();
            this.splitContainerDikey.Panel2.SuspendLayout();
            this.splitContainerDikey.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerYatay)).BeginInit();
            this.splitContainerYatay.Panel1.SuspendLayout();
            this.splitContainerYatay.Panel2.SuspendLayout();
            this.splitContainerYatay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLiveVideos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCevap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Video ID";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgw.ColumnHeadersHeight = 40;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MessageId,
            this.PublishedAt,
            this.DisplayMessage,
            this.DisplayName,
            this.ChannelUrl,
            this.IsVerified,
            this.IsChatOwner,
            this.IsChatSponsor,
            this.IsChatModerator});
            this.dgw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw.Location = new System.Drawing.Point(0, 0);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.Size = new System.Drawing.Size(570, 392);
            this.dgw.TabIndex = 7;
            this.dgw.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgw_RowsAdded);
            // 
            // MessageId
            // 
            this.MessageId.DataPropertyName = "MessageId";
            this.MessageId.HeaderText = "Messega Id";
            this.MessageId.Name = "MessageId";
            this.MessageId.ReadOnly = true;
            this.MessageId.Visible = false;
            // 
            // PublishedAt
            // 
            this.PublishedAt.DataPropertyName = "PublishedAt";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PublishedAt.DefaultCellStyle = dataGridViewCellStyle1;
            this.PublishedAt.FillWeight = 15F;
            this.PublishedAt.HeaderText = "Published At";
            this.PublishedAt.Name = "PublishedAt";
            this.PublishedAt.ReadOnly = true;
            // 
            // DisplayMessage
            // 
            this.DisplayMessage.DataPropertyName = "DisplayMessage";
            this.DisplayMessage.FillWeight = 50F;
            this.DisplayMessage.HeaderText = "Message";
            this.DisplayMessage.Name = "DisplayMessage";
            this.DisplayMessage.ReadOnly = true;
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.FillWeight = 20F;
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.ReadOnly = true;
            // 
            // ChannelUrl
            // 
            this.ChannelUrl.DataPropertyName = "ChannelUrl";
            this.ChannelUrl.FillWeight = 15F;
            this.ChannelUrl.HeaderText = "Channel Url";
            this.ChannelUrl.Name = "ChannelUrl";
            this.ChannelUrl.ReadOnly = true;
            this.ChannelUrl.Visible = false;
            // 
            // IsVerified
            // 
            this.IsVerified.DataPropertyName = "IsVerified";
            this.IsVerified.HeaderText = "IsVerified";
            this.IsVerified.Name = "IsVerified";
            this.IsVerified.ReadOnly = true;
            this.IsVerified.Visible = false;
            // 
            // IsChatOwner
            // 
            this.IsChatOwner.DataPropertyName = "IsChatOwner";
            this.IsChatOwner.HeaderText = "IsChatOwner";
            this.IsChatOwner.Name = "IsChatOwner";
            this.IsChatOwner.ReadOnly = true;
            this.IsChatOwner.Visible = false;
            // 
            // IsChatSponsor
            // 
            this.IsChatSponsor.DataPropertyName = "IsChatSponsor";
            this.IsChatSponsor.FillWeight = 5F;
            this.IsChatSponsor.HeaderText = "Is Sponsor";
            this.IsChatSponsor.Name = "IsChatSponsor";
            this.IsChatSponsor.ReadOnly = true;
            this.IsChatSponsor.Visible = false;
            // 
            // IsChatModerator
            // 
            this.IsChatModerator.DataPropertyName = "IsChatModerator";
            this.IsChatModerator.FillWeight = 5F;
            this.IsChatModerator.HeaderText = "Is Moderator";
            this.IsChatModerator.Name = "IsChatModerator";
            this.IsChatModerator.ReadOnly = true;
            this.IsChatModerator.Visible = false;
            // 
            // labelCount
            // 
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCount.Location = new System.Drawing.Point(79, 396);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(159, 13);
            this.labelCount.TabIndex = 8;
            this.labelCount.Text = "0";
            // 
            // splitContainerDikey
            // 
            this.splitContainerDikey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerDikey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDikey.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDikey.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDikey.Name = "splitContainerDikey";
            // 
            // splitContainerDikey.Panel1
            // 
            this.splitContainerDikey.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerDikey.Panel2
            // 
            this.splitContainerDikey.Panel2.Controls.Add(this.splitContainerYatay);
            this.splitContainerDikey.Size = new System.Drawing.Size(1117, 589);
            this.splitContainerDikey.SplitterDistance = 262;
            this.splitContainerDikey.SplitterWidth = 3;
            this.splitContainerDikey.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVideo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 587);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageVideo.Controls.Add(this.label10);
            this.tabPageVideo.Controls.Add(this.richTextBoxScheduledStartTime);
            this.tabPageVideo.Controls.Add(this.textBoxLiveChatId);
            this.tabPageVideo.Controls.Add(this.textBoxVideoId);
            this.tabPageVideo.Controls.Add(this.label11);
            this.tabPageVideo.Controls.Add(this.pbWorking);
            this.tabPageVideo.Controls.Add(this.buttonStop);
            this.tabPageVideo.Controls.Add(this.buttonAsync);
            this.tabPageVideo.Controls.Add(this.label2);
            this.tabPageVideo.Controls.Add(this.labelCount);
            this.tabPageVideo.Controls.Add(this.richTextBoxEndTime);
            this.tabPageVideo.Controls.Add(this.richTextBoxStartTime);
            this.tabPageVideo.Controls.Add(this.richTextBoxPuslishedAt);
            this.tabPageVideo.Controls.Add(this.label8);
            this.tabPageVideo.Controls.Add(this.label7);
            this.tabPageVideo.Controls.Add(this.label6);
            this.tabPageVideo.Controls.Add(this.linkLabelChannelId);
            this.tabPageVideo.Controls.Add(this.label5);
            this.tabPageVideo.Controls.Add(this.label4);
            this.tabPageVideo.Controls.Add(this.richTextBoxDescription);
            this.tabPageVideo.Controls.Add(this.label3);
            this.tabPageVideo.Controls.Add(this.richTextBoxTitle);
            this.tabPageVideo.Controls.Add(this.label1);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(252, 561);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Video Details";
            // 
            // textBoxLiveChatId
            // 
            this.textBoxLiveChatId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxLiveChatId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLiveChatId.Location = new System.Drawing.Point(90, 37);
            this.textBoxLiveChatId.Name = "textBoxLiveChatId";
            this.textBoxLiveChatId.ReadOnly = true;
            this.textBoxLiveChatId.Size = new System.Drawing.Size(156, 23);
            this.textBoxLiveChatId.TabIndex = 31;
            this.textBoxLiveChatId.Text = "";
            this.textBoxLiveChatId.TextChanged += new System.EventHandler(this.textBoxLiveChatId_TextChanged);
            // 
            // textBoxVideoId
            // 
            this.textBoxVideoId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxVideoId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxVideoId.Location = new System.Drawing.Point(90, 10);
            this.textBoxVideoId.Name = "textBoxVideoId";
            this.textBoxVideoId.ReadOnly = true;
            this.textBoxVideoId.Size = new System.Drawing.Size(156, 23);
            this.textBoxVideoId.TabIndex = 30;
            this.textBoxVideoId.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 396);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Chat Count";
            // 
            // pbWorking
            // 
            this.pbWorking.Image = global::derinYouTube.Properties.Resources.ajax_loader;
            this.pbWorking.Location = new System.Drawing.Point(82, 418);
            this.pbWorking.Name = "pbWorking";
            this.pbWorking.Size = new System.Drawing.Size(16, 16);
            this.pbWorking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWorking.TabIndex = 28;
            this.pbWorking.TabStop = false;
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStop.Location = new System.Drawing.Point(82, 479);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(156, 26);
            this.buttonStop.TabIndex = 27;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonAsync
            // 
            this.buttonAsync.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAsync.Location = new System.Drawing.Point(81, 448);
            this.buttonAsync.Name = "buttonAsync";
            this.buttonAsync.Size = new System.Drawing.Size(157, 25);
            this.buttonAsync.TabIndex = 25;
            this.buttonAsync.Text = "Get Live Chats";
            this.buttonAsync.UseVisualStyleBackColor = false;
            this.buttonAsync.Click += new System.EventHandler(this.buttonAsync_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Live Chat ID";
            // 
            // richTextBoxEndTime
            // 
            this.richTextBoxEndTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEndTime.Location = new System.Drawing.Point(90, 274);
            this.richTextBoxEndTime.Name = "richTextBoxEndTime";
            this.richTextBoxEndTime.ReadOnly = true;
            this.richTextBoxEndTime.Size = new System.Drawing.Size(156, 23);
            this.richTextBoxEndTime.TabIndex = 22;
            this.richTextBoxEndTime.Text = "";
            // 
            // richTextBoxStartTime
            // 
            this.richTextBoxStartTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxStartTime.Location = new System.Drawing.Point(90, 245);
            this.richTextBoxStartTime.Name = "richTextBoxStartTime";
            this.richTextBoxStartTime.ReadOnly = true;
            this.richTextBoxStartTime.Size = new System.Drawing.Size(156, 23);
            this.richTextBoxStartTime.TabIndex = 21;
            this.richTextBoxStartTime.Text = "";
            // 
            // richTextBoxPuslishedAt
            // 
            this.richTextBoxPuslishedAt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxPuslishedAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxPuslishedAt.Location = new System.Drawing.Point(90, 216);
            this.richTextBoxPuslishedAt.Name = "richTextBoxPuslishedAt";
            this.richTextBoxPuslishedAt.ReadOnly = true;
            this.richTextBoxPuslishedAt.Size = new System.Drawing.Size(156, 23);
            this.richTextBoxPuslishedAt.TabIndex = 20;
            this.richTextBoxPuslishedAt.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "End Time";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Start Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Published At";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabelChannelId
            // 
            this.linkLabelChannelId.AutoSize = true;
            this.linkLabelChannelId.Location = new System.Drawing.Point(87, 338);
            this.linkLabelChannelId.Name = "linkLabelChannelId";
            this.linkLabelChannelId.Size = new System.Drawing.Size(60, 13);
            this.linkLabelChannelId.TabIndex = 13;
            this.linkLabelChannelId.TabStop = true;
            this.linkLabelChannelId.Text = "Channel ID";
            this.linkLabelChannelId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelChannelId_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Channel ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Title";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Location = new System.Drawing.Point(90, 118);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(156, 93);
            this.richTextBoxDescription.TabIndex = 9;
            this.richTextBoxDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // richTextBoxTitle
            // 
            this.richTextBoxTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTitle.Location = new System.Drawing.Point(90, 66);
            this.richTextBoxTitle.Name = "richTextBoxTitle";
            this.richTextBoxTitle.ReadOnly = true;
            this.richTextBoxTitle.Size = new System.Drawing.Size(156, 46);
            this.richTextBoxTitle.TabIndex = 7;
            this.richTextBoxTitle.Text = "";
            // 
            // splitContainerYatay
            // 
            this.splitContainerYatay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerYatay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerYatay.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerYatay.Location = new System.Drawing.Point(0, 0);
            this.splitContainerYatay.Name = "splitContainerYatay";
            this.splitContainerYatay.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerYatay.Panel1
            // 
            this.splitContainerYatay.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerYatay.Panel1.Controls.Add(this.checkBoxLiveOnly);
            this.splitContainerYatay.Panel1.Controls.Add(this.buttonGetLiveBroadCasts);
            this.splitContainerYatay.Panel1.Controls.Add(this.dgwLiveVideos);
            // 
            // splitContainerYatay.Panel2
            // 
            this.splitContainerYatay.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerYatay.Size = new System.Drawing.Size(852, 589);
            this.splitContainerYatay.SplitterDistance = 191;
            this.splitContainerYatay.TabIndex = 11;
            // 
            // checkBoxLiveOnly
            // 
            this.checkBoxLiveOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxLiveOnly.AutoSize = true;
            this.checkBoxLiveOnly.Checked = true;
            this.checkBoxLiveOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLiveOnly.Location = new System.Drawing.Point(5, 163);
            this.checkBoxLiveOnly.Name = "checkBoxLiveOnly";
            this.checkBoxLiveOnly.Size = new System.Drawing.Size(157, 17);
            this.checkBoxLiveOnly.TabIndex = 17;
            this.checkBoxLiveOnly.Text = "Get Only Active Broadcasts";
            this.checkBoxLiveOnly.UseVisualStyleBackColor = true;
            // 
            // buttonGetLiveBroadCasts
            // 
            this.buttonGetLiveBroadCasts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetLiveBroadCasts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGetLiveBroadCasts.Location = new System.Drawing.Point(168, 158);
            this.buttonGetLiveBroadCasts.Name = "buttonGetLiveBroadCasts";
            this.buttonGetLiveBroadCasts.Size = new System.Drawing.Size(113, 27);
            this.buttonGetLiveBroadCasts.TabIndex = 16;
            this.buttonGetLiveBroadCasts.Text = "Get Live Broadcasts";
            this.buttonGetLiveBroadCasts.UseVisualStyleBackColor = false;
            this.buttonGetLiveBroadCasts.Click += new System.EventHandler(this.buttonGetLiveBroadCasts_Click);
            // 
            // dgwLiveVideos
            // 
            this.dgwLiveVideos.AllowUserToAddRows = false;
            this.dgwLiveVideos.AllowUserToDeleteRows = false;
            this.dgwLiveVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwLiveVideos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgwLiveVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLiveVideos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Description,
            this.PublishedDate,
            this.StartTime,
            this.EndTime,
            this.LiveStatus,
            this.LiveChatId,
            this.ChannelId,
            this.ChannelTitle,
            this.ScheduledStartTime});
            this.dgwLiveVideos.Location = new System.Drawing.Point(5, 3);
            this.dgwLiveVideos.MultiSelect = false;
            this.dgwLiveVideos.Name = "dgwLiveVideos";
            this.dgwLiveVideos.ReadOnly = true;
            this.dgwLiveVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwLiveVideos.Size = new System.Drawing.Size(840, 155);
            this.dgwLiveVideos.TabIndex = 11;
            this.dgwLiveVideos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLiveVideos_CellEnter);
            this.dgwLiveVideos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgwLiveVideos_DataBindingComplete);
            this.dgwLiveVideos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLiveVideos_RowEnter);
            this.dgwLiveVideos.SelectionChanged += new System.EventHandler(this.dgwLiveVideos_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgw);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClearAnswers);
            this.splitContainer1.Panel2.Controls.Add(this.dgwCevap);
            this.splitContainer1.Panel2.Controls.Add(this.buttonFindWinner);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxStopAt);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxStartAt);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCampStop);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxAnswer);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCampStart);
            this.splitContainer1.Size = new System.Drawing.Size(850, 392);
            this.splitContainer1.SplitterDistance = 570;
            this.splitContainer1.TabIndex = 13;
            // 
            // btnClearAnswers
            // 
            this.btnClearAnswers.Location = new System.Drawing.Point(215, 116);
            this.btnClearAnswers.Name = "btnClearAnswers";
            this.btnClearAnswers.Size = new System.Drawing.Size(56, 23);
            this.btnClearAnswers.TabIndex = 13;
            this.btnClearAnswers.Text = "Clear";
            this.btnClearAnswers.UseVisualStyleBackColor = true;
            this.btnClearAnswers.Click += new System.EventHandler(this.btnClearAnswers_Click);
            // 
            // dgwCevap
            // 
            this.dgwCevap.AllowUserToAddRows = false;
            this.dgwCevap.AllowUserToDeleteRows = false;
            this.dgwCevap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwCevap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwCevap.Location = new System.Drawing.Point(9, 145);
            this.dgwCevap.Name = "dgwCevap";
            this.dgwCevap.ReadOnly = true;
            this.dgwCevap.Size = new System.Drawing.Size(262, 244);
            this.dgwCevap.TabIndex = 12;
            // 
            // buttonFindWinner
            // 
            this.buttonFindWinner.Enabled = false;
            this.buttonFindWinner.Location = new System.Drawing.Point(12, 116);
            this.buttonFindWinner.Name = "buttonFindWinner";
            this.buttonFindWinner.Size = new System.Drawing.Size(155, 23);
            this.buttonFindWinner.TabIndex = 11;
            this.buttonFindWinner.Text = "Find Winner";
            this.buttonFindWinner.UseVisualStyleBackColor = true;
            this.buttonFindWinner.Click += new System.EventHandler(this.buttonFindWinner_ClickAsync);
            // 
            // textBoxStopAt
            // 
            this.textBoxStopAt.Location = new System.Drawing.Point(88, 65);
            this.textBoxStopAt.Name = "textBoxStopAt";
            this.textBoxStopAt.ReadOnly = true;
            this.textBoxStopAt.Size = new System.Drawing.Size(177, 21);
            this.textBoxStopAt.TabIndex = 9;
            this.textBoxStopAt.TextChanged += new System.EventHandler(this.textBoxStartAt_TextChanged);
            // 
            // textBoxStartAt
            // 
            this.textBoxStartAt.Location = new System.Drawing.Point(88, 8);
            this.textBoxStartAt.Name = "textBoxStartAt";
            this.textBoxStartAt.ReadOnly = true;
            this.textBoxStartAt.Size = new System.Drawing.Size(177, 21);
            this.textBoxStartAt.TabIndex = 8;
            this.textBoxStartAt.TextChanged += new System.EventHandler(this.textBoxStartAt_TextChanged);
            // 
            // buttonCampStop
            // 
            this.buttonCampStop.Location = new System.Drawing.Point(9, 65);
            this.buttonCampStop.Name = "buttonCampStop";
            this.buttonCampStop.Size = new System.Drawing.Size(73, 23);
            this.buttonCampStop.TabIndex = 7;
            this.buttonCampStop.Text = "Stop";
            this.buttonCampStop.UseVisualStyleBackColor = true;
            this.buttonCampStop.Click += new System.EventHandler(this.buttonCampStop_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Answer";
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Location = new System.Drawing.Point(88, 36);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(177, 21);
            this.textBoxAnswer.TabIndex = 1;
            this.textBoxAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAnswer_KeyPress);
            // 
            // buttonCampStart
            // 
            this.buttonCampStart.Location = new System.Drawing.Point(9, 8);
            this.buttonCampStart.Name = "buttonCampStart";
            this.buttonCampStart.Size = new System.Drawing.Size(73, 23);
            this.buttonCampStart.TabIndex = 0;
            this.buttonCampStart.Text = "Start";
            this.buttonCampStart.UseVisualStyleBackColor = true;
            this.buttonCampStart.Click += new System.EventHandler(this.buttonCampStart_Click);
            // 
            // richTextBoxScheduledStartTime
            // 
            this.richTextBoxScheduledStartTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxScheduledStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxScheduledStartTime.Location = new System.Drawing.Point(90, 303);
            this.richTextBoxScheduledStartTime.Name = "richTextBoxScheduledStartTime";
            this.richTextBoxScheduledStartTime.ReadOnly = true;
            this.richTextBoxScheduledStartTime.Size = new System.Drawing.Size(156, 23);
            this.richTextBoxScheduledStartTime.TabIndex = 32;
            this.richTextBoxScheduledStartTime.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 26);
            this.label10.TabIndex = 33;
            this.label10.Text = "Scheduled\r\nStart Time";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Video Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 66;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 52;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 85;
            // 
            // PublishedDate
            // 
            this.PublishedDate.DataPropertyName = "PublishedDate";
            this.PublishedDate.HeaderText = "Published At";
            this.PublishedDate.Name = "PublishedDate";
            this.PublishedDate.ReadOnly = true;
            this.PublishedDate.Width = 84;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "ActualStartTime";
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 75;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "ActualEndTime";
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Width = 69;
            // 
            // LiveStatus
            // 
            this.LiveStatus.DataPropertyName = "LiveStatus";
            this.LiveStatus.HeaderText = "Live Status";
            this.LiveStatus.Name = "LiveStatus";
            this.LiveStatus.ReadOnly = true;
            this.LiveStatus.Width = 78;
            // 
            // LiveChatId
            // 
            this.LiveChatId.DataPropertyName = "LiveChatId";
            this.LiveChatId.HeaderText = "Live Chat Id";
            this.LiveChatId.Name = "LiveChatId";
            this.LiveChatId.ReadOnly = true;
            this.LiveChatId.Width = 74;
            // 
            // ChannelId
            // 
            this.ChannelId.DataPropertyName = "ChannelId";
            this.ChannelId.HeaderText = "ChannelId";
            this.ChannelId.Name = "ChannelId";
            this.ChannelId.ReadOnly = true;
            this.ChannelId.Visible = false;
            // 
            // ChannelTitle
            // 
            this.ChannelTitle.DataPropertyName = "ChannelTitle";
            this.ChannelTitle.HeaderText = "ChannelTitle";
            this.ChannelTitle.Name = "ChannelTitle";
            this.ChannelTitle.ReadOnly = true;
            this.ChannelTitle.Visible = false;
            // 
            // ScheduledStartTime
            // 
            this.ScheduledStartTime.DataPropertyName = "ScheduledStartTime";
            this.ScheduledStartTime.HeaderText = "Scheduled Start Time";
            this.ScheduledStartTime.Name = "ScheduledStartTime";
            this.ScheduledStartTime.ReadOnly = true;
            this.ScheduledStartTime.Width = 102;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1117, 589);
            this.Controls.Add(this.splitContainerDikey);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouTube Chat & Comment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.splitContainerDikey.Panel1.ResumeLayout(false);
            this.splitContainerDikey.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDikey)).EndInit();
            this.splitContainerDikey.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).EndInit();
            this.splitContainerYatay.Panel1.ResumeLayout(false);
            this.splitContainerYatay.Panel1.PerformLayout();
            this.splitContainerYatay.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerYatay)).EndInit();
            this.splitContainerYatay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwLiveVideos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwCevap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.SplitContainer splitContainerDikey;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.RichTextBox richTextBoxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabelChannelId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainerYatay;
        private System.Windows.Forms.DataGridView dgwLiveVideos;
        private System.Windows.Forms.Button buttonGetLiveBroadCasts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBoxEndTime;
        private System.Windows.Forms.RichTextBox richTextBoxStartTime;
        private System.Windows.Forms.RichTextBox richTextBoxPuslishedAt;
        private System.Windows.Forms.CheckBox checkBoxLiveOnly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAsync;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbWorking;
        private System.Windows.Forms.RichTextBox textBoxLiveChatId;
        private System.Windows.Forms.RichTextBox textBoxVideoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelUrl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsVerified;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChatOwner;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChatSponsor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChatModerator;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCampStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Button buttonCampStop;
        private System.Windows.Forms.TextBox textBoxStartAt;
        private System.Windows.Forms.TextBox textBoxStopAt;
        private System.Windows.Forms.Button buttonFindWinner;
        private System.Windows.Forms.DataGridView dgwCevap;
        private System.Windows.Forms.Button btnClearAnswers;
        private System.Windows.Forms.RichTextBox richTextBoxScheduledStartTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LiveStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn LiveChatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduledStartTime;
    }
}