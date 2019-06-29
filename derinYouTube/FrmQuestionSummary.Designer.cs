namespace derinYouTube
{
    partial class FrmQuestionSummary
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
            this.lwResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelQuestion = new System.Windows.Forms.Label();
            this.lwDaySummary = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelDaySummary = new System.Windows.Forms.Label();
            this.pictureBoxOrder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // lwResult
            // 
            this.lwResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwResult.BackColor = System.Drawing.SystemColors.Control;
            this.lwResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lwResult.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lwResult.FullRowSelect = true;
            this.lwResult.GridLines = true;
            this.lwResult.HideSelection = false;
            this.lwResult.Location = new System.Drawing.Point(12, 52);
            this.lwResult.MultiSelect = false;
            this.lwResult.Name = "lwResult";
            this.lwResult.Size = new System.Drawing.Size(551, 206);
            this.lwResult.TabIndex = 2;
            this.lwResult.UseCompatibleStateImageBehavior = false;
            this.lwResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sıra";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Yarışmacı";
            this.columnHeader2.Width = 336;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Puan";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 143;
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestion.Location = new System.Drawing.Point(69, 7);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(494, 42);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "Soru....";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lwDaySummary
            // 
            this.lwDaySummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwDaySummary.BackColor = System.Drawing.SystemColors.Control;
            this.lwDaySummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwDaySummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lwDaySummary.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lwDaySummary.FullRowSelect = true;
            this.lwDaySummary.GridLines = true;
            this.lwDaySummary.HideSelection = false;
            this.lwDaySummary.Location = new System.Drawing.Point(12, 306);
            this.lwDaySummary.MultiSelect = false;
            this.lwDaySummary.Name = "lwDaySummary";
            this.lwDaySummary.Size = new System.Drawing.Size(551, 206);
            this.lwDaySummary.TabIndex = 4;
            this.lwDaySummary.UseCompatibleStateImageBehavior = false;
            this.lwDaySummary.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sıra";
            this.columnHeader4.Width = 62;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Yarışmacı";
            this.columnHeader5.Width = 336;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Puan";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 143;
            // 
            // labelDaySummary
            // 
            this.labelDaySummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDaySummary.BackColor = System.Drawing.Color.SteelBlue;
            this.labelDaySummary.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDaySummary.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDaySummary.Location = new System.Drawing.Point(12, 261);
            this.labelDaySummary.Name = "labelDaySummary";
            this.labelDaySummary.Size = new System.Drawing.Size(551, 42);
            this.labelDaySummary.TabIndex = 5;
            this.labelDaySummary.Text = "Günün Birincisi Sıralaması";
            this.labelDaySummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxOrder
            // 
            this.pictureBoxOrder.Image = global::derinYouTube.Properties.Resources._1;
            this.pictureBoxOrder.InitialImage = global::derinYouTube.Properties.Resources._1;
            this.pictureBoxOrder.Location = new System.Drawing.Point(12, 7);
            this.pictureBoxOrder.Name = "pictureBoxOrder";
            this.pictureBoxOrder.Size = new System.Drawing.Size(40, 42);
            this.pictureBoxOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOrder.TabIndex = 1;
            this.pictureBoxOrder.TabStop = false;
            // 
            // FrmQuestionSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 524);
            this.Controls.Add(this.labelDaySummary);
            this.Controls.Add(this.lwDaySummary);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.lwResult);
            this.Controls.Add(this.pictureBoxOrder);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmQuestionSummary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuestionSummary_FormClosing);
            this.Load += new System.EventHandler(this.FrmQuestionSummary_Load);
            this.Shown += new System.EventHandler(this.FrmQuestionSummary_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmQuestionSummary_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOrder;
        private System.Windows.Forms.ListView lwResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.ListView lwDaySummary;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label labelDaySummary;
    }
}