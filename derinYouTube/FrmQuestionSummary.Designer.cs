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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lwResult
            // 
            this.lwResult.BackColor = System.Drawing.SystemColors.Control;
            this.lwResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lwResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwResult.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lwResult.FullRowSelect = true;
            this.lwResult.GridLines = true;
            this.lwResult.HideSelection = false;
            this.lwResult.Location = new System.Drawing.Point(0, 0);
            this.lwResult.MultiSelect = false;
            this.lwResult.Name = "lwResult";
            this.lwResult.Size = new System.Drawing.Size(787, 244);
            this.lwResult.TabIndex = 2;
            this.lwResult.UseCompatibleStateImageBehavior = false;
            this.lwResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sıra";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Yarışmacı";
            this.columnHeader2.Width = 336;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Puan";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 143;
            // 
            // labelQuestion
            // 
            this.labelQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQuestion.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelQuestion.Location = new System.Drawing.Point(82, 3);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(702, 88);
            this.labelQuestion.TabIndex = 3;
            this.labelQuestion.Text = "Soru....";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lwDaySummary
            // 
            this.lwDaySummary.BackColor = System.Drawing.SystemColors.Control;
            this.lwDaySummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwDaySummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lwDaySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDaySummary.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lwDaySummary.FullRowSelect = true;
            this.lwDaySummary.GridLines = true;
            this.lwDaySummary.HideSelection = false;
            this.lwDaySummary.Location = new System.Drawing.Point(3, 433);
            this.lwDaySummary.MultiSelect = false;
            this.lwDaySummary.Name = "lwDaySummary";
            this.lwDaySummary.Size = new System.Drawing.Size(787, 245);
            this.lwDaySummary.TabIndex = 4;
            this.lwDaySummary.UseCompatibleStateImageBehavior = false;
            this.lwDaySummary.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sıra";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 104;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Yarışmacı";
            this.columnHeader5.Width = 531;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Puan";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 143;
            // 
            // labelDaySummary
            // 
            this.labelDaySummary.BackColor = System.Drawing.Color.SteelBlue;
            this.labelDaySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDaySummary.Font = new System.Drawing.Font("Segoe UI", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDaySummary.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDaySummary.Location = new System.Drawing.Point(0, 0);
            this.labelDaySummary.Name = "labelDaySummary";
            this.labelDaySummary.Size = new System.Drawing.Size(787, 74);
            this.labelDaySummary.TabIndex = 5;
            this.labelDaySummary.Text = "GÜNÜN BİRİNCİLİĞİ SIRALAMASI";
            this.labelDaySummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxOrder
            // 
            this.pictureBoxOrder.Image = global::derinYouTube.Properties.Resources._1;
            this.pictureBoxOrder.InitialImage = global::derinYouTube.Properties.Resources._1;
            this.pictureBoxOrder.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxOrder.Name = "pictureBoxOrder";
            this.pictureBoxOrder.Size = new System.Drawing.Size(73, 88);
            this.pictureBoxOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOrder.TabIndex = 1;
            this.pictureBoxOrder.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lwDaySummary, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 681);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxOrder);
            this.panel1.Controls.Add(this.labelQuestion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 94);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lwResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 244);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelDaySummary);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 353);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(787, 74);
            this.panel3.TabIndex = 2;
            // 
            // FrmQuestionSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmQuestionSummary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuestionSummary_FormClosing);
            this.Load += new System.EventHandler(this.FrmQuestionSummary_Load);
            this.Shown += new System.EventHandler(this.FrmQuestionSummary_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmQuestionSummary_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}