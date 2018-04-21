using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using derinYouTube.Extensions;
using derinYouTube.ViewModels;
using EArsiv.Helper;

namespace derinYouTube
{
    public partial class FrmMain : Form
    {
        private Stopwatch stopWatch = new Stopwatch();
        private Thread _threadProgress;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Helper.GenerateDataTableColumns();
            Temizle();
            dgw.DoubleBuffered(true);
            dgwLiveVideos.DoubleBuffered(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgw.DataSource = null;
            labelCount.Text = "0";
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var videoId = textBoxVideoId.Text;
            var comments = YouTubeApi.GetCommentsByVideoId(videoId);
            stopWatch.Stop();
            dgw.DataSource = comments.ToList();

            labelCount.Text = comments.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLiveChatId.Text))
            {
                MessageBox.Show("Videoya ait Live Chat ID okunamadı!", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            dgw.DataSource = null;
            labelCount.Text = "0";
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var comments = YouTubeApi.GetLiveCommentsByChatId(textBoxLiveChatId.Text);
            stopWatch.Stop();
            dgw.DataSource = new SortableBindingList<LiveChatModel>(comments);
            dgw.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            labelCount.Text = comments.Count.ToString();
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void buttonAsync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLiveChatId.Text))
            {
                MessageBox.Show("Live Chat ID okunamadı!", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (bgwGetChats.IsBusy)
            {
                MessageBox.Show("Servis zaten çalışıyor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StartProgressBar();
            bgwGetChats.RunWorkerAsync();
        }

        private void Temizle()
        {
            textBoxVideoId.Text = "";
            textBoxLiveChatId.Text = "";
            richTextBoxTitle.Text = "";
            richTextBoxDescription.Text = "";
            richTextBoxPuslishedAt.Text = "";
            richTextBoxStartTime.Text = "";
            richTextBoxEndTime.Text = "";
            linkLabelChannelId.Text = "Channel ID";
        }

        private void buttonGetVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxVideoId.Text))
            {
                MessageBox.Show("Bilgileri okunacak videnonun ID'si girilmeli", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                textBoxVideoId.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var video = YouTubeApi.GetVideInfoById(textBoxVideoId.Text);
            if (video == null)
            {
                Temizle();
            }
            else
            {
                richTextBoxTitle.Text = video.Title;
                richTextBoxDescription.Text = video.Description;
                linkLabelChannelId.Text = video.ChannelId;
                richTextBoxPuslishedAt.Text = video.PublishedDate.Value.ToString();
            }

            Cursor = Cursors.Default;
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void linkLabelChannelId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Kanala gidelim
        }

        private void buttonGetLiveBroadCasts_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            labelTime.Text = "0";
            stopWatch.Reset();
            stopWatch.Start();

            var videos = YouTubeApi.GetLiveBroadCasts(checkBoxLiveOnly.Checked);
            stopWatch.Stop();

            dgwLiveVideos.DataSource = new SortableBindingList<VideoModel>(videos);
            //dgwLiveVideos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgwLiveVideos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            Cursor = Cursors.Default;
            labelTime.Text = stopWatch.Elapsed.ToString();
        }

        private void dgwLiveVideos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwLiveVideos.SelectedRows.Count > 0)
                VideoBilgileriniOku(dgwLiveVideos.SelectedRows[0].Index);
        }

        private void dgwLiveVideos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                VideoBilgileriniOku(e.RowIndex);
        }

        private void dgwLiveVideos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                VideoBilgileriniOku(e.RowIndex);
        }

        private void VideoBilgileriniOku(int rowIndex)
        {
            try
            {
                var model = dgwLiveVideos.Rows[rowIndex].DataBoundItem as VideoModel;
                if (model != null)
                {
                    textBoxVideoId.Text = model.Id;
                    textBoxLiveChatId.Text = model.LiveChatId;
                    richTextBoxTitle.Text = model.Title;
                    richTextBoxDescription.Text = model.Description;
                    richTextBoxPuslishedAt.Text = model.PublishedDate?.ToString() ?? "";
                    richTextBoxStartTime.Text = model.ActualStartTime?.ToString() ?? "";
                    richTextBoxEndTime.Text = model.ActualEndTime?.ToString() ?? "";
                    linkLabelChannelId.Text = model.ChannelId;
                }
            }
            catch (Exception e)
            {
                Temizle();
            }
        }

        private void dgwLiveVideos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgwLiveVideos.RowCount == 0)
                Temizle();
        }

        private void bgwGetChats_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void bgwGetChats_DoWork(object sender, DoWorkEventArgs e)
        {
            
            dgw.DataSource = Helper.DtLiveChats;
            dgw.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            YouTubeApi.AsyncGetLiveCommentsByChatId(textBoxLiveChatId.Text, textBoxVideoId.Text);
        }

        private void StartProgressBar()
        {
            _threadProgress = new Thread(ShowProgressBar);
            _threadProgress.Start();
        }

        private void ShowProgressBar()
        {
            progressBarGetChats.Visible = true;
            progressBarGetChats.MarqueeAnimationSpeed = 30;
            this.Refresh();

        }

        private void dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            labelCount.Text = dgw.RowCount.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Servis durdurulacak, emin misiniz?", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                _threadProgress.Abort();
                bgwGetChats.CancelAsync();
                //progressBarGetChats.Visible = false;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgwGetChats.IsBusy)
            {
                MessageBox.Show("Servis çalışıyor. Önce servisi durdurun ve verilerin kaydedilmesini bekleyin!",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }
        }
    }
}