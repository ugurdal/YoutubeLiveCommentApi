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
            this.components = new System.ComponentModel.Container();
            this.lwDaySummary = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelDaySummary = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSizes = new System.Windows.Forms.Label();
            this.lwDaySummaryAll = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerShowAll = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lwDaySummary
            // 
            this.lwDaySummary.BackColor = System.Drawing.SystemColors.Control;
            this.lwDaySummary.BackgroundImage = global::derinYouTube.Properties.Resources.M_YARISMA_BACKGROUND;
            this.lwDaySummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwDaySummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6});
            this.lwDaySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDaySummary.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lwDaySummary.ForeColor = System.Drawing.SystemColors.Window;
            this.lwDaySummary.FullRowSelect = true;
            this.lwDaySummary.Location = new System.Drawing.Point(0, 0);
            this.lwDaySummary.MultiSelect = false;
            this.lwDaySummary.Name = "lwDaySummary";
            this.lwDaySummary.Size = new System.Drawing.Size(857, 535);
            this.lwDaySummary.TabIndex = 4;
            this.lwDaySummary.UseCompatibleStateImageBehavior = false;
            this.lwDaySummary.View = System.Windows.Forms.View.Details;
            this.lwDaySummary.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lwDaySummary_ColumnWidthChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sıra";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "SIRA";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "YARIŞMACI";
            this.columnHeader5.Width = 531;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PUAN";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 143;
            // 
            // labelDaySummary
            // 
            this.labelDaySummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(94)))), ((int)(((byte)(18)))));
            this.labelDaySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDaySummary.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDaySummary.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDaySummary.Location = new System.Drawing.Point(0, 0);
            this.labelDaySummary.Name = "labelDaySummary";
            this.labelDaySummary.Size = new System.Drawing.Size(857, 114);
            this.labelDaySummary.TabIndex = 5;
            this.labelDaySummary.Text = "GÜNÜN BİRİNCİLİĞİ SIRALAMASI";
            this.labelDaySummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 681);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 114);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSizes);
            this.panel1.Controls.Add(this.labelDaySummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 114);
            this.panel1.TabIndex = 6;
            // 
            // labelSizes
            // 
            this.labelSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSizes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(94)))), ((int)(((byte)(18)))));
            this.labelSizes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelSizes.Location = new System.Drawing.Point(757, 61);
            this.labelSizes.Name = "labelSizes";
            this.labelSizes.Size = new System.Drawing.Size(100, 53);
            this.labelSizes.TabIndex = 6;
            this.labelSizes.Text = "label1";
            this.labelSizes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lwDaySummaryAll
            // 
            this.lwDaySummaryAll.BackColor = System.Drawing.SystemColors.Control;
            this.lwDaySummaryAll.BackgroundImage = global::derinYouTube.Properties.Resources.M_YARISMA_BACKGROUND;
            this.lwDaySummaryAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwDaySummaryAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7});
            this.lwDaySummaryAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDaySummaryAll.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lwDaySummaryAll.ForeColor = System.Drawing.SystemColors.Window;
            this.lwDaySummaryAll.FullRowSelect = true;
            this.lwDaySummaryAll.Location = new System.Drawing.Point(0, 0);
            this.lwDaySummaryAll.MultiSelect = false;
            this.lwDaySummaryAll.Name = "lwDaySummaryAll";
            this.lwDaySummaryAll.Size = new System.Drawing.Size(857, 535);
            this.lwDaySummaryAll.TabIndex = 5;
            this.lwDaySummaryAll.UseCompatibleStateImageBehavior = false;
            this.lwDaySummaryAll.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sıra";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SIRA";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "YARIŞMACI";
            this.columnHeader3.Width = 531;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "PUAN";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 143;
            // 
            // timerShowAll
            // 
            this.timerShowAll.Interval = 1000;
            this.timerShowAll.Tick += new System.EventHandler(this.timerShowAll_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lwDaySummary);
            this.panel2.Controls.Add(this.lwDaySummaryAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 535);
            this.panel2.TabIndex = 6;
            // 
            // FrmQuestionSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmQuestionSummary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuestionSummary_FormClosing);
            this.Load += new System.EventHandler(this.FrmQuestionSummary_Load);
            this.Shown += new System.EventHandler(this.FrmQuestionSummary_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmQuestionSummary_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lwDaySummary;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label labelDaySummary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSizes;
        private System.Windows.Forms.ListView lwDaySummaryAll;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Timer timerShowAll;
        private System.Windows.Forms.Panel panel2;
    }
}