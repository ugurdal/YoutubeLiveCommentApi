namespace derinYouTube
{
    partial class frmCompetitions
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelBack = new System.Windows.Forms.Panel();
            this.buttonPrevius = new System.Windows.Forms.Button();
            this.panelForward = new System.Windows.Forms.Panel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelQuestionCount = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelQuestionId = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxAnswers = new System.Windows.Forms.TextBox();
            this.textBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.pictureBoxOrder = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxAnswerDetails = new System.Windows.Forms.RichTextBox();
            this.labelQuestionTime = new System.Windows.Forms.Label();
            this.buttonQuestionStart = new System.Windows.Forms.Button();
            this.textBoxQuestionStopAt = new System.Windows.Forms.TextBox();
            this.textBoxQuestionStartAt = new System.Windows.Forms.TextBox();
            this.buttonQuestionStop = new System.Windows.Forms.Button();
            this.labelShowError = new System.Windows.Forms.Label();
            this.dgwAnswers = new System.Windows.Forms.DataGridView();
            this.timerQuestion = new System.Windows.Forms.Timer(this.components);
            this.timerException = new System.Windows.Forms.Timer(this.components);
            this.timerCommentAdd = new System.Windows.Forms.Timer(this.components);
            this.timerAnswerCount = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelBack.SuspendLayout();
            this.panelForward.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(892, 547);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelForward, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 106);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelBack
            // 
            this.panelBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelBack.Controls.Add(this.buttonPrevius);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(3, 3);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(44, 100);
            this.panelBack.TabIndex = 0;
            // 
            // buttonPrevius
            // 
            this.buttonPrevius.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrevius.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrevius.Image = global::derinYouTube.Properties.Resources.button_arrow_left_large_1x;
            this.buttonPrevius.Location = new System.Drawing.Point(0, 0);
            this.buttonPrevius.Name = "buttonPrevius";
            this.buttonPrevius.Size = new System.Drawing.Size(44, 100);
            this.buttonPrevius.TabIndex = 1;
            this.buttonPrevius.UseVisualStyleBackColor = true;
            this.buttonPrevius.Click += new System.EventHandler(this.ButtonPrevius_Click);
            // 
            // panelForward
            // 
            this.panelForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelForward.Controls.Add(this.buttonNext);
            this.panelForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForward.Location = new System.Drawing.Point(845, 3);
            this.panelForward.Name = "panelForward";
            this.panelForward.Size = new System.Drawing.Size(44, 100);
            this.panelForward.TabIndex = 1;
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Image = global::derinYouTube.Properties.Resources.button_arrow_right_large_1x;
            this.buttonNext.Location = new System.Drawing.Point(0, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(44, 100);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelQuestionCount);
            this.panel3.Controls.Add(this.labelQuestion);
            this.panel3.Controls.Add(this.labelQuestionId);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.textBoxAnswers);
            this.panel3.Controls.Add(this.textBoxQuestion);
            this.panel3.Controls.Add(this.pictureBoxOrder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(53, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 100);
            this.panel3.TabIndex = 2;
            // 
            // labelQuestionCount
            // 
            this.labelQuestionCount.AutoSize = true;
            this.labelQuestionCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestionCount.Location = new System.Drawing.Point(623, 72);
            this.labelQuestionCount.Name = "labelQuestionCount";
            this.labelQuestionCount.Size = new System.Drawing.Size(17, 19);
            this.labelQuestionCount.TabIndex = 33;
            this.labelQuestionCount.Text = "0";
            this.labelQuestionCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelQuestionCount.Visible = false;
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestion.Location = new System.Drawing.Point(497, 72);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(123, 17);
            this.labelQuestion.TabIndex = 32;
            this.labelQuestion.Text = "Verilen Cevap Sayısı";
            this.labelQuestion.Visible = false;
            // 
            // labelQuestionId
            // 
            this.labelQuestionId.AutoSize = true;
            this.labelQuestionId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestionId.Location = new System.Drawing.Point(374, 72);
            this.labelQuestionId.Name = "labelQuestionId";
            this.labelQuestionId.Size = new System.Drawing.Size(14, 15);
            this.labelQuestionId.TabIndex = 17;
            this.labelQuestionId.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(139, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "Soru";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(130, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 15;
            this.label13.Text = "Cevap";
            // 
            // textBoxAnswers
            // 
            this.textBoxAnswers.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxAnswers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxAnswers.ForeColor = System.Drawing.Color.Red;
            this.textBoxAnswers.Location = new System.Drawing.Point(176, 65);
            this.textBoxAnswers.Name = "textBoxAnswers";
            this.textBoxAnswers.Size = new System.Drawing.Size(192, 27);
            this.textBoxAnswers.TabIndex = 14;
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxQuestion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxQuestion.Location = new System.Drawing.Point(176, 4);
            this.textBoxQuestion.MaxLength = 1000;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.Size = new System.Drawing.Size(607, 56);
            this.textBoxQuestion.TabIndex = 2;
            this.textBoxQuestion.Text = "";
            // 
            // pictureBoxOrder
            // 
            this.pictureBoxOrder.Image = global::derinYouTube.Properties.Resources._1;
            this.pictureBoxOrder.InitialImage = global::derinYouTube.Properties.Resources._1;
            this.pictureBoxOrder.Location = new System.Drawing.Point(19, 20);
            this.pictureBoxOrder.Name = "pictureBoxOrder";
            this.pictureBoxOrder.Size = new System.Drawing.Size(62, 59);
            this.pictureBoxOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOrder.TabIndex = 0;
            this.pictureBoxOrder.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxAnswerDetails);
            this.splitContainer2.Panel1.Controls.Add(this.labelQuestionTime);
            this.splitContainer2.Panel1.Controls.Add(this.buttonQuestionStart);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxQuestionStopAt);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxQuestionStartAt);
            this.splitContainer2.Panel1.Controls.Add(this.buttonQuestionStop);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.labelShowError);
            this.splitContainer2.Panel2.Controls.Add(this.dgwAnswers);
            this.splitContainer2.Size = new System.Drawing.Size(892, 437);
            this.splitContainer2.SplitterDistance = 182;
            this.splitContainer2.TabIndex = 1;
            // 
            // richTextBoxAnswerDetails
            // 
            this.richTextBoxAnswerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAnswerDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxAnswerDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxAnswerDetails.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxAnswerDetails.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxAnswerDetails.Location = new System.Drawing.Point(5, 217);
            this.richTextBoxAnswerDetails.MaxLength = 1000;
            this.richTextBoxAnswerDetails.Name = "richTextBoxAnswerDetails";
            this.richTextBoxAnswerDetails.ReadOnly = true;
            this.richTextBoxAnswerDetails.Size = new System.Drawing.Size(174, 217);
            this.richTextBoxAnswerDetails.TabIndex = 27;
            this.richTextBoxAnswerDetails.Text = "";
            // 
            // labelQuestionTime
            // 
            this.labelQuestionTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelQuestionTime.AutoSize = true;
            this.labelQuestionTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestionTime.Location = new System.Drawing.Point(80, 94);
            this.labelQuestionTime.Name = "labelQuestionTime";
            this.labelQuestionTime.Size = new System.Drawing.Size(18, 20);
            this.labelQuestionTime.TabIndex = 26;
            this.labelQuestionTime.Text = "0";
            // 
            // buttonQuestionStart
            // 
            this.buttonQuestionStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuestionStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQuestionStart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonQuestionStart.Location = new System.Drawing.Point(3, 3);
            this.buttonQuestionStart.Name = "buttonQuestionStart";
            this.buttonQuestionStart.Size = new System.Drawing.Size(176, 41);
            this.buttonQuestionStart.TabIndex = 10;
            this.buttonQuestionStart.Text = "Soruyu Başlat";
            this.buttonQuestionStart.UseVisualStyleBackColor = true;
            this.buttonQuestionStart.Click += new System.EventHandler(this.ButtonQuestionStart_Click);
            // 
            // textBoxQuestionStopAt
            // 
            this.textBoxQuestionStopAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestionStopAt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxQuestionStopAt.Location = new System.Drawing.Point(4, 171);
            this.textBoxQuestionStopAt.Multiline = true;
            this.textBoxQuestionStopAt.Name = "textBoxQuestionStopAt";
            this.textBoxQuestionStopAt.ReadOnly = true;
            this.textBoxQuestionStopAt.Size = new System.Drawing.Size(176, 40);
            this.textBoxQuestionStopAt.TabIndex = 13;
            // 
            // textBoxQuestionStartAt
            // 
            this.textBoxQuestionStartAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestionStartAt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxQuestionStartAt.Location = new System.Drawing.Point(3, 50);
            this.textBoxQuestionStartAt.Multiline = true;
            this.textBoxQuestionStartAt.Name = "textBoxQuestionStartAt";
            this.textBoxQuestionStartAt.ReadOnly = true;
            this.textBoxQuestionStartAt.Size = new System.Drawing.Size(176, 41);
            this.textBoxQuestionStartAt.TabIndex = 12;
            // 
            // buttonQuestionStop
            // 
            this.buttonQuestionStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuestionStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQuestionStop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonQuestionStop.Location = new System.Drawing.Point(4, 125);
            this.buttonQuestionStop.Name = "buttonQuestionStop";
            this.buttonQuestionStop.Size = new System.Drawing.Size(176, 40);
            this.buttonQuestionStop.TabIndex = 11;
            this.buttonQuestionStop.Text = "Soruyu Bitir";
            this.buttonQuestionStop.UseVisualStyleBackColor = true;
            this.buttonQuestionStop.Click += new System.EventHandler(this.ButtonQuestionStop_Click);
            // 
            // labelShowError
            // 
            this.labelShowError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelShowError.BackColor = System.Drawing.Color.DarkRed;
            this.labelShowError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelShowError.ForeColor = System.Drawing.SystemColors.Window;
            this.labelShowError.Location = new System.Drawing.Point(474, 244);
            this.labelShowError.Name = "labelShowError";
            this.labelShowError.Size = new System.Drawing.Size(220, 184);
            this.labelShowError.TabIndex = 14;
            this.labelShowError.Visible = false;
            // 
            // dgwAnswers
            // 
            this.dgwAnswers.AllowUserToAddRows = false;
            this.dgwAnswers.AllowUserToDeleteRows = false;
            this.dgwAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwAnswers.Location = new System.Drawing.Point(0, 0);
            this.dgwAnswers.Name = "dgwAnswers";
            this.dgwAnswers.ReadOnly = true;
            this.dgwAnswers.Size = new System.Drawing.Size(706, 437);
            this.dgwAnswers.TabIndex = 0;
            // 
            // timerQuestion
            // 
            this.timerQuestion.Enabled = true;
            this.timerQuestion.Interval = 1000;
            this.timerQuestion.Tick += new System.EventHandler(this.TimerQuestion_Tick);
            // 
            // timerException
            // 
            this.timerException.Enabled = true;
            this.timerException.Interval = 5000;
            this.timerException.Tick += new System.EventHandler(this.TimerException_Tick);
            // 
            // timerCommentAdd
            // 
            this.timerCommentAdd.Enabled = true;
            this.timerCommentAdd.Interval = 20000;
            this.timerCommentAdd.Tick += new System.EventHandler(this.TimerCommentAdd_Tick);
            // 
            // timerAnswerCount
            // 
            this.timerAnswerCount.Enabled = true;
            this.timerAnswerCount.Interval = 5000;
            this.timerAnswerCount.Tick += new System.EventHandler(this.TimerAnswerCount_Tick);
            // 
            // frmCompetitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 547);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "frmCompetitions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCompetitions_FormClosing);
            this.Load += new System.EventHandler(this.FrmCompetitions_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelBack.ResumeLayout(false);
            this.panelForward.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnswers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Panel panelForward;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgwAnswers;
        private System.Windows.Forms.TextBox textBoxQuestionStopAt;
        private System.Windows.Forms.Button buttonQuestionStop;
        private System.Windows.Forms.Button buttonQuestionStart;
        private System.Windows.Forms.TextBox textBoxQuestionStartAt;
        private System.Windows.Forms.Label labelQuestionTime;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBoxAnswerDetails;
        private System.Windows.Forms.PictureBox pictureBoxOrder;
        private System.Windows.Forms.RichTextBox textBoxQuestion;
        private System.Windows.Forms.TextBox textBoxAnswers;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelQuestionId;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevius;
        private System.Windows.Forms.Timer timerQuestion;
        private System.Windows.Forms.Label labelShowError;
        private System.Windows.Forms.Timer timerException;
        private System.Windows.Forms.Timer timerCommentAdd;
        private System.Windows.Forms.Label labelQuestionCount;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Timer timerAnswerCount;
    }
}