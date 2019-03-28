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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using derinYouTube.Extensions;
using derinYouTube.Model;
using derinYouTube.ViewModels;
using Dapper;
using System.Data.Entity.Validation;
using Exception = System.Exception;

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
            dgwViewerCountBroadcasts.DoubleBuffered(true);

            MessageHeader = "Dikkat"; //this.Text;
            this.DoubleBuffered = true;

            //_youtubeApi = new YouTubeApi("ugurrdal@gmail.com.json", "YouTubeCommentAPI");
            //_youtubeApi = new YouTubeApi("client_secret.json", "YouTubeCommentAPI2");
            //_youtubeApi = new YouTubeApi("migros_client_secret.json", "YouTubeCommentAPI3");
            _youtubeApi = new YouTubeApi("client_secret_izlene@gmail.com.json", "DerinYoutubeApiV1");
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Helper.Cnn = new SqlConnection(Helper.ConnectionString);
            await Temizle();
            pbWorking.Visible = false;
            buttonGetChats.Enabled = false;
            comboBoxChartType.SelectedIndex = 7;
            comboBoxChartType.SelectedIndexChanged += new EventHandler(async delegate (object o, EventArgs a)
            {
                await ShowChart();
            });

            NewQuestion();

            if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("ugurdal"))
            {
                textBoxVideoId.ReadOnly = false;
                textBoxLiveChatId.ReadOnly = false;
            }

            //this.textBoxVideoId.Text = "OnwNEYB-hWQ";
            //this.textBoxLiveChatId.Text = "Cg0KC09ud05FWUItaFdR";
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

        private string ShowErrorOnPanel
        {
            set
            {
                labelShowError.Text = value;
                labelShowError.Visible = true;
                timerException.Start();
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
            if (liveChats == null || !liveChats.Any())
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
                        bulkCopy.ColumnMappings.Add("IsMessageNumeric", "IsMessageNumeric");
                        bulkCopy.ColumnMappings.Add("NumericMessage", "NumericMessage");

                        bulkCopy.BatchSize = 1000;
                        bulkCopy.DestinationTableName = "dbo.liveChatMessages";
                        try
                        {
                            bulkCopy.WriteToServer(chats);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
                            MessageBox.Show($"Yorumlar veritabanına kaydedilemedi!\r\n{ex.Message}", MessageHeader,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            });

            ClearMultipleAnswers();
        }

        private async Task SaveChatsToDatabase2(LinkedList<LiveChatModel> liveChats)
        {
            if (liveChats == null || !liveChats.Any())
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
                        bulkCopy.ColumnMappings.Add("IsMessageNumeric", "IsMessageNumeric");
                        bulkCopy.ColumnMappings.Add("NumericMessage", "NumericMessage");

                        bulkCopy.BatchSize = 1000;
                        bulkCopy.DestinationTableName = "dbo.liveChatMessages";
                        try
                        {
                            bulkCopy.WriteToServer(chats);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
                            MessageBox.Show($"Yorumlar veritabanına kaydedilemedi!\r\n{ex.Message}", MessageHeader,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            });

            ClearMultipleAnswers();
        }

        private async Task ClearMultipleAnswers()
        {
            await Task.Run(() =>
              {
                  try
                  {
                      using (var connection = new SqlConnection(Helper.ConnectionString))
                      {
                          connection.Execute("clearMultipleChatMessages", new { videoId = textBoxVideoId.Text },
                              commandType: CommandType.StoredProcedure, commandTimeout: 300);

                          ChatCount = connection
                              .Query<int>($"SELECT COUNT(*) FROM dbo.liveChatMessages WHERE VideoId='{textBoxVideoId.Text}'")
                              .First();
                      }
                  }
                  catch (Exception ex)
                  {
                      ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
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
            dgwLiveVideos.DataSource = null;
            var videos = new LinkedList<VideoModel>();

            await Task.Run(() =>
            {
                videos = _youtubeApi.GetLiveBroadCasts(checkBoxLiveOnly.Checked);
            });

            if (videos.Any())
            {
                dgwLiveVideos.DataSource = videos.ToSortableGridList();
                dgwLiveVideos.FormatGrid();
                labelStreamsSaving.Visible = true;
            }

            await SaveLiveBroadcasts();
            labelStreamsSaving.Visible = false;
            Cursor = Cursors.Default;
        }

        private async Task SaveLiveBroadcasts()
        {
            await Task.Delay(100);
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
                catch (DbEntityValidationException ex)
                {
                    ShowErrorOnPanel = ex.ToMessage();
                    MessageBox.Show($"LiveBroadcasts ler veritabanına kaydedilemedi!\r\n{ex.ToMessage()}", MessageHeader,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
                    MessageBox.Show($"LiveBroadcasts ler veritabanına kaydedilemedi!\r\n{ex.Message}", MessageHeader,
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
                ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
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

            if (string.IsNullOrEmpty(richTextBoxQuestion.Text) || string.IsNullOrEmpty(textBoxAnswers.Text) ||
                !Helper.IsNumericArti(textBoxAnswers.Text))
            {
                MessageBox.Show("Soru ve cevap doldurulmalı. Cevap numerik olmalı!", MessageHeader, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            timerQuestion.Start();
            textBoxQuestionStartAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = true;
            buttonQuestionStart.Enabled = false;
            tsButtonNewQuestions.Enabled = false;
            await SaveCompetition();
        }

        private async void buttonQuestionStop_Click(object sender, EventArgs e)
        {
            timerQuestion.Stop();
            textBoxQuestionStopAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = false;
            tsButtonNewQuestions.Enabled = true;
            await SaveCompetition();
        }

        private async Task SaveCompetition()
        {
            await Task.Delay(100);
            var showResult = false;
            var compId = 0;
            try
            {
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
                            Answer = textBoxAnswers.Text,
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
            }
            catch (DbEntityValidationException ex)
            {
                ShowErrorOnPanel = ex.ToMessage();
                MessageBox.Show($"Soru kaydı sırasında hata..\r\n{ex.ToMessage()}", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
                MessageBox.Show($"Soru kaydı sırasında hata..\r\n{ex.Message}", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (showResult)
                await ShowValidAnswers(compId);
        }

        private async Task ShowValidAnswers(int competitionId)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwAnswers.DataSource = null;
            richTextBoxAnswerDetails.Text = string.Empty;
            await Task.Delay(100);
            var result = new List<CompetitionResultModel>();
            var totalUserCount = 0;
            var totalAnswers = 0;
            var validAnswers = 0;
            var rightAnswers = 0;

            await Task.Run(() =>
            {
                using (var db = new YoutubeCommentDbEntities())
                {
                    result = db.validAnswers_vw.Where(x => x.CompetitionId == competitionId).Select(x =>
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
                }
            });

            if (result.Any())
            {
                dgwAnswers.DataSource = result;
                dgwAnswers.FormatGrid(true);
                rightAnswers = result.Count(x => x.Gap == 0m);
            }


            await Task.Run(() =>
            {
                using (var db = new YoutubeCommentDbEntities())
                {
                    var compDetail = db.competitions_vw.FirstOrDefault(x => x.Id == competitionId);
                    if (compDetail != null)
                    {
                        totalAnswers = compDetail.TotalAnswers.Value;
                        totalUserCount = compDetail.TotalUser.Value;
                        validAnswers = compDetail.ValidAnswers;
                    }
                }
            });

            richTextBoxAnswerDetails.Text = $"# Toplam {totalUserCount} farklı kullanıcı cevap verdi.\r\n";
            richTextBoxAnswerDetails.Text += $"# Toplam {totalAnswers} cevap verildi.\r\n";
            richTextBoxAnswerDetails.Text += $"# Geçerli cevap sayısı: {validAnswers}\t, Geçersiz cevap sayısı: {totalAnswers - validAnswers}\r\n";
            richTextBoxAnswerDetails.Text += $"# Doğru cevap sayısı: {rightAnswers}";

            this.Cursor = Cursors.Default;
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
            labelQuestionTime.Text = "0";
            richTextBoxQuestion.Text = "";
            textBoxAnswers.Text = "";
            textBoxQuestionStartAt.Text = "";
            textBoxQuestionStopAt.Text = "";
            textBoxQuestionOrder.Text = "";
            richTextBoxAnswerDetails.Text = "";
            buttonQuestionStart.Enabled = true;
            buttonQuestionStop.Enabled = false;
            dgwAnswers.DataSource = null;
            timerQuestion.Stop();
        }

        private async void buttonReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwCompetitionHeader.DataSource = null;
            dgwCompetitionDetail.DataSource = null;
            await Task.Delay(100);

            var result = new List<CompetitionModel>();
            using (var db = new YoutubeCommentDbEntities())
            {
                result = db.competitions_vw
                    .Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(dtQAAnalysis.Value))
                    .Select(x =>
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
                        }).ToList();
            }

            if (result.Any())
            {
                dgwCompetitionHeader.DataSource = result.ToSortableGridList();
                dgwCompetitionHeader.FormatGrid();
            }

            this.Cursor = Cursors.Default;
        }


        private async void buttonShowWinnerOfDay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwWinnerOfDay.DataSource = null;
            dgwWinnerDetail.DataSource = null;
            await Task.Delay(100);
            var dayDetail = new List<WinnerOfDayModel>();

            await Task.Run(() =>
            {
                using (var db = new YoutubeCommentDbEntities())
                {
                    dayDetail = db.winnerOfDay_vw
                        .Where(x => DbFunctions.TruncateTime(x.Day) == DbFunctions.TruncateTime(dtWinnerOfDay.Value)).Select(x =>
                            new WinnerOfDayModel
                            {
                                Sequence = x.Sequence.Value,
                                DisplayName = x.AuthorDisplayName,
                                AuthorChannelId = x.AuthorChannelId,
                                AuthorChannelUrl = x.AuthorChannelUrl,
                                Day = x.Day.Value,
                                TotalCompetitions = x.TotalCompetition.Value,
                                TotalScore = x.TotalScore.Value
                            }).ToList();
                }
            });

            if (dayDetail.Any())
            {
                dgwWinnerOfDay.DataSource = dayDetail.ToSortableGridList();
                dgwWinnerOfDay.FormatGrid(true);
            }

            this.Cursor = Cursors.Default;
        }

        private async void dgwCompetitionHeader_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwCompetitionDetail.DataSource = null;
            await Task.Delay(100);
            var result = new List<CompetitionResultModel>();
            var data = dgwCompetitionHeader.CurrentRow.DataBoundItem as CompetitionModel;

            await Task.Run(() =>
            {
                using (var db = new YoutubeCommentDbEntities())
                {
                    result = db.validAnswers_vw.Where(x => x.CompetitionId == data.Id).Select(x =>
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


                }
            });

            if (result.Any())
            {
                dgwCompetitionDetail.DataSource = result;
                dgwCompetitionDetail.FormatGrid(true);
            }
            this.Cursor = Cursors.Default;
        }

        private async void dgwWinnerOfDay_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwWinnerDetail.DataSource = null;
            await Task.Delay(100);
            var result = new List<WinnerDetailsModel>();

            using (var db = new YoutubeCommentDbEntities())
            {
                if (dgwWinnerOfDay.CurrentRow.DataBoundItem is WinnerOfDayModel data)
                {
                    result = db.validAnswers_vw.Where(x => x.AuthorChannelId == data.AuthorChannelId)
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
                }
            }

            if (result.Any())
            {
                dgwWinnerDetail.DataSource = result;
                dgwWinnerDetail.FormatGrid();
            }

            this.Cursor = Cursors.Default;
        }

        private async void buttonShowStreams_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwStreams.DataSource = null;
            await Task.Delay(100);
            var model = new List<VideoModel>();

            using (var db = new YoutubeCommentDbEntities())
            {
                model = db.liveBroadcasts
                    .Where(x => DbFunctions.TruncateTime(dtAllStreams.Value) ==
                                DbFunctions.TruncateTime(x.PublishedDate)).Select(x => new VideoModel
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
            }

            if (model.Any())
            {
                dgwStreams.DataSource = model.OrderByDescending(x => x.ActualStartTime).ToSortableGridList();
                dgwStreams.FormatGrid();
            }

            this.Cursor = Cursors.Default;
        }

        private async void buttonShowChats_Click(object sender, EventArgs e)
        {
            if (dgwStreams.SelectedRows.Count != 1)
                return;

            var stream = dgwStreams.SelectedRows[0].DataBoundItem as VideoModel;
            this.Cursor = Cursors.WaitCursor;
            await Task.Delay(100);
            dgwChats.DataSource = null;
            labelChatCount.Text = "0";
            var model = new List<ChatsViewModel>();

            await Task.Run(() =>
            {
                using (var db = new YoutubeCommentDbEntities())
                {
                    model = db.liveChatMessages.Where(x => x.VideoId == stream.Id).Select(x => new ChatsViewModel
                    {
                        AuthorChannelId = x.AuthorChannelId,
                        PublishedAt = x.PublishedAt,
                        AuthorChannelUrl = x.AuthorChannelUrl,
                        AuthorDisplayName = x.AuthorDisplayName,
                        MessageText = x.MessageText
                    }).ToList();
                }
            });

            if (model.Any())
            {
                dgwChats.DataSource = model.OrderByDescending(x => x.PublishedAt).ToSortableGridList();
                dgwChats.FormatGrid();
                labelChatCount.Text = model.Count.ToString();
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
                ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
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
                MessageBox.Show(
                    "Önce devam eden soruyu bitirmek için 'Yeni Soru' tuşunu kullanın. Daha sonra soru listesine girebilirsiniz.",
                    MessageHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new FrmQuestions(FrmQuestions.FormTypeEnum.Select);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NewQuestion();
                textBoxQuestionOrder.Text = frm.SelectedQuestion.Order.ToString();
                textBoxAnswers.Text = frm.SelectedQuestion.Answer;
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

        private string ChartType
        {
            get
            {
                if (string.IsNullOrEmpty(comboBoxChartType.SelectedItem?.ToString() ?? string.Empty))
                    return "Spline";
                return comboBoxChartType.SelectedItem.ToString();
            }
        }

        private async void buttonShowChart_Click(object sender, EventArgs e)
        {
            await ShowChart();
        }

        private async Task ShowChart()
        {
            await Task.Delay(100);

            if (dgwViewerCountBroadcasts.SelectedRows.Count != 1)
                return;

            this.Cursor = Cursors.WaitCursor;

            var data = dgwViewerCountBroadcasts.SelectedRows[0].DataBoundItem as VideoModel;
            var chats = new List<ChartViewModel>();
            var viewers = new List<ChartViewModel>();

            using (var db = new YoutubeCommentDbEntities())
            {
                chats = db.chatCountByTime_vw.Where(x => x.VideoId == data.Id).Select(x => new ChartViewModel
                {
                    VideoId = x.VideoId,
                    Part = x.Time,
                    Count = x.ChatCount ?? 0
                }).ToList();

                viewers = db.viewerCountByTime_vw.Where(x => x.VideoId == data.Id).Select(x => new ChartViewModel
                {
                    VideoId = x.VideoId,
                    Part = x.Time,
                    Count = x.ViewerCount
                }).ToList();
            }

            chartViewerCount.Series.Clear();
            chartViewerCount.ChartAreas.Clear();
            chartViewerCount.Legends.Clear();

            chartViewerCount.ChartAreas.Add("Yorum");
            chartViewerCount.ChartAreas.Add("İzlenme");
            chartViewerCount.ChartAreas[0].AxisX.LabelStyle.Angle = -70;
            //chartViewerCount.ChartAreas[0].AxisX.MajorGrid.Interval = 5;
            chartViewerCount.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartViewerCount.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chartViewerCount.ChartAreas[1].AxisX.LabelStyle.Angle = -70;
            chartViewerCount.ChartAreas[1].AxisX.MajorGrid.Enabled = false;
            chartViewerCount.ChartAreas[1].AxisY.MajorGrid.Enabled = false;

            chartViewerCount.Series.Add(new Series
            {
                Name = "Yorum Sayısı",
                ChartTypeName = ChartType,
                XValueType = ChartValueType.String,
                ChartArea = "Yorum",
                BorderWidth = 2
            });

            chartViewerCount.Series.Add(new Series
            {
                Name = "İzlenme Sayısı",
                ChartTypeName = ChartType,
                XValueType = ChartValueType.String,
                ChartArea = "İzlenme",
                BorderWidth = 2
            });

            chartViewerCount.Legends.Add("Toplam");

            var ix = 0;
            foreach (var item in chats)
            {
                if (ix == 0 || ix % 2 == 0)
                {
                    chartViewerCount.ChartAreas[0].AxisX.CustomLabels.Add(ix, ix + 2, item.Part);
                }

                ix++;

                chartViewerCount.Series[0].Points.Add(new DataPoint
                {
                    AxisLabel = item.Part,
                    YValues = new double[] { item.Count },
                    Color = Color.DodgerBlue,
                    Name = item.Part,
                    IsValueShownAsLabel = true
                });
            }

            ix = 0;
            foreach (var item in viewers)
            {
                if (ix == 0 || ix % 2 == 0)
                {
                    chartViewerCount.ChartAreas[1].AxisX.CustomLabels.Add(ix, ix + 2, item.Part);
                }

                ix++;
                chartViewerCount.Series[1].Points.Add(new DataPoint
                {
                    AxisLabel = item.Part,
                    YValues = new double[] { item.Count },
                    Color = Color.Coral,
                    Name = item.Part,
                    IsValueShownAsLabel = true,
                });
            }

            this.Cursor = Cursors.Default;
        }

        private async void buttonShowBroadcastForViewerCount_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwViewerCountBroadcasts.DataSource = null;
            await Task.Delay(100);
            var model = new List<VideoModel>();

            await Task.Run(() =>
            {
                using (var db = new YoutubeCommentDbEntities())
                {
                    model = db.liveBroadcasts
                        .Where(x => DbFunctions.TruncateTime(dtViewerCount.Value) ==
                                    DbFunctions.TruncateTime(x.PublishedDate)).Select(x => new VideoModel
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
                }
            });

            if (model.Any())
            {
                dgwViewerCountBroadcasts.DataSource = model.OrderByDescending(x => x.ActualStartTime).ToSortableGridList();
                dgwViewerCountBroadcasts.FormatGrid();
            }

            this.Cursor = Cursors.Default;
        }

        private async void dgwViewerCountBroadcasts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                await ShowChart();
            }
        }

        private async void timerQuestion_Tick(object sender, EventArgs e)
        {
            await Task.Delay(100);
            if (!string.IsNullOrEmpty(textBoxQuestionStartAt.Text))
            {
                var startAt = DateTime.Parse(textBoxQuestionStartAt.Text);
                labelQuestionTime.Text =
                    Math.Round((DateTime.Now - startAt).TotalSeconds, MidpointRounding.AwayFromZero).ToString("N0");
            }
            else
            {
                labelQuestionTime.Text = "0";
            }
        }

        private void timerException_Tick(object sender, EventArgs e)
        {
            labelShowError.Text = "";
            labelShowError.Visible = false;
            timerException.Stop();
        }

    }
}