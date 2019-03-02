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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonNewQuestions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwQ)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwQ
            // 
            this.dgwQ.AllowUserToAddRows = false;
            this.dgwQ.AllowUserToDeleteRows = false;
            this.dgwQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwQ.Location = new System.Drawing.Point(7, 149);
            this.dgwQ.Name = "dgwQ";
            this.dgwQ.ReadOnly = true;
            this.dgwQ.Size = new System.Drawing.Size(743, 302);
            this.dgwQ.TabIndex = 0;
            this.dgwQ.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwQ_CellDoubleClick);
            this.dgwQ.SelectionChanged += new System.EventHandler(this.dgwQ_SelectionChanged);
            // 
            // richTextBoxAnswers
            // 
            this.richTextBoxAnswers.Location = new System.Drawing.Point(57, 103);
            this.richTextBoxAnswers.Name = "richTextBoxAnswers";
            this.richTextBoxAnswers.Size = new System.Drawing.Size(101, 21);
            this.richTextBoxAnswers.TabIndex = 17;
            this.richTextBoxAnswers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxAnswers_KeyPress);
            // 
            // labelQ
            // 
            this.labelQ.AutoSize = true;
            this.labelQ.Location = new System.Drawing.Point(21, 41);
            this.labelQ.Name = "labelQ";
            this.labelQ.Size = new System.Drawing.Size(29, 13);
            this.labelQ.TabIndex = 15;
            this.labelQ.Text = "Soru";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(12, 106);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(38, 13);
            this.labelA.TabIndex = 16;
            this.labelA.Text = "Cevap";
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxQuestion.Location = new System.Drawing.Point(56, 41);
            this.richTextBoxQuestion.MaxLength = 1000;
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.Size = new System.Drawing.Size(377, 56);
            this.richTextBoxQuestion.TabIndex = 14;
            this.richTextBoxQuestion.Text = "";
            // 
            // labelCount
            // 
            this.labelCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCount.Location = new System.Drawing.Point(650, 123);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(100, 23);
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
            this.buttonClose.Location = new System.Drawing.Point(652, 467);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(98, 34);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Kapat";
            this.buttonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::derinYouTube.Properties.Resources.Clearallrequests_8816;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDelete.Location = new System.Drawing.Point(332, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(101, 33);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Text = "Seçilileri Sil";
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::derinYouTube.Properties.Resources.saveHS;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.Location = new System.Drawing.Point(332, 103);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(101, 33);
            this.buttonAdd.TabIndex = 18;
            this.buttonAdd.Text = "Kaydet";
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonNewQuestions
            // 
            this.buttonNewQuestions.Image = global::derinYouTube.Properties.Resources.AddTableHS;
            this.buttonNewQuestions.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonNewQuestions.Location = new System.Drawing.Point(56, 7);
            this.buttonNewQuestions.Name = "buttonNewQuestions";
            this.buttonNewQuestions.Size = new System.Drawing.Size(101, 33);
            this.buttonNewQuestions.TabIndex = 2;
            this.buttonNewQuestions.Text = "Yeni Soru";
            this.buttonNewQuestions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNewQuestions.UseVisualStyleBackColor = true;
            this.buttonNewQuestions.Click += new System.EventHandler(this.buttonNewQuestions_Click);
            // 
            // FrmQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(754, 513);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.richTextBoxAnswers);
            this.Controls.Add(this.richTextBoxQuestion);
            this.Controls.Add(this.labelQ);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.buttonNewQuestions);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dgwQ);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soru Hazırla";
            this.Load += new System.EventHandler(this.FrmQuestions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwQ;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonNewQuestions;
        private System.Windows.Forms.TextBox richTextBoxAnswers;
        private System.Windows.Forms.Label labelQ;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.RichTextBox richTextBoxQuestion;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonDelete;
    }
}