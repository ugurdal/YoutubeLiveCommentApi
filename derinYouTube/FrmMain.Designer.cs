namespace derinYouTube
{
    sealed partial class FrmMain
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
            this.tabControlLeftMenu = new System.Windows.Forms.TabControl();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBoxScheduledStartTime = new System.Windows.Forms.RichTextBox();
            this.textBoxLiveChatId = new System.Windows.Forms.RichTextBox();
            this.textBoxVideoId = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLive = new System.Windows.Forms.TabPage();
            this.splitContainerYatay = new System.Windows.Forms.SplitContainer();
            this.labelStreamsSaving = new System.Windows.Forms.Label();
            this.labelCalisiyorMesaj = new System.Windows.Forms.Label();
            this.checkBoxLiveOnly = new System.Windows.Forms.CheckBox();
            this.dgwLiveVideos = new System.Windows.Forms.DataGridView();
            this.tabPageQuestion = new System.Windows.Forms.TabPage();
            this.splitContainerQA = new System.Windows.Forms.SplitContainer();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBoxAnswers = new System.Windows.Forms.TextBox();
            this.richTextBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.textBoxQuestionStopAt = new System.Windows.Forms.TextBox();
            this.buttonQuestionStop = new System.Windows.Forms.Button();
            this.labelQuestionId = new System.Windows.Forms.Label();
            this.buttonQuestionStart = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxQuestionStartAt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgwAnswers = new System.Windows.Forms.DataGridView();
            this.tabPageAnalysis = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgwCompetitionDetail = new System.Windows.Forms.DataGridView();
            this.dgwCompetitionHeader = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtReport = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLayoutPanelWinnerOfDay = new System.Windows.Forms.TableLayoutPanel();
            this.dgwWinnerDetail = new System.Windows.Forms.DataGridView();
            this.dgwWinnerOfDay = new System.Windows.Forms.DataGridView();
            this.tabPageChats = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelChats = new System.Windows.Forms.TableLayoutPanel();
            this.dgwChats = new System.Windows.Forms.DataGridView();
            this.dgwStreams = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtAllStreams = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelChatCount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.timerViewerCount = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pbWorking = new System.Windows.Forms.PictureBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonAsync = new System.Windows.Forms.Button();
            this.buttonGetLiveBroadCasts = new System.Windows.Forms.Button();
            this.tsButtonNewQuestions = new System.Windows.Forms.ToolStripButton();
            this.tsButtonShowQList = new System.Windows.Forms.ToolStripButton();
            this.tsButtonQuestionList = new System.Windows.Forms.ToolStripButton();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonShowStreams = new System.Windows.Forms.Button();
            this.buttonShowChats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDikey)).BeginInit();
            this.splitContainerDikey.Panel1.SuspendLayout();
            this.splitContainerDikey.Panel2.SuspendLayout();
            this.splitContainerDikey.SuspendLayout();
            this.tabControlLeftMenu.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageLive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerYatay)).BeginInit();
            this.splitContainerYatay.Panel1.SuspendLayout();
            this.splitContainerYatay.Panel2.SuspendLayout();
            this.splitContainerYatay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLiveVideos)).BeginInit();
            this.tabPageQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQA)).BeginInit();
            this.splitContainerQA.Panel1.SuspendLayout();
            this.splitContainerQA.Panel2.SuspendLayout();
            this.splitContainerQA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).BeginInit();
            this.tabPageAnalysis.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompetitionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompetitionHeader)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanelWinnerOfDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwWinnerDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwWinnerOfDay)).BeginInit();
            this.tabPageChats.SuspendLayout();
            this.tableLayoutPanelChats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwChats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStreams)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Video ID";
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgw.ColumnHeadersHeight = 25;
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
            this.dgw.Size = new System.Drawing.Size(768, 193);
            this.dgw.TabIndex = 7;
            this.dgw.Visible = false;
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
            this.labelCount.Location = new System.Drawing.Point(142, 458);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(80, 13);
            this.labelCount.TabIndex = 8;
            this.labelCount.Text = "0";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainerDikey
            // 
            this.splitContainerDikey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerDikey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDikey.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDikey.IsSplitterFixed = true;
            this.splitContainerDikey.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDikey.Name = "splitContainerDikey";
            // 
            // splitContainerDikey.Panel1
            // 
            this.splitContainerDikey.Panel1.Controls.Add(this.tabControlLeftMenu);
            // 
            // splitContainerDikey.Panel2
            // 
            this.splitContainerDikey.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainerDikey.Size = new System.Drawing.Size(1027, 638);
            this.splitContainerDikey.SplitterDistance = 240;
            this.splitContainerDikey.SplitterWidth = 3;
            this.splitContainerDikey.TabIndex = 11;
            // 
            // tabControlLeftMenu
            // 
            this.tabControlLeftMenu.Controls.Add(this.tabPageVideo);
            this.tabControlLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLeftMenu.ItemSize = new System.Drawing.Size(73, 25);
            this.tabControlLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.tabControlLeftMenu.Name = "tabControlLeftMenu";
            this.tabControlLeftMenu.SelectedIndex = 0;
            this.tabControlLeftMenu.Size = new System.Drawing.Size(238, 636);
            this.tabControlLeftMenu.TabIndex = 0;
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
            this.tabPageVideo.Location = new System.Drawing.Point(4, 29);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(230, 603);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Video Bilgileri";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(11, 371);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Planlanan Başlangıç Tarihi";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richTextBoxScheduledStartTime
            // 
            this.richTextBoxScheduledStartTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxScheduledStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxScheduledStartTime.Location = new System.Drawing.Point(11, 387);
            this.richTextBoxScheduledStartTime.Name = "richTextBoxScheduledStartTime";
            this.richTextBoxScheduledStartTime.ReadOnly = true;
            this.richTextBoxScheduledStartTime.Size = new System.Drawing.Size(211, 23);
            this.richTextBoxScheduledStartTime.TabIndex = 32;
            this.richTextBoxScheduledStartTime.Text = "";
            // 
            // textBoxLiveChatId
            // 
            this.textBoxLiveChatId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxLiveChatId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLiveChatId.Location = new System.Drawing.Point(11, 65);
            this.textBoxLiveChatId.Name = "textBoxLiveChatId";
            this.textBoxLiveChatId.ReadOnly = true;
            this.textBoxLiveChatId.Size = new System.Drawing.Size(211, 23);
            this.textBoxLiveChatId.TabIndex = 31;
            this.textBoxLiveChatId.Text = "";
            this.textBoxLiveChatId.TextChanged += new System.EventHandler(this.textBoxLiveChatId_TextChanged);
            // 
            // textBoxVideoId
            // 
            this.textBoxVideoId.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxVideoId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxVideoId.Location = new System.Drawing.Point(11, 23);
            this.textBoxVideoId.Name = "textBoxVideoId";
            this.textBoxVideoId.ReadOnly = true;
            this.textBoxVideoId.Size = new System.Drawing.Size(211, 23);
            this.textBoxVideoId.TabIndex = 30;
            this.textBoxVideoId.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(11, 458);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Toplam Yorum Sayısı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Live Chat ID";
            // 
            // richTextBoxEndTime
            // 
            this.richTextBoxEndTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxEndTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEndTime.Location = new System.Drawing.Point(11, 345);
            this.richTextBoxEndTime.Name = "richTextBoxEndTime";
            this.richTextBoxEndTime.ReadOnly = true;
            this.richTextBoxEndTime.Size = new System.Drawing.Size(211, 23);
            this.richTextBoxEndTime.TabIndex = 22;
            this.richTextBoxEndTime.Text = "";
            // 
            // richTextBoxStartTime
            // 
            this.richTextBoxStartTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxStartTime.Location = new System.Drawing.Point(11, 303);
            this.richTextBoxStartTime.Name = "richTextBoxStartTime";
            this.richTextBoxStartTime.ReadOnly = true;
            this.richTextBoxStartTime.Size = new System.Drawing.Size(211, 23);
            this.richTextBoxStartTime.TabIndex = 21;
            this.richTextBoxStartTime.Text = "";
            // 
            // richTextBoxPuslishedAt
            // 
            this.richTextBoxPuslishedAt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxPuslishedAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxPuslishedAt.Location = new System.Drawing.Point(11, 261);
            this.richTextBoxPuslishedAt.Name = "richTextBoxPuslishedAt";
            this.richTextBoxPuslishedAt.ReadOnly = true;
            this.richTextBoxPuslishedAt.Size = new System.Drawing.Size(211, 23);
            this.richTextBoxPuslishedAt.TabIndex = 20;
            this.richTextBoxPuslishedAt.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(11, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Bitiş Tarihi";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(11, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Başlangıç Tarihi";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(11, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Yayın Tarihi";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabelChannelId
            // 
            this.linkLabelChannelId.Location = new System.Drawing.Point(88, 430);
            this.linkLabelChannelId.Name = "linkLabelChannelId";
            this.linkLabelChannelId.Size = new System.Drawing.Size(134, 15);
            this.linkLabelChannelId.TabIndex = 13;
            this.linkLabelChannelId.TabStop = true;
            this.linkLabelChannelId.Text = "Channel ID";
            this.linkLabelChannelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelChannelId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelChannelId_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(11, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kanal ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Başlık";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Location = new System.Drawing.Point(11, 171);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(211, 71);
            this.richTextBoxDescription.TabIndex = 9;
            this.richTextBoxDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(11, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Açıklama";
            // 
            // richTextBoxTitle
            // 
            this.richTextBoxTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTitle.Location = new System.Drawing.Point(11, 107);
            this.richTextBoxTitle.Name = "richTextBoxTitle";
            this.richTextBoxTitle.ReadOnly = true;
            this.richTextBoxTitle.Size = new System.Drawing.Size(211, 46);
            this.richTextBoxTitle.TabIndex = 7;
            this.richTextBoxTitle.Text = "";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLive);
            this.tabControlMain.Controls.Add(this.tabPageQuestion);
            this.tabControlMain.Controls.Add(this.tabPageAnalysis);
            this.tabControlMain.Controls.Add(this.tabPageChats);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ItemSize = new System.Drawing.Size(58, 25);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(782, 636);
            this.tabControlMain.TabIndex = 12;
            // 
            // tabPageLive
            // 
            this.tabPageLive.Controls.Add(this.splitContainerYatay);
            this.tabPageLive.Location = new System.Drawing.Point(4, 29);
            this.tabPageLive.Name = "tabPageLive";
            this.tabPageLive.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLive.Size = new System.Drawing.Size(774, 603);
            this.tabPageLive.TabIndex = 0;
            this.tabPageLive.Text = "Canlı Yayınlar";
            this.tabPageLive.UseVisualStyleBackColor = true;
            // 
            // splitContainerYatay
            // 
            this.splitContainerYatay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerYatay.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerYatay.Location = new System.Drawing.Point(3, 3);
            this.splitContainerYatay.Name = "splitContainerYatay";
            this.splitContainerYatay.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerYatay.Panel1
            // 
            this.splitContainerYatay.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerYatay.Panel1.Controls.Add(this.labelStreamsSaving);
            this.splitContainerYatay.Panel1.Controls.Add(this.labelCalisiyorMesaj);
            this.splitContainerYatay.Panel1.Controls.Add(this.checkBoxLiveOnly);
            this.splitContainerYatay.Panel1.Controls.Add(this.buttonGetLiveBroadCasts);
            this.splitContainerYatay.Panel1.Controls.Add(this.dgwLiveVideos);
            // 
            // splitContainerYatay.Panel2
            // 
            this.splitContainerYatay.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainerYatay.Panel2.Controls.Add(this.dgw);
            this.splitContainerYatay.Size = new System.Drawing.Size(768, 597);
            this.splitContainerYatay.SplitterDistance = 400;
            this.splitContainerYatay.TabIndex = 11;
            // 
            // labelStreamsSaving
            // 
            this.labelStreamsSaving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStreamsSaving.BackColor = System.Drawing.Color.DarkRed;
            this.labelStreamsSaving.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStreamsSaving.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStreamsSaving.Location = new System.Drawing.Point(618, 317);
            this.labelStreamsSaving.Name = "labelStreamsSaving";
            this.labelStreamsSaving.Size = new System.Drawing.Size(146, 29);
            this.labelStreamsSaving.TabIndex = 19;
            this.labelStreamsSaving.Text = ".... Kaydediliyor ....";
            this.labelStreamsSaving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStreamsSaving.Visible = false;
            // 
            // labelCalisiyorMesaj
            // 
            this.labelCalisiyorMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCalisiyorMesaj.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.labelCalisiyorMesaj.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCalisiyorMesaj.ForeColor = System.Drawing.SystemColors.Window;
            this.labelCalisiyorMesaj.Location = new System.Drawing.Point(3, 365);
            this.labelCalisiyorMesaj.Name = "labelCalisiyorMesaj";
            this.labelCalisiyorMesaj.Size = new System.Drawing.Size(762, 32);
            this.labelCalisiyorMesaj.TabIndex = 18;
            this.labelCalisiyorMesaj.Text = "Servisten Yorumlar Okunuyor ve Kaydediliyor!!";
            this.labelCalisiyorMesaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCalisiyorMesaj.Visible = false;
            // 
            // checkBoxLiveOnly
            // 
            this.checkBoxLiveOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxLiveOnly.Checked = true;
            this.checkBoxLiveOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLiveOnly.Location = new System.Drawing.Point(122, 320);
            this.checkBoxLiveOnly.Name = "checkBoxLiveOnly";
            this.checkBoxLiveOnly.Size = new System.Drawing.Size(107, 32);
            this.checkBoxLiveOnly.TabIndex = 17;
            this.checkBoxLiveOnly.Text = "Sadece Canlı Yayınları Göster";
            this.checkBoxLiveOnly.UseVisualStyleBackColor = true;
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
            this.dgwLiveVideos.Location = new System.Drawing.Point(3, 3);
            this.dgwLiveVideos.MultiSelect = false;
            this.dgwLiveVideos.Name = "dgwLiveVideos";
            this.dgwLiveVideos.ReadOnly = true;
            this.dgwLiveVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwLiveVideos.Size = new System.Drawing.Size(761, 312);
            this.dgwLiveVideos.TabIndex = 11;
            this.dgwLiveVideos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLiveVideos_CellEnter);
            this.dgwLiveVideos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgwLiveVideos_DataBindingComplete);
            this.dgwLiveVideos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLiveVideos_RowEnter);
            this.dgwLiveVideos.SelectionChanged += new System.EventHandler(this.dgwLiveVideos_SelectionChanged);
            // 
            // tabPageQuestion
            // 
            this.tabPageQuestion.Controls.Add(this.splitContainerQA);
            this.tabPageQuestion.Location = new System.Drawing.Point(4, 29);
            this.tabPageQuestion.Name = "tabPageQuestion";
            this.tabPageQuestion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuestion.Size = new System.Drawing.Size(774, 603);
            this.tabPageQuestion.TabIndex = 1;
            this.tabPageQuestion.Text = "Soru Sor";
            this.tabPageQuestion.UseVisualStyleBackColor = true;
            // 
            // splitContainerQA
            // 
            this.splitContainerQA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerQA.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerQA.IsSplitterFixed = true;
            this.splitContainerQA.Location = new System.Drawing.Point(3, 3);
            this.splitContainerQA.Name = "splitContainerQA";
            this.splitContainerQA.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerQA.Panel1
            // 
            this.splitContainerQA.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerQA.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerQA.Panel1.Controls.Add(this.label14);
            this.splitContainerQA.Panel1.Controls.Add(this.richTextBoxAnswers);
            this.splitContainerQA.Panel1.Controls.Add(this.richTextBoxQuestion);
            this.splitContainerQA.Panel1.Controls.Add(this.textBoxQuestionStopAt);
            this.splitContainerQA.Panel1.Controls.Add(this.buttonQuestionStop);
            this.splitContainerQA.Panel1.Controls.Add(this.labelQuestionId);
            this.splitContainerQA.Panel1.Controls.Add(this.buttonQuestionStart);
            this.splitContainerQA.Panel1.Controls.Add(this.label12);
            this.splitContainerQA.Panel1.Controls.Add(this.textBoxQuestionStartAt);
            this.splitContainerQA.Panel1.Controls.Add(this.label13);
            // 
            // splitContainerQA.Panel2
            // 
            this.splitContainerQA.Panel2.Controls.Add(this.dgwAnswers);
            this.splitContainerQA.Size = new System.Drawing.Size(768, 597);
            this.splitContainerQA.SplitterDistance = 220;
            this.splitContainerQA.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.BackColor = System.Drawing.Color.Firebrick;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(52, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(379, 24);
            this.label14.TabIndex = 19;
            this.label14.Text = "Bilgi! Soruyu bitirdiğinizde geçerli cevaplar aşağıda listelenecek!";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxAnswers
            // 
            this.richTextBoxAnswers.Location = new System.Drawing.Point(55, 98);
            this.richTextBoxAnswers.Name = "richTextBoxAnswers";
            this.richTextBoxAnswers.Size = new System.Drawing.Size(88, 21);
            this.richTextBoxAnswers.TabIndex = 13;
            this.richTextBoxAnswers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAnswer_KeyPress);
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxQuestion.Location = new System.Drawing.Point(54, 36);
            this.richTextBoxQuestion.MaxLength = 1000;
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.Size = new System.Drawing.Size(377, 56);
            this.richTextBoxQuestion.TabIndex = 1;
            this.richTextBoxQuestion.Text = "";
            // 
            // textBoxQuestionStopAt
            // 
            this.textBoxQuestionStopAt.Location = new System.Drawing.Point(149, 159);
            this.textBoxQuestionStopAt.Name = "textBoxQuestionStopAt";
            this.textBoxQuestionStopAt.ReadOnly = true;
            this.textBoxQuestionStopAt.Size = new System.Drawing.Size(162, 21);
            this.textBoxQuestionStopAt.TabIndex = 9;
            this.textBoxQuestionStopAt.TextChanged += new System.EventHandler(this.textBoxStartAt_TextChanged);
            // 
            // buttonQuestionStop
            // 
            this.buttonQuestionStop.Location = new System.Drawing.Point(54, 159);
            this.buttonQuestionStop.Name = "buttonQuestionStop";
            this.buttonQuestionStop.Size = new System.Drawing.Size(89, 23);
            this.buttonQuestionStop.TabIndex = 7;
            this.buttonQuestionStop.Text = "Bitir";
            this.buttonQuestionStop.UseVisualStyleBackColor = true;
            this.buttonQuestionStop.Click += new System.EventHandler(this.buttonQuestionStop_Click);
            // 
            // labelQuestionId
            // 
            this.labelQuestionId.AutoSize = true;
            this.labelQuestionId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestionId.Location = new System.Drawing.Point(437, 36);
            this.labelQuestionId.Name = "labelQuestionId";
            this.labelQuestionId.Size = new System.Drawing.Size(14, 13);
            this.labelQuestionId.TabIndex = 10;
            this.labelQuestionId.Text = "0";
            // 
            // buttonQuestionStart
            // 
            this.buttonQuestionStart.Location = new System.Drawing.Point(54, 130);
            this.buttonQuestionStart.Name = "buttonQuestionStart";
            this.buttonQuestionStart.Size = new System.Drawing.Size(89, 23);
            this.buttonQuestionStart.TabIndex = 0;
            this.buttonQuestionStart.Text = "Başla";
            this.buttonQuestionStart.UseVisualStyleBackColor = true;
            this.buttonQuestionStart.Click += new System.EventHandler(this.buttonQuestionStart_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Soru";
            // 
            // textBoxQuestionStartAt
            // 
            this.textBoxQuestionStartAt.Location = new System.Drawing.Point(149, 132);
            this.textBoxQuestionStartAt.Name = "textBoxQuestionStartAt";
            this.textBoxQuestionStartAt.ReadOnly = true;
            this.textBoxQuestionStartAt.Size = new System.Drawing.Size(162, 21);
            this.textBoxQuestionStartAt.TabIndex = 8;
            this.textBoxQuestionStartAt.TextChanged += new System.EventHandler(this.textBoxStartAt_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Cevap";
            // 
            // dgwAnswers
            // 
            this.dgwAnswers.AllowUserToAddRows = false;
            this.dgwAnswers.AllowUserToDeleteRows = false;
            this.dgwAnswers.ColumnHeadersHeight = 40;
            this.dgwAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwAnswers.Location = new System.Drawing.Point(0, 0);
            this.dgwAnswers.Name = "dgwAnswers";
            this.dgwAnswers.ReadOnly = true;
            this.dgwAnswers.Size = new System.Drawing.Size(768, 373);
            this.dgwAnswers.TabIndex = 15;
            // 
            // tabPageAnalysis
            // 
            this.tabPageAnalysis.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAnalysis.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAnalysis.Location = new System.Drawing.Point(4, 29);
            this.tabPageAnalysis.Name = "tabPageAnalysis";
            this.tabPageAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalysis.Size = new System.Drawing.Size(774, 603);
            this.tabPageAnalysis.TabIndex = 2;
            this.tabPageAnalysis.Text = "Soru ve Cevap Analizi";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgwCompetitionDetail, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgwCompetitionHeader, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelWinnerOfDay, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgwCompetitionDetail
            // 
            this.dgwCompetitionDetail.AllowUserToAddRows = false;
            this.dgwCompetitionDetail.AllowUserToDeleteRows = false;
            this.dgwCompetitionDetail.ColumnHeadersHeight = 40;
            this.dgwCompetitionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwCompetitionDetail.Location = new System.Drawing.Point(3, 206);
            this.dgwCompetitionDetail.Name = "dgwCompetitionDetail";
            this.dgwCompetitionDetail.ReadOnly = true;
            this.dgwCompetitionDetail.Size = new System.Drawing.Size(762, 240);
            this.dgwCompetitionDetail.TabIndex = 17;
            this.dgwCompetitionDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwCompetitionDetail_CellDoubleClick);
            // 
            // dgwCompetitionHeader
            // 
            this.dgwCompetitionHeader.AllowUserToAddRows = false;
            this.dgwCompetitionHeader.AllowUserToDeleteRows = false;
            this.dgwCompetitionHeader.ColumnHeadersHeight = 40;
            this.dgwCompetitionHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwCompetitionHeader.Location = new System.Drawing.Point(3, 58);
            this.dgwCompetitionHeader.Name = "dgwCompetitionHeader";
            this.dgwCompetitionHeader.ReadOnly = true;
            this.dgwCompetitionHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwCompetitionHeader.Size = new System.Drawing.Size(762, 117);
            this.dgwCompetitionHeader.TabIndex = 16;
            this.dgwCompetitionHeader.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwCompetitionHeader_RowEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.buttonReport);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 49);
            this.panel1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(3, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Yarışmalar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Analiz Tarihi";
            // 
            // dtReport
            // 
            this.dtReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReport.Location = new System.Drawing.Point(92, 3);
            this.dtReport.Name = "dtReport";
            this.dtReport.Size = new System.Drawing.Size(102, 21);
            this.dtReport.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 19);
            this.panel2.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "Günün Birincisi";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(762, 19);
            this.panel3.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(322, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Geçerli Cevaplar ( Yalnızca Numerik Cevaplar Gösterilir )";
            // 
            // tableLayoutPanelWinnerOfDay
            // 
            this.tableLayoutPanelWinnerOfDay.ColumnCount = 2;
            this.tableLayoutPanelWinnerOfDay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWinnerOfDay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWinnerOfDay.Controls.Add(this.dgwWinnerDetail, 1, 0);
            this.tableLayoutPanelWinnerOfDay.Controls.Add(this.dgwWinnerOfDay, 0, 0);
            this.tableLayoutPanelWinnerOfDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWinnerOfDay.Location = new System.Drawing.Point(3, 477);
            this.tableLayoutPanelWinnerOfDay.Name = "tableLayoutPanelWinnerOfDay";
            this.tableLayoutPanelWinnerOfDay.RowCount = 1;
            this.tableLayoutPanelWinnerOfDay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWinnerOfDay.Size = new System.Drawing.Size(762, 117);
            this.tableLayoutPanelWinnerOfDay.TabIndex = 18;
            // 
            // dgwWinnerDetail
            // 
            this.dgwWinnerDetail.AllowUserToAddRows = false;
            this.dgwWinnerDetail.AllowUserToDeleteRows = false;
            this.dgwWinnerDetail.ColumnHeadersHeight = 40;
            this.dgwWinnerDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwWinnerDetail.Location = new System.Drawing.Point(384, 3);
            this.dgwWinnerDetail.Name = "dgwWinnerDetail";
            this.dgwWinnerDetail.ReadOnly = true;
            this.dgwWinnerDetail.Size = new System.Drawing.Size(375, 111);
            this.dgwWinnerDetail.TabIndex = 19;
            // 
            // dgwWinnerOfDay
            // 
            this.dgwWinnerOfDay.AllowUserToAddRows = false;
            this.dgwWinnerOfDay.AllowUserToDeleteRows = false;
            this.dgwWinnerOfDay.ColumnHeadersHeight = 40;
            this.dgwWinnerOfDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwWinnerOfDay.Location = new System.Drawing.Point(3, 3);
            this.dgwWinnerOfDay.Name = "dgwWinnerOfDay";
            this.dgwWinnerOfDay.ReadOnly = true;
            this.dgwWinnerOfDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgwWinnerOfDay.Size = new System.Drawing.Size(375, 111);
            this.dgwWinnerOfDay.TabIndex = 18;
            this.dgwWinnerOfDay.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwWinnerOfDay_RowEnter);
            // 
            // tabPageChats
            // 
            this.tabPageChats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPageChats.Controls.Add(this.tableLayoutPanelChats);
            this.tabPageChats.Location = new System.Drawing.Point(4, 29);
            this.tabPageChats.Name = "tabPageChats";
            this.tabPageChats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChats.Size = new System.Drawing.Size(774, 603);
            this.tabPageChats.TabIndex = 3;
            this.tabPageChats.Text = "Tüm Yorumlar";
            // 
            // tableLayoutPanelChats
            // 
            this.tableLayoutPanelChats.ColumnCount = 1;
            this.tableLayoutPanelChats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelChats.Controls.Add(this.dgwChats, 0, 3);
            this.tableLayoutPanelChats.Controls.Add(this.dgwStreams, 0, 1);
            this.tableLayoutPanelChats.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanelChats.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanelChats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelChats.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelChats.Name = "tableLayoutPanelChats";
            this.tableLayoutPanelChats.RowCount = 4;
            this.tableLayoutPanelChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelChats.Size = new System.Drawing.Size(768, 597);
            this.tableLayoutPanelChats.TabIndex = 0;
            // 
            // dgwChats
            // 
            this.dgwChats.AllowUserToAddRows = false;
            this.dgwChats.AllowUserToDeleteRows = false;
            this.dgwChats.ColumnHeadersHeight = 40;
            this.dgwChats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwChats.Location = new System.Drawing.Point(3, 231);
            this.dgwChats.Name = "dgwChats";
            this.dgwChats.ReadOnly = true;
            this.dgwChats.Size = new System.Drawing.Size(762, 363);
            this.dgwChats.TabIndex = 18;
            // 
            // dgwStreams
            // 
            this.dgwStreams.AllowUserToAddRows = false;
            this.dgwStreams.AllowUserToDeleteRows = false;
            this.dgwStreams.ColumnHeadersHeight = 40;
            this.dgwStreams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwStreams.Location = new System.Drawing.Point(3, 38);
            this.dgwStreams.Name = "dgwStreams";
            this.dgwStreams.ReadOnly = true;
            this.dgwStreams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwStreams.Size = new System.Drawing.Size(762, 152);
            this.dgwStreams.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.dtAllStreams);
            this.panel4.Controls.Add(this.buttonShowStreams);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(762, 29);
            this.panel4.TabIndex = 3;
            // 
            // dtAllStreams
            // 
            this.dtAllStreams.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAllStreams.Location = new System.Drawing.Point(98, 4);
            this.dtAllStreams.Name = "dtAllStreams";
            this.dtAllStreams.Size = new System.Drawing.Size(102, 21);
            this.dtAllStreams.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(3, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Yayın Listesi";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel5.Controls.Add(this.labelChatCount);
            this.panel5.Controls.Add(this.buttonShowChats);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 196);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(762, 29);
            this.panel5.TabIndex = 3;
            // 
            // labelChatCount
            // 
            this.labelChatCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChatCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelChatCount.Location = new System.Drawing.Point(655, 7);
            this.labelChatCount.Name = "labelChatCount";
            this.labelChatCount.Size = new System.Drawing.Size(104, 13);
            this.labelChatCount.TabIndex = 39;
            this.labelChatCount.Text = "0";
            this.labelChatCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.Location = new System.Drawing.Point(3, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Yorum Listesi";
            // 
            // timerViewerCount
            // 
            this.timerViewerCount.Enabled = true;
            this.timerViewerCount.Interval = 60000;
            this.timerViewerCount.Tick += new System.EventHandler(this.timerViewerCount_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonNewQuestions,
            this.toolStripSeparator1,
            this.tsButtonShowQList,
            this.toolStripSeparator2,
            this.tsButtonQuestionList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(768, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // pbWorking
            // 
            this.pbWorking.Image = global::derinYouTube.Properties.Resources.ajax_loader;
            this.pbWorking.Location = new System.Drawing.Point(206, 485);
            this.pbWorking.Name = "pbWorking";
            this.pbWorking.Size = new System.Drawing.Size(16, 16);
            this.pbWorking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWorking.TabIndex = 28;
            this.pbWorking.TabStop = false;
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStop.Image = global::derinYouTube.Properties.Resources.StopHS;
            this.buttonStop.Location = new System.Drawing.Point(145, 539);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(77, 41);
            this.buttonStop.TabIndex = 27;
            this.buttonStop.Text = "Bitir";
            this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonAsync
            // 
            this.buttonAsync.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAsync.Image = global::derinYouTube.Properties.Resources.FormRunHS;
            this.buttonAsync.Location = new System.Drawing.Point(10, 539);
            this.buttonAsync.Name = "buttonAsync";
            this.buttonAsync.Size = new System.Drawing.Size(127, 40);
            this.buttonAsync.TabIndex = 25;
            this.buttonAsync.Text = "Başla";
            this.buttonAsync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAsync.UseVisualStyleBackColor = false;
            this.buttonAsync.Click += new System.EventHandler(this.buttonAsync_Click);
            // 
            // buttonGetLiveBroadCasts
            // 
            this.buttonGetLiveBroadCasts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetLiveBroadCasts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGetLiveBroadCasts.Image = global::derinYouTube.Properties.Resources.Web;
            this.buttonGetLiveBroadCasts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGetLiveBroadCasts.Location = new System.Drawing.Point(3, 319);
            this.buttonGetLiveBroadCasts.Name = "buttonGetLiveBroadCasts";
            this.buttonGetLiveBroadCasts.Size = new System.Drawing.Size(113, 33);
            this.buttonGetLiveBroadCasts.TabIndex = 16;
            this.buttonGetLiveBroadCasts.Text = "Yayınları Göster";
            this.buttonGetLiveBroadCasts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGetLiveBroadCasts.UseVisualStyleBackColor = false;
            this.buttonGetLiveBroadCasts.Click += new System.EventHandler(this.buttonGetLiveBroadCasts_Click);
            // 
            // tsButtonNewQuestions
            // 
            this.tsButtonNewQuestions.Image = global::derinYouTube.Properties.Resources.AddTableHS;
            this.tsButtonNewQuestions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonNewQuestions.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tsButtonNewQuestions.Name = "tsButtonNewQuestions";
            this.tsButtonNewQuestions.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsButtonNewQuestions.Size = new System.Drawing.Size(96, 22);
            this.tsButtonNewQuestions.Text = "Yeni Soru";
            this.tsButtonNewQuestions.Click += new System.EventHandler(this.buttonNewQuestions_Click);
            // 
            // tsButtonShowQList
            // 
            this.tsButtonShowQList.Image = global::derinYouTube.Properties.Resources.CheckBoxHS;
            this.tsButtonShowQList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonShowQList.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tsButtonShowQList.Name = "tsButtonShowQList";
            this.tsButtonShowQList.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsButtonShowQList.Size = new System.Drawing.Size(160, 22);
            this.tsButtonShowQList.Text = "Soru Listesinden Seç !";
            this.tsButtonShowQList.Click += new System.EventHandler(this.buttonShowQList_Click);
            // 
            // tsButtonQuestionList
            // 
            this.tsButtonQuestionList.Image = global::derinYouTube.Properties.Resources.EditTableHS;
            this.tsButtonQuestionList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonQuestionList.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tsButtonQuestionList.Name = "tsButtonQuestionList";
            this.tsButtonQuestionList.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tsButtonQuestionList.Size = new System.Drawing.Size(110, 22);
            this.tsButtonQuestionList.Text = "Soru Hazırla";
            this.tsButtonQuestionList.Click += new System.EventHandler(this.buttonQuestionList_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Image = global::derinYouTube.Properties.Resources.FindHS1;
            this.buttonReport.Location = new System.Drawing.Point(200, 2);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(86, 23);
            this.buttonReport.TabIndex = 35;
            this.buttonReport.Text = "Göster";
            this.buttonReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonShowStreams
            // 
            this.buttonShowStreams.Image = global::derinYouTube.Properties.Resources.FindHS1;
            this.buttonShowStreams.Location = new System.Drawing.Point(206, 3);
            this.buttonShowStreams.Name = "buttonShowStreams";
            this.buttonShowStreams.Size = new System.Drawing.Size(84, 23);
            this.buttonShowStreams.TabIndex = 39;
            this.buttonShowStreams.Text = "Göster";
            this.buttonShowStreams.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonShowStreams.UseVisualStyleBackColor = true;
            this.buttonShowStreams.Click += new System.EventHandler(this.buttonShowStreams_Click);
            // 
            // buttonShowChats
            // 
            this.buttonShowChats.Image = global::derinYouTube.Properties.Resources.FindHS1;
            this.buttonShowChats.Location = new System.Drawing.Point(98, 2);
            this.buttonShowChats.Name = "buttonShowChats";
            this.buttonShowChats.Size = new System.Drawing.Size(169, 23);
            this.buttonShowChats.TabIndex = 40;
            this.buttonShowChats.Text = "Yorumları Göster";
            this.buttonShowChats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonShowChats.UseVisualStyleBackColor = true;
            this.buttonShowChats.Click += new System.EventHandler(this.buttonShowChats_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1027, 638);
            this.Controls.Add(this.splitContainerDikey);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Derin Bilgi - YouTube Canlı Yayın Analizi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.splitContainerDikey.Panel1.ResumeLayout(false);
            this.splitContainerDikey.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDikey)).EndInit();
            this.splitContainerDikey.ResumeLayout(false);
            this.tabControlLeftMenu.ResumeLayout(false);
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageVideo.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLive.ResumeLayout(false);
            this.splitContainerYatay.Panel1.ResumeLayout(false);
            this.splitContainerYatay.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerYatay)).EndInit();
            this.splitContainerYatay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwLiveVideos)).EndInit();
            this.tabPageQuestion.ResumeLayout(false);
            this.splitContainerQA.Panel1.ResumeLayout(false);
            this.splitContainerQA.Panel1.PerformLayout();
            this.splitContainerQA.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQA)).EndInit();
            this.splitContainerQA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).EndInit();
            this.tabPageAnalysis.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompetitionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompetitionHeader)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanelWinnerOfDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwWinnerDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwWinnerOfDay)).EndInit();
            this.tabPageChats.ResumeLayout(false);
            this.tableLayoutPanelChats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwChats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStreams)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.SplitContainer splitContainerDikey;
        private System.Windows.Forms.TabControl tabControlLeftMenu;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.RichTextBox richTextBoxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabelChannelId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBoxEndTime;
        private System.Windows.Forms.RichTextBox richTextBoxStartTime;
        private System.Windows.Forms.RichTextBox richTextBoxPuslishedAt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAsync;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbWorking;
        private System.Windows.Forms.RichTextBox textBoxLiveChatId;
        private System.Windows.Forms.RichTextBox textBoxVideoId;
        private System.Windows.Forms.Button buttonQuestionStart;
        private System.Windows.Forms.Button buttonQuestionStop;
        private System.Windows.Forms.TextBox textBoxQuestionStartAt;
        private System.Windows.Forms.TextBox textBoxQuestionStopAt;
        private System.Windows.Forms.RichTextBox richTextBoxScheduledStartTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBoxQuestion;
        private System.Windows.Forms.Label labelQuestionId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLive;
        private System.Windows.Forms.TabPage tabPageQuestion;
        private System.Windows.Forms.DataGridView dgwAnswers;
        private System.Windows.Forms.SplitContainer splitContainerQA;
        private System.Windows.Forms.SplitContainer splitContainerYatay;
        private System.Windows.Forms.CheckBox checkBoxLiveOnly;
        private System.Windows.Forms.Button buttonGetLiveBroadCasts;
        private System.Windows.Forms.DataGridView dgwLiveVideos;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelUrl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsVerified;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChatOwner;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChatSponsor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChatModerator;
        private System.Windows.Forms.TabPage tabPageAnalysis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtReport;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgwWinnerOfDay;
        private System.Windows.Forms.DataGridView dgwCompetitionDetail;
        private System.Windows.Forms.DataGridView dgwCompetitionHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWinnerOfDay;
        private System.Windows.Forms.DataGridView dgwWinnerDetail;
        private System.Windows.Forms.TabPage tabPageChats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChats;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgwChats;
        private System.Windows.Forms.DataGridView dgwStreams;
        private System.Windows.Forms.Button buttonShowChats;
        private System.Windows.Forms.Button buttonShowStreams;
        private System.Windows.Forms.Label labelChatCount;
        private System.Windows.Forms.Label labelCalisiyorMesaj;
        private System.Windows.Forms.TextBox richTextBoxAnswers;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timerViewerCount;
        private System.Windows.Forms.DateTimePicker dtAllStreams;
        private System.Windows.Forms.Label labelStreamsSaving;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsButtonNewQuestions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButtonShowQList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButtonQuestionList;
    }
}