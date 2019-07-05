using derinYouTube.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derinYouTube
{
    public partial class FrmQuestionSummary : Form
    {
        private bool _loaded;

        public enum ViewType
        {
            Day = 0,
            Week = 1,
            Both = 2
        }

        public FrmQuestionSummary()
        {
            InitializeComponent();
            SetDoubleBuffered(this);
            SetDoubleBuffered(this.tableLayoutPanel1);
            SetDoubleBuffered(this.lwDaySummary);
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            var aProp = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FrmQuestionSummary_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            lwDaySummary.Columns[0].Width = Properties.Settings.Default.LwCol1Width;
            lwDaySummary.Columns[1].Width = Properties.Settings.Default.LwCol2Width;
            lwDaySummary.Columns[2].Width = Properties.Settings.Default.LwCol3Width;
            lwDaySummary.Columns[3].Width = Properties.Settings.Default.LwCol4Width;
        }

        private void SetTableLayoutSizes(ViewType layout)
        {
            /*
            switch (layout)
            {
                case ViewType.Both:
                    tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[0].Height = 100F;

                    tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[1].Height = 50F;

                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[2].Height = 80F;

                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[3].Height = 50F;
                    break;
                case ViewType.Day:
                case ViewType.Week:
                    tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[0].Height = 0F;
                    tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[1].Height = 0F;

                    tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                    tableLayoutPanel1.RowStyles[2].Height = 100F;
                    tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[3].Height = 100F;
                    break;
            }
            SetListViewSize();
            */
        }

        public void ShowResults(ShowResultModel model)
        {
            /*
            switch (model.Sequence)
            {
                case 1:
                    pictureBoxOrder.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBoxOrder.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBoxOrder.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBoxOrder.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBoxOrder.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBoxOrder.Image = Properties.Resources._6;
                    break;
                case 7:
                    pictureBoxOrder.Image = Properties.Resources._7;
                    break;
                case 8:
                    pictureBoxOrder.Image = Properties.Resources._8;
                    break;
                case 9:
                    pictureBoxOrder.Image = Properties.Resources._9;
                    break;
                case 10:
                    pictureBoxOrder.Image = Properties.Resources._10;
                    break;
            }
            */

            //SetTableLayoutSizes(ViewType.Week);
            //labelQuestion.Text = model.Question;
            //lwResult.Items.Clear();
            lwDaySummary.Items.Clear();
            lwDaySummary.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
            labelDaySummary.Text = "GÜNÜN BİRİNCİSİ SIRALAMASI";
            labelDaySummary.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
            //pictureBoxOrder.Visible = true;
            //labelQuestion.Visible = true;
            //lwResult.Visible = true;

            var ix = 1;
            //if (model.Results != null)
            //{
            //    foreach (var item in model.Results.OrderByDescending(x => x.Score))
            //    {
            //        if (ix > 5)
            //            break;

            //        var lwItm = lwResult.Items.Add(item.Sequence.ToString());
            //        lwItm.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
            //        lwItm.SubItems.Add(item.Sequence.ToString());
            //        lwItm.SubItems.Add(item.DisplayName.ToUpper());
            //        lwItm.SubItems.Add(item.Score.ToString());
            //        ix++;
            //    }
            //}

            //Son soruda günün birinliğini kapatıyoruz.
            //labelDaySummary.Visible = model.Sequence != 10;
            //lwDaySummary.Visible = model.Sequence != 10;

            ix = 1;
            if (model.CurrentWinners != null)
            {
                foreach (var item in model.CurrentWinners.OrderByDescending(x => x.TotalScore))
                {
                    if (ix > 5)
                        break;

                    var lwItm = lwDaySummary.Items.Add(item.Sequence.ToString());
                    lwItm.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
                    lwItm.SubItems.Add(item.Sequence.ToString());
                    lwItm.SubItems.Add(item.DisplayName.ToUpper());
                    lwItm.SubItems.Add(item.TotalScore.ToString());
                    ix++;
                }
            }
        }

        public void ShowWinners(List<WinnerOfDayModel> model, ViewType type)
        {
            //SetTableLayoutSizes(type);
            lwDaySummary.Items.Clear();
            labelDaySummary.Text = type == ViewType.Day
                ? "GÜNÜN BİRİNCİSİ SIRALAMASI"
                : "HAFTANIN BİRİNCİSİ SIRALAMASI";
            lwDaySummary.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
            labelDaySummary.Font = new Font("Segoe UI", 50f, FontStyle.Bold);

            var ix = 1;
            if (model != null)
            {
                foreach (var item in model.OrderByDescending(x => x.TotalScore))
                {
                    if (ix > 5)
                        break;

                    var lwItm = lwDaySummary.Items.Add(item.Sequence.ToString());
                    lwItm.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
                    lwItm.SubItems.Add(item.Sequence.ToString());
                    lwItm.SubItems.Add(item.DisplayName.ToUpper());
                    lwItm.SubItems.Add(item.TotalScore.ToString());
                    ix++;
                }
            }
        }

        private void FrmQuestionSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LwCol1Width = 0;
            Properties.Settings.Default.LwCol2Width = lwDaySummary.Columns[1].Width;
            Properties.Settings.Default.LwCol3Width = lwDaySummary.Columns[2].Width;
            Properties.Settings.Default.LwCol4Width = lwDaySummary.Columns[3].Width;
            Properties.Settings.Default.Save();
            this.Hide();
            e.Cancel = true;
        }

        private void FrmQuestionSummary_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmQuestionSummary_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
