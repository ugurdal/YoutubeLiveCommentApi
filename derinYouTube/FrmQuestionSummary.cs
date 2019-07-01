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
        public enum ViewType
        {
            Day = 0,
            Week = 1
        }

        public FrmQuestionSummary()
        {
            InitializeComponent();
            //this.MinimumSize = this.Size;
        }

        private void FrmQuestionSummary_Load(object sender, EventArgs e)
        {
        }

        public void ShowResults(ShowResultModel model)
        {
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

            labelQuestion.Text = model.Question;
            lwResult.Items.Clear();
            lwDaySummary.Items.Clear();
            labelDaySummary.Text = "Günün Birincisi Sıralaması";
            pictureBoxOrder.Visible = true;
            labelQuestion.Visible = true;
            lwResult.Visible = true;

            var ix = 1;
            if (model.Results != null)
            {
                foreach (var item in model.Results.OrderByDescending(x => x.Score))
                {
                    if (ix > 5)
                        break;

                    var lwItm = lwResult.Items.Add(item.Sequence.ToString());
                    lwItm.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
                    lwItm.SubItems.Add(item.DisplayName.ToUpperInvariant());
                    lwItm.SubItems.Add(item.Score.ToString());
                    ix++;
                }
            }

            //Son soruda günün birinliğini kapatıyoruz.
            labelDaySummary.Visible = model.Sequence != 10;
            lwDaySummary.Visible = model.Sequence != 10;

            ix = 1;
            if (model.CurrentWinners != null)
            {
                foreach (var item in model.CurrentWinners.OrderByDescending(x => x.TotalScore))
                {
                    if (ix > 5)
                        break;

                    var lwItm = lwDaySummary.Items.Add(item.Sequence.ToString());
                    lwItm.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
                    lwItm.SubItems.Add(item.DisplayName.ToUpperInvariant());
                    lwItm.SubItems.Add(item.TotalScore.ToString());
                    ix++;
                }
            }
        }

        public void ShowWinners(List<WinnerOfDayModel> model, ViewType type)
        {
            labelDaySummary.Text = type == ViewType.Day 
                ? "Günün Birincisi Sıralaması"
                : "Haftanın Birincisi Sıralaması";
            pictureBoxOrder.Visible = false;
            labelQuestion.Visible = false;
            lwResult.Visible = false;
            lwDaySummary.Items.Clear();

            var ix = 1;
            if (model != null)
            {
                foreach (var item in model.OrderByDescending(x => x.TotalScore))
                {
                    if (ix > 5)
                        break;

                    var lwItm = lwDaySummary.Items.Add(item.Sequence.ToString());
                    lwItm.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
                    lwItm.SubItems.Add(item.DisplayName.ToUpperInvariant());
                    lwItm.SubItems.Add(item.TotalScore.ToString());
                    ix++;
                }
            }
        }

        private void FrmQuestionSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void FrmQuestionSummary_SizeChanged(object sender, EventArgs e)
        {
            SetListViewSize();
        }

        private void SetListViewSize()
        {
            var width = lwResult.Size.Width - 10;
            lwResult.Columns[0].Width = Convert.ToInt32(width / 100.0 * 10.0);
            lwResult.Columns[1].Width = Convert.ToInt32(width / 100.0 * 70.0);
            lwResult.Columns[2].Width = Convert.ToInt32(width / 100.0 * 20.0);

            lwDaySummary.Columns[0].Width = Convert.ToInt32(width / 100.0 * 10.0);
            lwDaySummary.Columns[1].Width = Convert.ToInt32(width / 100.0 * 70.0);
            lwDaySummary.Columns[2].Width = Convert.ToInt32(width / 100.0 * 20.0);
        }

        private void FrmQuestionSummary_Shown(object sender, EventArgs e)
        {
            SetListViewSize();
        }
    }
}
