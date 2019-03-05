using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
using Dapper;

namespace derinYouTube
{
    public sealed partial class FrmMain : Form
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private LinkedList<LiveChatModel> _liveChats;
        private LinkedList<LiveChatModel> _liveChats2;
        private readonly string MessageHeader;
        private readonly YouTubeApi _youtubeApi;
        private int _chatCount;
        private int _requestCount;

        //TODO: Dakikalık izleyici bilgisi için menü hazırla

        public FrmMain()
        {
            InitializeComponent();
            dgw.DoubleBuffered(true);
            dgwLiveVideos.DoubleBuffered(true);
            dgwAnswers.DoubleBuffered(true);
            dgwCompetitionHeader.DoubleBuffered(true);
            dgwCompetitionDetail.DoubleBuffered(true);
            dgwWinnerOfDay.DoubleBuffered(true);
            dgwWinnerDetail.DoubleBuffered(true);
            dgwStreams.DoubleBuffered(true);
            dgwChats.DoubleBuffered(true);

            MessageHeader = "Dikkat"; //this.Text;
            this.DoubleBuffered = true;


            _youtubeApi = new YouTubeApi("client_secret.json", "YouTubeCommentAPI2");
            //_youtubeApi = new YouTubeApi("migros_client_secret.json", "YouTubeCommentAPI3");
            //_youtubeApi = new YouTubeApi("client_secret_izlene@gmail.com.json", "DerinYoutubeApiV1");
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Helper.Cnn = new SqlConnection(Helper.ConnectionString);
            await Temizle();
            pbWorking.Visible = false;
            buttonGetChats.Enabled = false;
            NewQuestion();

            if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("ugurdal"))
            {
                textBoxVideoId.ReadOnly = false;
                textBoxLiveChatId.ReadOnly = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dgw.DataSource = null;
            //labelCount.Text = "0";

            //var videoId = textBoxVideoId.Text;
            //var comments = YouTubeApi.GetCommentsByVideoId(videoId);
            //dgw.DataSource = comments.ToList();

            //labelCount.Text = comments.Count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBoxLiveChatId.Text))
            //{
            //    MessageBox.Show("Videoya ait Live Chat ID okunamadı!", this.Text, MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    return;
            //}

            //dgw.DataSource = null;
            //labelCount.Text = "0";

            //var comments = YouTubeApi.GetLiveCommentsByChatId(textBoxLiveChatId.Text);
            //dgw.DataSource = new SortableBindingList<LiveChatModel>(comments);
            //dgw.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgw.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //labelCount.Text = comments.Count.ToString();
        }

        private async void buttonAsync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLiveChatId.Text))
            {
                MessageBox.Show("Live Chat ID okunamadı!", MessageHeader, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            _tokenSource = new CancellationTokenSource();
            _liveChats = new LinkedList<LiveChatModel>();
            _liveChats2 = new LinkedList<LiveChatModel>();
            buttonGetChats.Enabled = false;
            dgwLiveVideos.Enabled = false;
            buttonGetLiveBroadCasts.Enabled = false;
            pbWorking.Visible = true;
            labelWorkingMessage.Visible = true;
            timerViewerCount.Start();
            ChatCount = 0;
            RequestCount = 0;

            try
            {
                Progress<ReportChatModel> progress1 = new Progress<ReportChatModel>();
                progress1.ProgressChanged += ReportProgress;

                Progress<ReportChatModel> progress2 = new Progress<ReportChatModel>();
                progress2.ProgressChanged += ReportProgress2;

                _youtubeApi.GetLiveChatsAsync(textBoxLiveChatId.Text, textBoxVideoId.Text, _tokenSource.Token, progress1);
                await Task.Delay(5000);
                _youtubeApi.GetLiveChatsAsync(textBoxLiveChatId.Text, textBoxVideoId.Text, _tokenSource.Token, progress2);

            }
            catch (OperationCanceledException ox)
            {
                MessageBox.Show($"Servis durduruldu.\r\"{ox.Message}", MessageHeader, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private int RequestCount
        {
            get { return _requestCount; }
            set
            {
                _requestCount = value;
                textBoxRequestCount.Text = _requestCount.ToString();
            }
        }

        private int ChatCount
        {
            get { return _chatCount; }
            set
            {
                Task.Run(() =>
                {
                    _chatCount = value;
                    labelCount.Text = _chatCount.ToString();
                });
            }
        }

        private int CurrentService
        {
            set
            {
                var color = value == 1
                    ? Color.BurlyWood
                    : Color.LightGreen;

                textBoxServiceNo.Text = value.ToString();
                textBoxRequestCount.BackColor = color;
                textBoxServiceNo.BackColor = color;
                textBoxFirstChatTime.BackColor = color;
                textBoxLastChatTime.BackColor = color;
                textBoxChatCountInPackage.BackColor = color;
                textBoxOldChatInPackage.BackColor = color;
            }
        }

        private async void ReportProgress(object sender, ReportChatModel e)
        {
            RequestCount++;
            await SaveChatsToDatabase(e.LiveChats);
        }

        private async void ReportProgress2(object sender, ReportChatModel e)
        {
            RequestCount++;
            await SaveChatsToDatabase2(e.LiveChats);
        }

        private async Task SaveChatsToDatabase(LinkedList<LiveChatModel> liveChats)
        {
            if (liveChats == null)
                return;

            CurrentService = 1;
            textBoxFirstChatTime.Text = liveChats.First.Value.PublishedAt;
            textBoxLastChatTime.Text = liveChats.Last.Value.PublishedAt;
            textBoxChatCountInPackage.Text = liveChats.Count.ToString();
            textBoxOldChatInPackage.Text = "";

            await Task.Run(() =>
            {
                var chats = liveChats.AsDataTable();

                using (var connection = new SqlConnection(Helper.ConnectionString))
                {
                    connection.Open();
                    using (var bulkCopy = new SqlBulkCopy(Helper.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.ColumnMappings.Add("MessageId", "MessageId");
                        bulkCopy.ColumnMappings.Add("AuthorChannelId", "AuthorChannelId");
                        bulkCopy.ColumnMappings.Add("AuthorChannelUrl", "AuthorChannelUrl");
                        bulkCopy.ColumnMappings.Add("AuthorDisplayName", "AuthorDisplayName");
                        bulkCopy.ColumnMappings.Add("LiveChatId", "LiveChatId");
                        bulkCopy.ColumnMappings.Add("VideoId", "VideoId");
                        bulkCopy.ColumnMappings.Add("PublishedTime", "PublishedAt");
                        bulkCopy.ColumnMappings.Add("DisplayMessage", "MessageText");

                        bulkCopy.BatchSize = 1000;
                        bulkCopy.DestinationTableName = "dbo.liveChatMessages";
                        try
                        {
                            bulkCopy.WriteToServer(chats);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Yorumlar veritabanına kaydedilemedi!\r\n{ex.Message}", MessageHeader,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    connection.Execute("clearMultipleChatMessages", new { videoId = textBoxVideoId.Text },
                        commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    ChatCount = connection
                        .Query<int>($"SELECT COUNT(*) FROM dbo.liveChatMessages WHERE VideoId='{textBoxVideoId.Text}'")
                        .First();
                }

            });
        }

        private async Task SaveChatsToDatabase2(LinkedList<LiveChatModel> liveChats)
        {
            if (liveChats == null)
                return;

            CurrentService = 2;
            textBoxFirstChatTime.Text = liveChats.First.Value.PublishedAt;
            textBoxLastChatTime.Text = liveChats.Last.Value.PublishedAt;
            textBoxChatCountInPackage.Text = liveChats.Count.ToString();
            textBoxOldChatInPackage.Text = "";

            await Task.Run(() =>
            {
                var chats = liveChats.AsDataTable();

                using (var connection = new SqlConnection(Helper.ConnectionString))
                {
                    connection.Open();
                    using (var bulkCopy = new SqlBulkCopy(Helper.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.ColumnMappings.Add("MessageId", "MessageId");
                        bulkCopy.ColumnMappings.Add("AuthorChannelId", "AuthorChannelId");
                        bulkCopy.ColumnMappings.Add("AuthorChannelUrl", "AuthorChannelUrl");
                        bulkCopy.ColumnMappings.Add("AuthorDisplayName", "AuthorDisplayName");
                        bulkCopy.ColumnMappings.Add("LiveChatId", "LiveChatId");
                        bulkCopy.ColumnMappings.Add("VideoId", "VideoId");
                        bulkCopy.ColumnMappings.Add("PublishedTime", "PublishedAt");
                        bulkCopy.ColumnMappings.Add("DisplayMessage", "MessageText");

                        bulkCopy.BatchSize = 1000;
                        bulkCopy.DestinationTableName = "dbo.liveChatMessages";
                        try
                        {
                            bulkCopy.WriteToServer(chats);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Yorumlar veritabanına kaydedilemedi!\r\n{ex.Message}", MessageHeader,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    connection.Execute("clearMultipleChatMessages", new { videoId = textBoxVideoId.Text },
                        commandType: CommandType.StoredProcedure, commandTimeout: 300);

                    ChatCount = connection
                        .Query<int>($"SELECT COUNT(*) FROM dbo.liveChatMessages WHERE VideoId='{textBoxVideoId.Text}'")
                        .First();
                }

            });

        }

        private async Task Temizle()
        {
            await Task.Run(() =>
            {
                RequestCount = 0;
                ChatCount = 0;

                textBoxVideoId.Text = "";
                textBoxLiveChatId.Text = "";
                richTextBoxTitle.Text = "";
                richTextBoxDescription.Text = "";
                richTextBoxPuslishedAt.Text = "";
                richTextBoxStartTime.Text = "";
                richTextBoxEndTime.Text = "";
                richTextBoxScheduledStartTime.Text = "";
                linkLabelChannelId.Text = "Channel ID";

                textBoxServiceNo.Text = "";
                textBoxRequestCount.Text = "";
                textBoxFirstChatTime.Text = "";
                textBoxLastChatTime.Text = "";
                textBoxChatCountInPackage.Text = "";
                textBoxOldChatInPackage.Text = "";

                timerViewerCount.Stop();
            });
        }

        private void buttonGetVideo_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(textBoxVideoId.Text))
            //{
            //    MessageBox.Show("Bilgileri okunacak videnonun ID'si girilmeli", this.Text, MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    textBoxVideoId.Focus();
            //    return;
            //}

            //Cursor = Cursors.WaitCursor;

            //var video = YouTubeApi.GetVideInfoById(textBoxVideoId.Text);
            //if (video == null)
            //{
            //    Temizle();
            //}
            //else
            //{
            //    richTextBoxTitle.Text = video.Title;
            //    richTextBoxDescription.Text = video.Description;
            //    linkLabelChannelId.Text = video.ChannelId;
            //    richTextBoxPuslishedAt.Text = video.PublishedDate.Value.ToString();
            //}

            //Cursor = Cursors.Default;
        }

        private void linkLabelChannelId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var channel = $"http://www.youtube.com/channel/{linkLabelChannelId.Text}";
            Process.Start(channel);
        }

        private async void buttonGetLiveBroadCasts_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var videos = _youtubeApi.GetLiveBroadCasts(checkBoxLiveOnly.Checked);
            dgwLiveVideos.DataSource = new SortableBindingList<VideoModel>(videos);
            dgwLiveVideos.FormatGrid();
            labelStreamsSaving.Visible = true;
            Cursor = Cursors.Default;
            await SaveLiveBroadcasts();
            labelStreamsSaving.Visible = false;
        }

        private async Task SaveLiveBroadcasts()
        {
            await Task.Delay(200);
            await Task.Run(() =>
            {
                try
                {
                    using (var db = new YoutubeCommentDbEntities())
                    {
                        foreach (DataGridViewRow row in dgwLiveVideos.Rows)
                        {
                            var data = row.DataBoundItem as VideoModel;
                            var video = db.liveBroadcasts.FirstOrDefault(x => x.BroadcastId == data.Id) ??
                                        new liveBroadcasts();

                            if (video.Id != 0)
                                continue;

                            video.BroadcastId = data.Id;
                            video.Title = data.Title ?? "";
                            video.ChannelId = data.ChannelId ?? "";
                            video.LiveChatId = data.LiveChatId ?? "";
                            video.Description = data.Description ?? "";
                            video.LiveStatus = data.LiveStatus ?? "";
                            video.ChannelTitle = data.ChannelTitle ?? "";
                            video.PublishedDate = data.PublishedDate;
                            video.ActualStartTime = data.ActualStartTime;
                            video.ActualEndTime = data.ActualEndTime;
                            video.ScheduledStartTime = data.ScheduledStartTime;

                            db.liveBroadcasts.Add(video);
                            db.SaveChanges();
                        }
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    var errorMessage = "";
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        errorMessage =
                            $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            errorMessage += $"\r\n- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";
                        }
                    }

                    MessageBox.Show($"LiveBroadcasts ler veritabanına kaydedilemedi!\r\n{errorMessage}", MessageHeader,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"LiveBroadcasts ler veritabanına kaydedilemedi!\r\n{e.Message}", MessageHeader,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
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

        private async void VideoBilgileriniOku(int rowIndex)
        {
            try
            {
                if (dgwLiveVideos.Rows[rowIndex].DataBoundItem is VideoModel model)
                {
                    textBoxVideoId.Text = model.Id;
                    textBoxLiveChatId.Text = model.LiveChatId;
                    richTextBoxTitle.Text = model.Title;
                    richTextBoxDescription.Text = model.Description;
                    richTextBoxPuslishedAt.Text = model.PublishedDate?.ToString() ?? "";
                    richTextBoxStartTime.Text = model.ActualStartTime?.ToString() ?? "";
                    richTextBoxEndTime.Text = model.ActualEndTime?.ToString() ?? "";
                    linkLabelChannelId.Text = model.ChannelId;
                    richTextBoxScheduledStartTime.Text = model.ScheduledStartTime?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                await Temizle();
            }
        }

        private async void dgwLiveVideos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgwLiveVideos.RowCount == 0)
                await Temizle();
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

            if (DialogResult.Yes == MessageBox.Show("Servis durdurulacak, emin misiniz?", MessageHeader,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                _tokenSource.Cancel();
                buttonGetChats.Enabled = true;
                dgwLiveVideos.Enabled = true;
                buttonGetLiveBroadCasts.Enabled = true;
                pbWorking.Visible = false;
                labelWorkingMessage.Visible = false;
                timerViewerCount.Stop();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void textBoxLiveChatId_TextChanged(object sender, EventArgs e)
        {
            buttonGetChats.Enabled = !string.IsNullOrEmpty(textBoxLiveChatId.Text.Trim());
        }

        private void textBoxAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void buttonQuestionStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxVideoId.Text))
            {
                MessageBox.Show("Önce yayın seçin!", MessageHeader, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControlMain.SelectTab(tabPageLive);
                return;
            }

            if (string.IsNullOrEmpty(richTextBoxQuestion.Text) || string.IsNullOrEmpty(richTextBoxAnswers.Text) ||
                !Helper.IsNumericArti(richTextBoxAnswers.Text))
            {
                MessageBox.Show("Soru ve cevap doldurulmalı. Cevap numerik olmalı!", MessageHeader, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            textBoxQuestionStartAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = true;
            buttonQuestionStart.Enabled = false;
            tsButtonNewQuestions.Enabled = false;
            await SaveCompetition();
        }

        private async void buttonQuestionStop_Click(object sender, EventArgs e)
        {
            textBoxQuestionStopAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = false;
            tsButtonNewQuestions.Enabled = true;
            await SaveCompetition();
        }

        private async Task SaveCompetition()
        {
            await Task.Delay(200);
            var showResult = false;
            var compId = 0;
            await Task.Run(() =>
            {
                if (labelQuestionId.Text == "0")
                {
                    var comp = new competitions
                    {
                        Id = 0,
                        LiveChatId = textBoxLiveChatId.Text ?? "",
                        VideoId = textBoxVideoId.Text,
                        Question = richTextBoxQuestion.Text,
                        Answer = richTextBoxAnswers.Text,
                        Date = DateTime.Now,
                        StartTime = DateTime.Now,
                    };

                    using (var db = new YoutubeCommentDbEntities())
                    {
                        db.competitions.Add(comp);
                        db.SaveChanges();

                        labelQuestionId.Text = comp.Id.ToString();
                    }
                }
                else
                {
                    using (var db = new YoutubeCommentDbEntities())
                    {
                        var id = Convert.ToInt32(labelQuestionId.Text);
                        compId = id;
                        var comp = db.competitions.Find(id);
                        if (comp != null)
                        {
                            showResult = true;
                            comp.EndTime = DateTime.Now;
                            db.SaveChanges();

                            db.findAnswers(id);
                        }
                    }
                }
            });

            if (showResult)
                await ShowValidAnswers(compId);
        }

        private async Task ShowValidAnswers(int competitionId)
        {
            await Task.Delay(200);
            dgwAnswers.DataSource = null;
            using (var db = new YoutubeCommentDbEntities())
            {
                var result = db.validAnswers_vw.Where(x => x.CompetitionId == competitionId).Select(x =>
                    new CompetitionResultModel
                    {
                        Sequence = x.Sequence.Value,
                        PublishedAt = x.PublishedAt.Value,
                        DisplayName = x.AuthorDisplayName,
                        AuthorChannelUrl = x.AuthorChannelUrl,
                        Answer = x.Answer,
                        MessageText = x.MessageText,
                        Score = x.Score,
                        Gap = x.Gap.Value,
                        TotalAnswersOfUser = x.UserAnswerCount,
                        AuthorChannelId = x.AuthorChannelId
                    }).OrderByDescending(x => x.Score).ToList();

                if (result.Any())
                {
                    dgwAnswers.DataSource = result;
                    dgwAnswers.FormatGrid(true);
                }
            }
        }

        private void textBoxStartAt_TextChanged(object sender, EventArgs e)
        {
            //buttonFindWinner.Enabled =
            //    !string.IsNullOrEmpty(textBoxQuestionStartAt.Text) && !string.IsNullOrEmpty(textBoxQuestionStopAt.Text);
        }

        private void buttonNewQuestions_Click(object sender, EventArgs e)
        {
            NewQuestion();
        }

        private void NewQuestion()
        {
            labelQuestionId.Text = "0";
            richTextBoxQuestion.Text = "";
            richTextBoxAnswers.Text = "";
            textBoxQuestionStartAt.Text = "";
            textBoxQuestionStopAt.Text = "";
            buttonQuestionStart.Enabled = true;
            buttonQuestionStop.Enabled = false;
            dgwAnswers.DataSource = null;
        }

        private async void buttonReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Delay(200);
            dgwCompetitionHeader.DataSource = null;
            dgwWinnerOfDay.DataSource = null;
            dgwCompetitionDetail.DataSource = null;
            dgwWinnerDetail.DataSource = null;

            using (var db = new YoutubeCommentDbEntities())
            {
                var result = db.competitions_vw
                    .Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(dtQAAnalysis.Value)).Select(x =>
                        new CompetitionModel
                        {
                            Id = x.Id,
                            VideoId = x.VideoId,
                            Question = x.Question,
                            Answer = x.Answer,
                            StartTime = x.StartTime,
                            EndTime = x.EndTime ?? DateTime.Now,
                            TotalAnswers = x.TotalAnswers ?? 0,
                            UserCount = x.TotalUser ?? 0,
                            ValidAnswers = x.ValidAnswers
                        }).ToSortableGridList();

                if (result.Any())
                {
                    dgwCompetitionHeader.DataSource = result;
                    dgwCompetitionHeader.FormatGrid();
                }


                var dayDetail = db.winnerOfDay_vw
                    .Where(x => DbFunctions.TruncateTime(x.Day) == DbFunctions.TruncateTime(dtQAAnalysis.Value)).Select(x =>
                        new WinnerOfDayModel
                        {
                            Sequence = x.Sequence.Value,
                            DisplayName = x.AuthorDisplayName,
                            AuthorChannelId = x.AuthorChannelId,
                            AuthorChannelUrl = x.AuthorChannelUrl,
                            Day = x.Day.Value,
                            TotalCompetitions = x.TotalCompetition.Value,
                            TotalScore = x.TotalScore.Value
                        }).ToSortableGridList();

                if (dayDetail.Any())
                {
                    dgwWinnerOfDay.DataSource = dayDetail;
                    dgwWinnerOfDay.FormatGrid(true);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private async void dgwCompetitionHeader_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Delay(200);
            dgwCompetitionDetail.DataSource = null;

            using (var db = new YoutubeCommentDbEntities())
            {
                var data = dgwCompetitionHeader.CurrentRow.DataBoundItem as CompetitionModel;
                var result = db.validAnswers_vw.Where(x => x.CompetitionId == data.Id).Select(x =>
                    new CompetitionResultModel
                    {
                        Sequence = x.Sequence.Value,
                        PublishedAt = x.PublishedAt.Value,
                        DisplayName = x.AuthorDisplayName,
                        AuthorChannelUrl = x.AuthorChannelUrl,
                        Answer = x.Answer,
                        MessageText = x.MessageText,
                        Score = x.Score,
                        Gap = x.Gap.Value,
                        TotalAnswersOfUser = x.UserAnswerCount,
                        AuthorChannelId = x.AuthorChannelId
                    }).OrderByDescending(x => x.Score).ToList();

                if (result.Any())
                {
                    dgwCompetitionDetail.DataSource = result;
                    dgwCompetitionDetail.FormatGrid(true);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private async void dgwWinnerOfDay_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Delay(200);
            dgwWinnerDetail.DataSource = null;

            using (var db = new YoutubeCommentDbEntities())
            {
                if (dgwWinnerOfDay.CurrentRow.DataBoundItem is WinnerOfDayModel data)
                {
                    var result = db.validAnswers_vw.Where(x => x.AuthorChannelId == data.AuthorChannelId)
                        .Where(x => DbFunctions.TruncateTime(x.PublishedAt) == DbFunctions.TruncateTime(dtQAAnalysis.Value))
                        .Select(x =>
                            new WinnerDetailsModel
                            {
                                Sequence = x.Sequence.Value,
                                PublishedAt = x.PublishedAt.Value,
                                DisplayName = x.AuthorDisplayName,
                                AuthorChannelUrl = x.AuthorChannelUrl,
                                Question = x.Question,
                                Answer = x.Answer,
                                MessageText = x.MessageText,
                                Score = x.Score,
                                Gap = x.Gap.Value,
                                TotalAnswersOfUser = x.UserAnswerCount
                            }).OrderByDescending(x => x.Score).ToList();

                    if (result.Any())
                    {
                        dgwWinnerDetail.DataSource = result;
                        dgwWinnerDetail.Columns["AuthorChannelUrl"].Visible = false;
                        dgwWinnerDetail.FormatGrid();
                    }
                }
            }

            this.Cursor = Cursors.Default;
        }

        private async void buttonShowStreams_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Delay(200);
            dgwStreams.DataSource = null;
            using (var db = new YoutubeCommentDbEntities())
            {
                var model = db.liveBroadcasts
                    .Where(x => DbFunctions.TruncateTime(dtAllStreams.Value) ==
                                DbFunctions.TruncateTime(x.ActualStartTime)).Select(x => new VideoModel
                                {
                                    Id = x.BroadcastId,
                                    Title = x.Title,
                                    ChannelId = x.ChannelId,
                                    ChannelTitle = x.ChannelTitle,
                                    LiveChatId = x.LiveChatId,
                                    ActualEndTime = x.ActualEndTime,
                                    ActualStartTime = x.ActualStartTime,
                                    Description = x.Description,
                                    LiveStatus = x.LiveStatus,
                                    PublishedDate = x.PublishedDate,
                                    ScheduledStartTime = x.ScheduledStartTime
                                }).ToList();

                if (model.Any())
                {
                    dgwStreams.DataSource = model.OrderByDescending(x => x.ActualStartTime).ToSortableGridList();
                    dgwStreams.FormatGrid();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private async void buttonShowChats_Click(object sender, EventArgs e)
        {
            if (dgwStreams.SelectedRows.Count != 1)
                return;

            var stream = dgwStreams.SelectedRows[0].DataBoundItem as VideoModel;
            this.Cursor = Cursors.WaitCursor;
            await Task.Delay(200);
            dgwChats.DataSource = null;
            labelChatCount.Text = "0";
            using (var db = new YoutubeCommentDbEntities())
            {
                var model = db.liveChatMessages.Where(x => x.VideoId == stream.Id).Select(x => new ChatsViewModel
                {
                    AuthorChannelId = x.AuthorChannelId,
                    PublishedAt = x.PublishedAt,
                    AuthorChannelUrl = x.AuthorChannelUrl,
                    AuthorDisplayName = x.AuthorDisplayName,
                    MessageText = x.MessageText
                }).ToList();

                if (model.Any())
                {
                    dgwChats.DataSource = model.ToSortableGridList();
                    dgwChats.FormatGrid();
                    labelChatCount.Text = model.Count.ToString();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void dgwCompetitionDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                var competition = dgwCompetitionHeader.CurrentRow.DataBoundItem as CompetitionModel;
                var result = dgwCompetitionDetail.Rows[e.RowIndex].DataBoundItem as CompetitionResultModel;

                using (var db = new YoutubeCommentDbEntities())
                {
                    var model = db.liveChatMessages.Where(x => x.VideoId == competition.VideoId)
                        .Where(x => x.AuthorChannelId == result.AuthorChannelId)
                        .Where(x => x.PublishedAt.Value >= competition.StartTime && x.PublishedAt.Value <= competition.EndTime)
                        .Select(x =>
                        new ChatsViewModel
                        {
                            AuthorChannelId = x.AuthorChannelId,
                            PublishedAt = x.PublishedAt,
                            AuthorChannelUrl = x.AuthorChannelUrl,
                            AuthorDisplayName = x.AuthorDisplayName,
                            MessageText = x.MessageText
                        }).OrderBy(x => x.PublishedAt).ToList();

                    if (model.Any())
                    {
                        new FrmShowResult(model).ShowDialog();
                    }
                }

            }
        }

        private void timerViewerCount_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxVideoId.Text))
                {
                    var result = _youtubeApi.GetCurrentStreamViewCount(textBoxVideoId.Text);
                    using (var db = new YoutubeCommentDbEntities())
                    {
                        var item = new liveBroadcastsViewCount
                        {
                            Date = DateTime.Now,
                            Count = (long)result,
                            VideoId = textBoxVideoId.Text
                        };

                        db.liveBroadcastsViewCount.Add(item);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonQuestionList_Click(object sender, EventArgs e)
        {
            new FrmQuestions(FrmQuestions.FormTypeEnum.New).ShowDialog();
        }

        private void buttonShowQList_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxQuestionStartAt.Text))
            {
                MessageBox.Show("Önce devam eden soruyu bitirin!", MessageHeader, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var frm = new FrmQuestions(FrmQuestions.FormTypeEnum.Select);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NewQuestion();
                richTextBoxAnswers.Text = frm.SelectedQuestion.Answer;
                richTextBoxQuestion.Text = frm.SelectedQuestion.Question;
            }
        }

        private void dgwAnswers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && labelQuestionId.Text != "0")
            {
                var result = dgwAnswers.Rows[e.RowIndex].DataBoundItem as CompetitionResultModel;
                var competitionId = Convert.ToInt32(labelQuestionId.Text);

                using (var db = new YoutubeCommentDbEntities())
                {
                    var competition = db.competitions.FirstOrDefault(x => x.Id == competitionId);
                    if (competition == null)
                        return;

                    var model = db.liveChatMessages.Where(x => x.VideoId == competition.VideoId)
                        .Where(x => x.AuthorChannelId == result.AuthorChannelId)
                        .Where(x => x.PublishedAt.Value >= competition.StartTime && x.PublishedAt.Value <= competition.EndTime)
                        .Select(x =>
                            new ChatsViewModel
                            {
                                AuthorChannelId = x.AuthorChannelId,
                                PublishedAt = x.PublishedAt,
                                AuthorChannelUrl = x.AuthorChannelUrl,
                                AuthorDisplayName = x.AuthorDisplayName,
                                MessageText = x.MessageText
                            }).OrderBy(x => x.PublishedAt).ToList();

                    if (model.Any())
                    {
                        new FrmShowResult(model).ShowDialog();
                    }
                }

            }
        }

        private void dtWinnerOfDay_ValueChanged(object sender, EventArgs e)
        {
            dtQAAnalysis.Value = dtWinnerOfDay.Value;
        }

        private void dtQAAnalysis_ValueChanged(object sender, EventArgs e)
        {
            dtWinnerOfDay.Value = dtQAAnalysis.Value;
        }

        private void buttonShowChart_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Add(100);
            chart1.Series[0].Points.Add(200);
            chart1.Series[0].Points.Add(300);
            chart1.Series[0].Points.Add(400);
            chart1.Series[0].Points.Add(300);
            chart1.Series[0].Points.Add(200);

            chart1.Series[1].Points.Add(10);
            chart1.Series[1].Points.Add(20);
            chart1.Series[1].Points.Add(30);
            chart1.Series[1].Points.Add(40);
            chart1.Series[1].Points.Add(30);
            chart1.Series[1].Points.Add(20);
        }
    }
}