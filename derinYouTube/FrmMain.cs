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
using derinYouTube.Model;
using derinYouTube.ViewModels;
using EArsiv.Helper;

namespace derinYouTube
{
    public partial class FrmMain : Form
    {
        CancellationTokenSource _tokenSource = new CancellationTokenSource();
        LinkedList<LiveChatModel> _liveChats;

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
            pbWorking.Visible = false;
            buttonAsync.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgw.DataSource = null;
            labelCount.Text = "0";

            var videoId = textBoxVideoId.Text;
            var comments = YouTubeApi.GetCommentsByVideoId(videoId);
            dgw.DataSource = comments.ToList();

            labelCount.Text = comments.Count.ToString();
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

            var comments = YouTubeApi.GetLiveCommentsByChatId(textBoxLiveChatId.Text);
            dgw.DataSource = new SortableBindingList<LiveChatModel>(comments);
            dgw.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            labelCount.Text = comments.Count.ToString();
        }

        private async void buttonAsync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLiveChatId.Text))
            {
                MessageBox.Show("Live Chat ID okunamadı!", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            _liveChats = new LinkedList<LiveChatModel>();
            buttonAsync.Enabled = false;
            dgwLiveVideos.Enabled = false;
            buttonGetLiveBroadCasts.Enabled = false;
            pbWorking.Visible = true;

            Progress<ReportChatModel> progress = new Progress<ReportChatModel>();
            progress.ProgressChanged += ReportProgress;

            try
            {
                var result = await YouTubeApi.GetLiveChatsAsync(textBoxLiveChatId.Text, _tokenSource.Token, progress);
                await Task.Delay(100);
                AddChatToDataGridView(result);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Servis durduruldu.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReportProgress(object sender, ReportChatModel e)
        {
            AddChatToDataGridView(e.LiveChats);
        }

        private async void AddChatToDataGridView(LinkedList<LiveChatModel> liveChats)
        {
            await Task.Delay(500);
            //Parallel.ForEach<LiveChatModel>(liveChats.ToList(), (chat) =>
            //{
            //    if (_liveChats.All(x => x.MessageId != chat.MessageId))
            //    {
            //        _liveChats.AddLast(chat);
            //        dgw.Rows.Add(chat.MessageId, chat.PublishedAt, chat.DisplayMessage,
            //                        chat.DisplayName, chat.ChannelUrl, chat.IsVerified, chat.IsChatOwner,
            //                        chat.IsChatSponsor, chat.IsChatModerator);
            //    }
            //});

            var chats = liveChats;
            foreach (var chat in chats)
            {
                if (_liveChats.All(x => x.MessageId != chat.MessageId))
                {
                    _liveChats.AddLast(chat);
                    dgw.Rows.Add(chat.MessageId, chat.PublishedAt, chat.DisplayMessage,
                                    chat.DisplayName, chat.ChannelUrl, chat.IsVerified, chat.IsChatOwner,
                                    chat.IsChatSponsor, chat.IsChatModerator);

                    labelCount.Text = dgw.RowCount.ToString();
                    dgw.Sort(this.dgw.Columns["PublishedAt"], ListSortDirection.Descending);
                    //await Task.Run(() =>
                    //{
                    //    this.dgw.Sort(this.dgw.Columns["PublishedAt"], ListSortDirection.Descending);
                    //    this.dgw.Refresh();
                    //});
                }
            }
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
        }

        private void linkLabelChannelId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Kanala gidelim
        }

        private void buttonGetLiveBroadCasts_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var videos = YouTubeApi.GetLiveBroadCasts(checkBoxLiveOnly.Checked);
            dgwLiveVideos.DataSource = new SortableBindingList<VideoModel>(videos);
            Cursor = Cursors.Default;
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
            catch (Exception ex)
            {
                Temizle();
            }
        }

        private void dgwLiveVideos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgwLiveVideos.RowCount == 0)
                Temizle();
        }

        private void dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Task.Delay(500);
            //labelCount.Text = dgw.RowCount.ToString();
            //Task.Run(() => 
            //{
            //    this.dgw.Sort(this.dgw.Columns["PublishedAt"], ListSortDirection.Descending);
            //    this.dgw.Refresh();
            //});
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (_tokenSource.IsCancellationRequested)
                return;

            if (DialogResult.Yes == MessageBox.Show("Servis durdurulacak, emin misiniz?", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                _tokenSource.Cancel();
                buttonAsync.Enabled = true;
                dgwLiveVideos.Enabled = true;
                buttonGetLiveBroadCasts.Enabled = true;
                pbWorking.Visible = false;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBoxLiveChatId_TextChanged(object sender, EventArgs e)
        {
            buttonAsync.Enabled = !string.IsNullOrEmpty(textBoxLiveChatId.Text.Trim());
        }

        private void textBoxAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCampStart_Click(object sender, EventArgs e)
        {
            //if (!buttonAsync.Enabled)
            //    return;

            textBoxStartAt.Text = DateTime.Now.ToString();
        }

        private void buttonCampStop_Click(object sender, EventArgs e)
        {
            textBoxStopAt.Text = DateTime.Now.ToString();
        }

        private async void buttonFindWinner_ClickAsync(object sender, EventArgs e)
        {
            await Task.Delay(500);

            var t1 = DateTime.Parse(textBoxStartAt.Text);
            var t2 = DateTime.Parse(textBoxStopAt.Text);

            var rows = dgw.Rows.Cast<DataGridViewRow>().Where(x =>
                DateTime.Parse(x.Cells["PublishedAt"].Value.ToString()) >= t1 &&
                DateTime.Parse(x.Cells["PublishedAt"].Value.ToString()) <= t2);

            var cevaplar = new List<AnswerModel>();
            foreach (DataGridViewRow rw in rows)
            {
                var ix = 0;
                if (int.TryParse(rw.Cells["DisplayMessage"].Value.ToString(), out ix))
                {
                    var cevap = new AnswerModel
                    { 
                        UserName = rw.Cells["DisplayName"].Value.ToString(),
                        Message = ix,
                        PublishedAt = DateTime.Parse(rw.Cells["PublishedAt"].Value.ToString())
                    };
                    cevaplar.Add(cevap);
                }
            }

            dgwCevap.DataSource = cevaplar.OrderBy(x => x.PublishedAt).ToList();

        }
    }
}