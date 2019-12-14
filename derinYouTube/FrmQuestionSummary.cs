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
        private List<WinnerOfDayModel> _listAll;
        private int _cursor;
        private const int VisibleItemCount = 10;
        private ViewType _currentViewType;

        public enum ViewType
        {
            Day = 0,
            Week = 1,
            Both = 2,
            Day_All = 3,
            Week_All = 4
        }

        public FrmQuestionSummary()
        {
            InitializeComponent();
            SetDoubleBuffered(this);
            SetDoubleBuffered(this.tableLayoutPanel1);
            SetDoubleBuffered(this.lwDaySummary);
            

            if (Screen.AllScreens.Count() > 1)
            {
                var secondaryScreen = Screen.AllScreens.Cast<Screen>().Where(x => !x.Primary).Take(1).FirstOrDefault();
                if (secondaryScreen != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = secondaryScreen.WorkingArea.Location;
                    this.Size = new Size(secondaryScreen.WorkingArea.Width, secondaryScreen.WorkingArea.Height);
                }
            }
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
            SetScreenType();
            Properties.Settings.Default.Reload();
            lwDaySummary.Columns[0].Width = 0;

            if (Helper.Settings.FirstOrDefault(x => x.Id == 1)?.IsNumeric ?? false)
            {
                lwDaySummary.Columns[1].Width = Helper.Settings.FirstOrDefault(x => x.Id == 1).NumericValue;
                lwDaySummaryAll.Columns[1].Width = Helper.Settings.FirstOrDefault(x => x.Id == 1).NumericValue;
            }

            if (Helper.Settings.FirstOrDefault(x => x.Id == 2)?.IsNumeric ?? false)
            {
                lwDaySummary.Columns[2].Width = Helper.Settings.FirstOrDefault(x => x.Id == 2).NumericValue;
                lwDaySummaryAll.Columns[2].Width = Helper.Settings.FirstOrDefault(x => x.Id == 2).NumericValue;
            }

            if (Helper.Settings.FirstOrDefault(x => x.Id == 3)?.IsNumeric ?? false)
            {
                lwDaySummary.Columns[3].Width = Helper.Settings.FirstOrDefault(x => x.Id == 3).NumericValue;
                lwDaySummaryAll.Columns[3].Width = Helper.Settings.FirstOrDefault(x => x.Id == 3).NumericValue;
            }
        }

        private void SetScreenType(bool showAll = false)
        {
            _listAll = new List<WinnerOfDayModel>();
            _cursor = 0;
            timerShowAll.Stop();
            timerShowAll.Enabled = false;
            timerShowAll.Interval = Helper.TimerInterval;

            if (showAll)
            {
                lwDaySummaryAll.Visible = true;
                lwDaySummaryAll.BringToFront();
                lwDaySummary.Visible = false;
                lwDaySummary.SendToBack();
            }
            else
            {
                lwDaySummaryAll.Visible = false;
                lwDaySummaryAll.SendToBack();
                lwDaySummary.Visible = true;
                lwDaySummary.BringToFront();
            }
        }

        /// <summary>
        /// Her soru bitiminde tetiklenir. Günün birincisi sıralamasını ikinci ekranda yayınlar. 
        /// </summary>
        /// <param name="model"></param>
        public void ShowResults(ShowResultModel model)
        {
            SetScreenType();
            lwDaySummary.Items.Clear();
            lwDaySummary.Font = new Font("Segoe UI", 50f, FontStyle.Bold);
            labelDaySummary.Text = "GÜNÜN BİRİNCİSİ SIRALAMASI";
            labelDaySummary.Font = new Font("Segoe UI", 50f, FontStyle.Bold);

            var ix = 1;
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
            SetScreenType();
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

        public void ShowAllWinners(List<WinnerOfDayModel> model, ViewType type)
        {
            SetScreenType(true);
            lwDaySummaryAll.Items.Clear();
            _currentViewType = type;
            _listAll = model;
            labelDaySummary.Text = type == ViewType.Day_All
                ? "GÜNÜN BİRİNCİSİ SIRALAMASI ( TÜM LİSTE )"
                : "HAFTANIN BİRİNCİSİ SIRALAMASI ( TÜM LİSTE) ";
            lwDaySummaryAll.Font = new Font("Segoe UI", 40f, FontStyle.Bold);
            labelDaySummary.Font = new Font("Segoe UI", 40f, FontStyle.Bold);

            timerShowAll.Enabled = true;
            timerShowAll.Start();
        }

        private void timerShowAll_Tick(object sender, EventArgs e)
        {
            lwDaySummaryAll.Items.Clear();
            if (_listAll.Any())
            {
                if (_cursor * VisibleItemCount > _listAll.Count)
                    _cursor = 0;

                var items = _listAll.Skip(_cursor * VisibleItemCount).Take(VisibleItemCount).ToList();
                foreach (var item in items.OrderByDescending(x => x.TotalScore))
                {
                    var lwItm = lwDaySummaryAll.Items.Add(item.Sequence.ToString());
                    lwItm.Font = new Font("Segoe UI", 40f, FontStyle.Bold);
                    lwItm.SubItems.Add(item.Sequence.ToString());
                    lwItm.SubItems.Add(item.DisplayName.ToUpper());
                    lwItm.SubItems.Add(item.TotalScore.ToString());
                }

                _cursor++;
            }
        }

        private void FrmQuestionSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetScreenType();
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

        private void lwDaySummary_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            labelSizes.Text = $"{lwDaySummary.Columns[1].Width}\r\n";
            labelSizes.Text += $"{lwDaySummary.Columns[2].Width}\r\n";
            labelSizes.Text += $"{lwDaySummary.Columns[3].Width}\r\n";
        }

    }
}
