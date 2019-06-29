namespace derinYouTube
{
    partial class FrmQuestions
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
            this.dgwQ = new System.Windows.Forms.DataGridView();
            this.richTextBoxAnswers = new System.Windows.Forms.TextBox();
            this.labelQ = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.richTextBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsButtonSave = new System.Windows.Forms.ToolStripButton();
            this.tsButtonNew = new System.Windows.Forms.ToolStripButton();
            this.tsButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.splitContainerQ = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.dtQuestionDate = new System.Windows.Forms.DateTimePicker();
            this.numOrder = new System.Windows.Forms.NumericUpDown();
            this.labelOrder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQ)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQ)).BeginInit();
            this.splitContainerQ.Panel1.SuspendLayout();
            this.splitContainerQ.Panel2.SuspendLayout();
            this.splitContainerQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwQ
            // 
            this.dgwQ.AllowUserToAddRows = false;
            this.dgwQ.AllowUserToDeleteRows = false;
            this.dgwQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwQ.Location = new System.Drawing.Point(0, 0);
            this.dgwQ.Name = "dgwQ";
            this.dgwQ.ReadOnly = true;
            this.dgwQ.Size = new System.Drawing.Size(870, 355);
            this.dgwQ.TabIndex = 0;
            this.dgwQ.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQ_CellDoubleClick);
            this.dgwQ.SelectionChanged += new System.EventHandler(this.dgwQ_SelectionChanged);
            // 
            // richTextBoxAnswers
            // 
            this.richTextBoxAnswers.Location = new System.Drawing.Point(66, 112);
            this.richTextBoxAnswers.Name = "richTextBoxAnswers";
            this.richTextBoxAnswers.Size = new System.Drawing.Size(117, 23);
            this.richTextBoxAnswers.TabIndex = 17;
            this.richTextBoxAnswers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxAnswers_KeyPress);
            // 
            // labelQ
            // 
            this.labelQ.AutoSize = true;
            this.labelQ.Location = new System.Drawing.Point(24, 43);
            this.labelQ.Name = "labelQ";
            this.labelQ.Size = new System.Drawing.Size(31, 15);
            this.labelQ.TabIndex = 15;
            this.labelQ.Text = "Soru";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(14, 115);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(40, 15);
            this.labelA.TabIndex = 16;
            this.labelA.Text = "Cevap";
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxQuestion.Location = new System.Drawing.Point(66, 40);
            this.richTextBoxQuestion.MaxLength = 1000;
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.Size = new System.Drawing.Size(439, 64);
            this.richTextBoxQuestion.TabIndex = 14;
            this.richTextBoxQuestion.Text = "";
            // 
            // labelCount
            // 
            this.labelCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCount.Location = new System.Drawing.Point(744, 78);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(117, 27);
            this.labelCount.TabIndex = 19;
            this.labelCount.Text = "0";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Image = global::derinYouTube.Properties.Resources.OK;
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClose.Location = new System.Drawing.Point(761, 539);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(114, 39);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Kapat";
            this.buttonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonSave,
            this.tsButtonNew,
            this.tsButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(880, 25);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsButtonSave
            // 
            this.tsButtonSave.Image = global::derinYouTube.Properties.Resources.saveHS;
            this.tsButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonSave.Name = "tsButtonSave";
            this.tsButtonSave.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsButtonSave.Size = new System.Drawing.Size(73, 22);
            this.tsButtonSave.Text = "Kaydet";
            this.tsButtonSave.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tsButtonNew
            // 
            this.tsButtonNew.Image = global::derinYouTube.Properties.Resources.AddTableHS;
            this.tsButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonNew.Name = "tsButtonNew";
            this.tsButtonNew.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsButtonNew.Size = new System.Drawing.Size(86, 22);
            this.tsButtonNew.Text = "Yeni Soru";
            this.tsButtonNew.Click += new System.EventHandler(this.buttonNewQuestions_Click);
            // 
            // tsButtonDelete
            // 
            this.tsButtonDelete.Image = global::derinYouTube.Properties.Resources.Clearallrequests_8816;
            this.tsButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonDelete.Name = "tsButtonDelete";
            this.tsButtonDelete.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsButtonDelete.Size = new System.Drawing.Size(95, 22);
            this.tsButtonDelete.Text = "Seçilileri Sil";
            this.tsButtonDelete.Visible = false;
            this.tsButtonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // splitContainerQ
            // 
            this.splitContainerQ.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerQ.IsSplitterFixed = true;
            this.splitContainerQ.Location = new System.Drawing.Point(5, 32);
            this.splitContainerQ.Name = "splitContainerQ";
            this.splitContainerQ.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerQ.Panel1
            // 
            this.splitContainerQ.Panel1.Controls.Add(this.label1);
            this.splitContainerQ.Panel1.Controls.Add(this.dtQuestionDate);
            this.splitContainerQ.Panel1.Controls.Add(this.numOrder);
            this.splitContainerQ.Panel1.Controls.Add(this.labelOrder);
            this.splitContainerQ.Panel1.Controls.Add(this.labelCount);
            this.splitContainerQ.Panel1.Controls.Add(this.richTextBoxQuestion);
            this.splitContainerQ.Panel1.Controls.Add(this.labelA);
            this.splitContainerQ.Panel1.Controls.Add(this.richTextBoxAnswers);
            this.splitContainerQ.Panel1.Controls.Add(this.labelQ);
            this.splitContainerQ.Panel1MinSize = 0;
            // 
            // splitContainerQ.Panel2
            // 
            this.splitContainerQ.Panel2.Controls.Add(this.dgwQ);
            this.splitContainerQ.Size = new System.Drawing.Size(870, 500);
            this.splitContainerQ.SplitterDistance = 140;
            this.splitContainerQ.SplitterWidth = 5;
            this.splitContainerQ.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tarih";
            // 
            // dtQuestionDate
            // 
            this.dtQuestionDate.Location = new System.Drawing.Point(273, 7);
            this.dtQuestionDate.Name = "dtQuestionDate";
            this.dtQuestionDate.Size = new System.Drawing.Size(233, 23);
            this.dtQuestionDate.TabIndex = 23;
            this.dtQuestionDate.ValueChanged += new System.EventHandler(this.DtQuestionDate_ValueChanged);
            // 
            // numOrder
            // 
            this.numOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numOrder.Location = new System.Drawing.Point(66, 7);
            this.numOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrder.Name = "numOrder";
            this.numOrder.Size = new System.Drawing.Size(70, 22);
            this.numOrder.TabIndex = 22;
            this.numOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Location = new System.Drawing.Point(29, 9);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(26, 15);
            this.labelOrder.TabIndex = 21;
            this.labelOrder.Text = "Sıra";
            // 
            // FrmQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(880, 592);
            this.Controls.Add(this.splitContainerQ);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonClose);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soru Hazırla";
            this.Load += new System.EventHandler(this.FrmQuestions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwQ)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainerQ.Panel1.ResumeLayout(false);
            this.splitContainerQ.Panel1.PerformLayout();
            this.splitContainerQ.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQ)).EndInit();
            this.splitContainerQ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwQ;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox richTextBoxAnswers;
        private System.Windows.Forms.Label labelQ;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.RichTextBox richTextBoxQuestion;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsButtonDelete;
        private System.Windows.Forms.ToolStripButton tsButtonSave;
        private System.Windows.Forms.ToolStripButton tsButtonNew;
        private System.Windows.Forms.SplitContainer splitContainerQ;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.NumericUpDown numOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtQuestionDate;
    }
}