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
        private string _newComment;
        private frmGetChats _frmGetChats;
        private frmCompetitions _frmCompetitions;
        private FrmQuestionSummary _frmQuestionSummary;
        private VideoModel _currentBroadcast;

        public FrmMain()
        {
            InitializeComponent();
            //dgw.DoubleBuffered(true);
            dgwLiveVideos.DoubleBuffered(true);
            dgwAnswers.DoubleBuffered(true);
            dgwCompetitionHeader.DoubleBuffered(true);
            dgwCompetitionDetail.DoubleBuffered(true);
            dgwWinnerOfDay.DoubleBuffered(true);
            dgwWinnerDetail.DoubleBuffered(true);
            dgwStreams.DoubleBuffered(true);
            dgwChats.DoubleBuffered(true);
            dgwViewerCountBroadcasts.DoubleBuffered(true);
            dgwWinnerOfWeek.DoubleBuffered(true);

            MessageHeader = "Dikkat"; //this.Text;
            this.DoubleBuffered = true;
            dtWinnerOfWeek.Value = DateTime.Today;

            //Sol paneli kapat
            tabControlLeftMenu.Visible = false;
            //tabControlLeftMenu.TabPages.Remove(tabPageService);
            splitContainerDikey.SplitterDistance = 5;
            tabControlMain.TabPages.Remove(tabPageQuestion);

            dgwWinnerOfDay.CellDoubleClick += DataGridViewCellDoubleClick;
            dgwWinnerOfWeek.CellDoubleClick += DataGridViewCellDoubleClick;
            dgwAnswers.CellDoubleClick += DataGridViewCellDoubleClick;
            dgwCompetitionDetail.CellDoubleClick += DataGridViewCellDoubleClick;
            dgwChats.CellDoubleClick += DataGridViewCellDoubleClick;

            timerCommentAdd.Stop();
            timerException.Stop();
            timerQuestion.Stop();

            if (string.IsNullOrEmpty(Properties.Settings.Default.YoutubeHesap))
            {
                MessageBox.Show("Config'e YouTube hesap bilgileri girilmeli", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            else
            {
                //_youtubeApi = new YouTubeApi("ugurrdal@gmail.com.json", "YouTubeCommentAPI");
                //_youtubeApi = new YouTubeApi("client_secret.json", "YouTubeCommentAPI2");
                //_youtubeApi = new YouTubeApi("migros_client_secret.json", "YouTubeCommentAPI3");
                //_youtubeApi = new YouTubeApi("client_secret_izlene@gmail.com.json", "DerinYoutubeApiV1");

                if (Properties.Settings.Default.YoutubeHesap == "client_secret_izlene@gmail.com.json")
                {
                    _youtubeApi = new YouTubeApi("client_secret_izlene@gmail.com.json", "DerinYoutubeApiV1");
                }
                if (Properties.Settings.Default.YoutubeHesap == "ugurrdal@gmail.com.json")
                {
                    _youtubeApi = new YouTubeApi("ugurrdal@gmail.com.json", "DerinYoutubeApiV1");
                }

                if (_youtubeApi == null)
                {
                    MessageBox.Show("Tanımsız YouTube hesabı", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }

        private void DataGridViewCellDoubleClick(object sender, EventArgs args)
        {
            try
            {
                var gridView = sender as DataGridView;
                if (gridView.CurrentCell != null && gridView.CurrentCell.Value.ToString().ToLower().Contains("www.youtube.com"))
                    Process.Start(gridView.CurrentCell.Value.ToString());
            }
            catch (Exception)
            {
            }
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Helper.Cnn = new SqlConnection(Helper.ConnectionString);
            await Temizle();
            pbWorking.Visible = false;
            //buttonGetChats.Enabled = false; //TODO: Butonun disabled'ı kapatıldı
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

            Helper.CnnOpen();
            Helper.Settings = Helper.Cnn.Query<SettingsModel>("SELECT Id,Value FROM settings").ToList();
        }

        private async void buttonAsync_Click(object sender, EventArgs e)
        {
            return;
            _frmGetChats = new frmGetChats(textBoxVideoId.Text, textBoxLiveChatId.Text, _youtubeApi);
            _frmGetChats.Show();

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
                //await Task.Delay(5000);
                //_youtubeApi.GetLiveChatsAsync(textBoxLiveChatId.Text, textBoxVideoId.Text, _tokenSource.Token, progress2);

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
            await SaveChatsToDatabase(e.LiveChats, e.PollingIntervalMillis);
        }

        private async void ReportProgress2(object sender, ReportChatModel e)
        {
            RequestCount++;
            await SaveChatsToDatabase2(e.LiveChats, e.PollingIntervalMillis);
        }

        private async Task SaveChatsToDatabase(LinkedList<LiveChatModel> liveChats, long? pollingIntervalMillis)
        {
            if (liveChats == null || !liveChats.Any())
                return;

            CurrentService = 1;
            textBoxFirstChatTime.Text = liveChats.First.Value.PublishedAt;
            textBoxLastChatTime.Text = liveChats.Last.Value.PublishedAt;
            textBoxChatCountInPackage.Text = liveChats.Count.ToString();
            textBoxOldChatInPackage.Text = "";
            textBoxPollingIntervalMillis.Text = pollingIntervalMillis?.ToString() ?? "";

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

                        bulkCopy.BatchSize = 5000;
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

        private async Task SaveChatsToDatabase2(LinkedList<LiveChatModel> liveChats, long? pollingIntervalMillis)
        {
            if (liveChats == null || !liveChats.Any())
                return;

            CurrentService = 2;
            textBoxFirstChatTime.Text = liveChats.First.Value.PublishedAt;
            textBoxLastChatTime.Text = liveChats.Last.Value.PublishedAt;
            textBoxChatCountInPackage.Text = liveChats.Count.ToString();
            textBoxOldChatInPackage.Text = "";
            textBoxPollingIntervalMillis.Text = pollingIntervalMillis?.ToString() ?? "";

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

                        bulkCopy.BatchSize = 5000;
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

                          if (!string.IsNullOrEmpty(textBoxQuestionStartAt.Text) && string.IsNullOrEmpty(textBoxQuestionStopAt.Text))
                          {
                              var startAt = DateTime.Parse(textBoxQuestionStartAt.Text);
                              var count = connection
                              .Query<int>($"SELECT COUNT(*) FROM dbo.liveChatMessages WHERE VideoId='{textBoxVideoId.Text}' " +
                              $" AND PublishedAt>='{startAt}'")
                              .First();
                              labelQuestionCount.Text = count.ToString();
                          }
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
                textBoxPollingIntervalMillis.Text = "";
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
                    using (var db = new DbEntities())
                    {
                        foreach (DataGridViewRow row in dgwLiveVideos.Rows)
                        {
                            var data = row.DataBoundItem as VideoModel;
                            var video = db.liveBroadcasts.FirstOrDefault(x => x.BroadcastId == data.Id) ??
                                        new liveBroadcasts();

                            video.BroadcastId = data.Id;
                            video.Title = data.Title ?? "";
                            video.ChannelId = data.ChannelId ?? "";
                            video.LiveChatId = data.LiveChatId ?? "";
                            video.Description = data.Description ?? "";
                            video.LiveStatus = data.LiveStatus ?? "";
                            video.ChannelTitle = data.ChannelTitle ?? "";
                            video.PublishedDate = data.ScheduledStartTime ?? data.PublishedDate;
                            video.ActualStartTime = data.ActualStartTime;
                            video.ActualEndTime = data.ActualEndTime;
                            video.ScheduledStartTime = data.ScheduledStartTime;

                            if (video.Id == 0)
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

        private VideoModel CurrentBroadcast
        {
            get
            {
                return _currentBroadcast;
            }
            set
            {
                _currentBroadcast = value;
            }
        }

        private async void VideoBilgileriniOku(int rowIndex)
        {
            try
            {
                if (dgwLiveVideos.Rows[rowIndex].DataBoundItem is VideoModel model)
                {
                    _currentBroadcast = model;
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
            //buttonGetChats.Enabled = !string.IsNullOrEmpty(textBoxLiveChatId.Text.Trim());
            //TODO: Butonun disabled'ı kapatıldı
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
            labelQuestion.Visible = true;
            labelQuestionCount.Visible = true;
            await SaveCompetition();
        }

        private async void buttonQuestionStop_Click(object sender, EventArgs e)
        {
            timerQuestion.Stop();
            textBoxQuestionStopAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = false;
            tsButtonNewQuestions.Enabled = true;
            labelQuestion.Visible = false;
            labelQuestionCount.Visible = false;
            labelQuestionCount.Text = "0";
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

                        using (var db = new DbEntities())
                        {
                            db.competitions.Add(comp);
                            db.SaveChanges();

                            labelQuestionId.Text = comp.Id.ToString();
                        }
                    }
                    else
                    {
                        using (var db = new DbEntities())
                        {
                            var id = Convert.ToInt32(labelQuestionId.Text);
                            compId = id;
                            var comp = db.competitions.Find(id);
                            if (comp != null)
                            {
                                showResult = true;
                                comp.EndTime = DateTime.Now;
                                db.SaveChanges();

                                db.Database.ExecuteSqlCommand("EXEC findAnswers @p0", id);
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
                using (var db = new DbEntities())
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

                var ix = 1;
                _newComment = "";
                _newComment = $"Sıra: {textBoxQuestionOrder.Text}\r\n";
                _newComment += $"Soru: {richTextBoxQuestion.Text}\r\n";
                _newComment += $"Cevap: {textBoxAnswers.Text}\r\n";
                _newComment += "____________________________________\r\n";
                _newComment += "İlk 20\r\n";
                _newComment += "____________________________________\r\n";

                foreach (var item in result.OrderByDescending(x => x.Score))
                {
                    if (ix > 20)
                        break;

                    _newComment += $"{ix} - {item.DisplayName} - Cevabı: {item.MessageText} - Saat/Dakika: {item.PublishedAt.ToString("HH:mm:ss.fff")} - Puan: {item.Score} \r\n";
                    ix++;
                }

                timerCommentAdd.Start();
            }


            await Task.Run(() =>
            {
                using (var db = new DbEntities())
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
            return;
            var frm = new frmCompetitions(textBoxVideoId.Text, textBoxLiveChatId.Text, _youtubeApi);
            frm.Show();

            //TODO: Yarışma süreçleri yeni forma alındı
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
            labelSelectedComp.Text = "";

            //await Task.Delay(50);
            //var result = new List<CompetitionModel>();
            //using (var db = new DbEntities())
            //{
            //    result = db.competitions_vw
            //        .Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(dtQAAnalysis.Value))
            //        .Select(x =>
            //            new CompetitionModel
            //            {
            //                Id = x.Id,
            //                VideoId = x.VideoId,
            //                Question = x.Question,
            //                Answer = x.Answer,
            //                StartTime = x.StartTime,
            //                EndTime = x.EndTime ?? DateTime.Now,
            //                TotalAnswers = x.TotalAnswers ?? 0,
            //                UserCount = x.TotalUser ?? 0,
            //                ValidAnswers = x.ValidAnswers
            //            }).ToList();
            //}

            Helper.CnnOpen();
            var result = Helper.Cnn.Query<CompetitionModel>($"Select * From dbo.fn_competitions('{dtQAAnalysis.Value.Date}')").ToList();
            Helper.CnnClose();

            if (result.Any())
            {
                dgwCompetitionHeader.DataSource = result.OrderBy(x => x.Id).ToSortableGridList();
                dgwCompetitionHeader.FormatGrid();
            }

            this.Cursor = Cursors.Default;
        }


        private async void buttonShowWinnerOfDay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwWinnerOfDay.DataSource = null;
            dgwWinnerDetail.DataSource = null;
            labelSelectedUser.Text = "";

            Helper.CnnOpen();
            var dayDetail = Helper.Cnn.Query<WinnerOfDayModel>($@"
                SELECT TOP 20 CAST(PublishedAt AS DATE) Day
	                ,AuthorChannelId
	                ,AuthorChannelUrl
	                ,AuthorDisplayName as DisplayName
	                ,SUM(Score) TotalScore
	                ,COUNT(DISTINCT(CompetitionId)) TotalCompetitions
	                ,ROW_NUMBER() OVER (PARTITION BY CAST(PublishedAt AS DATE) ORDER BY SUM(Score) DESC) Sequence
	                ,'' as IsSubscripted
                FROM ValidAnswers_vw
                WHERE CAST(PublishedAt AS DATE)=CAST('{dtWinnerOfDay.Value}' as DATE)
                GROUP BY CAST(PublishedAt AS DATE),AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
                ORDER BY TotalScore DESC ").OrderByDescending(x => x.TotalScore).ToList();

            Helper.CnnClose();

            if (dayDetail.Any())
            {
                dgwWinnerOfDay.DataSource = dayDetail.ToSortableGridList();
                dgwWinnerOfDay.Columns["TotalDays"].Visible = false;
                dgwWinnerOfDay.FormatGrid(true);
            }

            this.Cursor = Cursors.Default;
            dgwWinnerOfDay.Columns.Cast<DataGridViewColumn>().ToList()
                .ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            labelCheckSubscriptionDay.Visible = true;

            await CheckUsersForSubscription(dgwWinnerOfDay);

            labelCheckSubscriptionDay.Visible = false;
            dgwWinnerOfDay.Columns.Cast<DataGridViewColumn>().ToList()
                .ForEach(f => f.SortMode = DataGridViewColumnSortMode.Automatic);
        }

        private async void buttonShowWinnerOfDayOnScreen_Click(object sender, EventArgs e)
        {
            buttonShowWinnerOfDayOnScreen.Enabled = false;
            await Task.Delay(20);
            Helper.CnnOpen();
            if (CheckSubForms())
            {
                var dayDetail = new List<WinnerOfDayModel>();

                await Task.Run(() =>
                {
                    dayDetail = Helper.Cnn.Query<WinnerOfDayModel>($@"
                    SELECT TOP 5 CAST(PublishedAt AS DATE) Day
	                    ,AuthorChannelId
	                    ,AuthorChannelUrl
	                    ,AuthorDisplayName as DisplayName
	                    ,SUM(Score) TotalScore
	                    ,COUNT(DISTINCT(CompetitionId)) TotalCompetitions
	                    ,ROW_NUMBER() OVER (PARTITION BY CAST(PublishedAt AS DATE) ORDER BY SUM(Score) DESC) Sequence
	                    ,'' as IsSubscripted
                    FROM ValidAnswers_vw
                    WHERE CAST(PublishedAt AS DATE)=CAST('{dtWinnerOfDay.Value}' as DATE)
                    GROUP BY CAST(PublishedAt AS DATE),AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
                    ORDER BY TotalScore DESC ").OrderByDescending(x => x.TotalScore).ToList();
                });

                Helper.CnnClose();

                if (dayDetail.Any())
                {
                    _frmQuestionSummary.Activate();
                    _frmQuestionSummary.Show();
                    _frmQuestionSummary.BringToFront();
                    _frmQuestionSummary.ShowWinners(dayDetail, FrmQuestionSummary.ViewType.Day);
                }
            }
            buttonShowWinnerOfDayOnScreen.Enabled = true;
        }

        private async void buttonShowWinnerOfWeekOnScreen_Click(object sender, EventArgs e)
        {
            buttonShowWinnerOfWeekOnScreen.Enabled = false;
            await Task.Delay(20);
            Helper.CnnOpen();
            if (CheckSubForms())
            {
                var start = dtWinnerOfWeek.Value.GetFirstDayOfWeek();
                var end = dtWinnerOfWeek.Value.GetLastWorkDayOfWeek();
                var weekDetail = new List<WinnerOfDayModel>();

                await Task.Run(() =>
                {
                    weekDetail = Helper.Cnn.Query<WinnerOfDayModel>($@"
                     SELECT TOP 5 AuthorChannelId
	                    ,AuthorChannelUrl
	                    ,AuthorDisplayName as DisplayName
	                    ,SUM(Score) TotalScore
	                    ,COUNT(DISTINCT(CompetitionId)) TotalCompetitions
	                    ,COUNT(DISTINCT(CAST(PublishedAt AS DATE))) TotalDays
	                    ,ROW_NUMBER() OVER (ORDER BY SUM(Score) DESC) Sequence
	                    ,'' as IsSubscripted
                    FROM ValidAnswers_vw
                    WHERE CAST(PublishedAt AS DATE) BETWEEN CAST('{start}' as DATE) AND CAST('{end}' as DATE)
                    GROUP BY AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
                    ORDER BY TotalScore DESC ").OrderByDescending(x => x.TotalScore).ToList();
                });

                Helper.CnnClose();

                if (weekDetail.Any())
                {
                    _frmQuestionSummary.Activate();
                    _frmQuestionSummary.Show();
                    _frmQuestionSummary.BringToFront();
                    _frmQuestionSummary.ShowWinners(weekDetail, FrmQuestionSummary.ViewType.Week);
                }
            }
            buttonShowWinnerOfWeekOnScreen.Enabled = true;
        }

        private async Task CheckUsersForSubscription(DataGridView dgw)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var ix = 0;
                    foreach (DataGridViewRow row in dgw.Rows)
                    {
                        if (ix >= 10)
                            break;

                        var data = row.DataBoundItem as WinnerOfDayModel;
                        var queryResult =
                            _youtubeApi.IsUserSucscripted(data.AuthorChannelId, "UCqcOFUC9aroUcaz6k_gtmIg").Result;

                        data.IsSubscripted = queryResult.ToDescription();
                        dgw.Rows[row.Index].Cells["IsSubscripted"].Value = queryResult.ToDescription();
                        ix++;

                        dgw.Refresh();
                        await Task.Delay(25);
                    }
                });
            }
            catch (Exception e)
            {
            }
        }

        private async void dgwCompetitionHeader_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgwCompetitionHeader.CurrentRow == null)
            //    return;

            //this.Cursor = Cursors.WaitCursor;
            //dgwCompetitionDetail.DataSource = null;
            //var data = dgwCompetitionHeader.CurrentRow.DataBoundItem as CompetitionModel;

            //label17.Text = data.Question;
            //await Task.Delay(100);
            //var result = new List<CompetitionResultModel>();
            //await Task.Run(() =>
            //{
            //    using (var db = new DbEntities())
            //    {
            //        result = db.validAnswers_vw.Where(x => x.CompetitionId == data.Id).Select(x =>
            //            new CompetitionResultModel
            //            {
            //                Sequence = x.Sequence.Value,
            //                PublishedAt = x.PublishedAt.Value,
            //                DisplayName = x.AuthorDisplayName,
            //                AuthorChannelUrl = x.AuthorChannelUrl,
            //                Answer = x.Answer,
            //                MessageText = x.MessageText,
            //                Score = x.Score,
            //                Gap = x.Gap.Value,
            //                TotalAnswersOfUser = x.UserAnswerCount,
            //                AuthorChannelId = x.AuthorChannelId
            //            }).OrderByDescending(x => x.Score).ToList();


            //    }
            //});

            //if (result.Any())
            //{
            //    dgwCompetitionDetail.DataSource = result;
            //    dgwCompetitionDetail.FormatGrid(true);
            //}
            //this.Cursor = Cursors.Default;
        }

        private async void dgwWinnerOfDay_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //dgwWinnerDetail.DataSource = null;
            //labelSelectedUser.Text = "";

            //if (dgwWinnerOfDay.CurrentRow == null)
            //    return;

            //await Task.Delay(100);
            //var result = new List<WinnerDetailsModel>();

            //using (var db = new DbEntities())
            //{
            //    if (dgwWinnerOfDay.CurrentRow.DataBoundItem is WinnerOfDayModel data)
            //    {
            //        labelSelectedUser.Text = data.DisplayName;

            //        result = db.validAnswers_vw.Where(x => x.AuthorChannelId == data.AuthorChannelId)
            //            .Where(x => DbFunctions.TruncateTime(x.PublishedAt) == DbFunctions.TruncateTime(dtQAAnalysis.Value))
            //            .Select(x =>
            //                new WinnerDetailsModel
            //                {
            //                    Sequence = x.Sequence.Value,
            //                    PublishedAt = x.PublishedAt.Value,
            //                    DisplayName = x.AuthorDisplayName,
            //                    AuthorChannelUrl = x.AuthorChannelUrl,
            //                    Question = x.Question,
            //                    Answer = x.Answer,
            //                    MessageText = x.MessageText,
            //                    Score = x.Score,
            //                    Gap = x.Gap.Value,
            //                    TotalAnswersOfUser = x.UserAnswerCount
            //                }).OrderByDescending(x => x.Score).ToList();
            //    }
            //}

            //if (result.Any())
            //{
            //    dgwWinnerDetail.DataSource = result;
            //    dgwWinnerDetail.FormatGrid();
            //    dgwWinnerDetail.Columns["AuthorChannelUrl"].Visible = false;
            //}

            //this.Cursor = Cursors.Default;
        }

        private async void buttonShowStreams_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwStreams.DataSource = null;
            //await Task.Delay(100);
            var model = new List<VideoModel>();

            using (var db = new DbEntities())
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
            dgwChats.DataSource = null;
            labelChatCount.Text = "0";

            if (dgwStreams.SelectedRows.Count != 1)
                return;

            var stream = dgwStreams.SelectedRows[0].DataBoundItem as VideoModel;
            this.Cursor = Cursors.WaitCursor;
            //await Task.Delay(100);
            //var model = new List<ChatsViewModel>();

            //await Task.Run(() =>
            //{
            //    using (var db = new DbEntities())
            //    {
            //        model = db.liveChatMessages.Where(x => x.VideoId == stream.Id).Select(x => new ChatsViewModel
            //        {
            //            AuthorChannelId = x.AuthorChannelId,
            //            PublishedAt = x.PublishedAt.Value,
            //            AuthorChannelUrl = x.AuthorChannelUrl,
            //            AuthorDisplayName = x.AuthorDisplayName,
            //            MessageText = x.MessageText
            //        }).ToList();
            //    }
            //});

            var userStr = string.IsNullOrEmpty(textBoxSearchUser.Text.Trim())
                ? ""
                : $" AND AuthorDisplayName LIKE '%{textBoxSearchUser.Text.Trim()}%' ";

            Helper.CnnOpen();
            var model = Helper.Cnn.Query<ChatsViewModel>($@"
                Select AuthorChannelId,PublishedAt,AuthorChannelUrl,AuthorDisplayName,MessageText
                From liveChatMessages
                Where VideoId=@Id {userStr}", new { Id = stream.Id }, commandTimeout: 3000).ToList();

            Helper.CnnClose();

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

                using (var db = new DbEntities())
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
                    using (var db = new DbEntities())
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
            new FrmQuestions(Enumeration.FormTypeEnum.New).ShowDialog();
        }

        private async void buttonShowQList_Click(object sender, EventArgs e)
        {
            await Task.Delay(100);
            if (timerQuestion.Enabled && !string.IsNullOrEmpty(textBoxQuestionStartAt.Text))
            {
                MessageBox.Show(
                    "Önce devam eden soruyu bitirmek için 'Yeni Soru' tuşunu kullanın. Daha sonra soru listesine girebilirsiniz.",
                    MessageHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewQuestion();
            var frm = new FrmQuestions(Enumeration.FormTypeEnum.Select);
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

                using (var db = new DbEntities())
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

        private void dtQAAnalysis_ValueChanged(object sender, EventArgs e)
        {
            var date = (sender as DateTimePicker).Value;
            dtWinnerOfDay.Value = date;
            dtQAAnalysis.Value = date;
            dtAllStreams.Value = date;
            dtViewerCount.Value = date;
            dtWinnerOfWeek.Value = date;
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

            using (var db = new DbEntities())
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
                using (var db = new DbEntities())
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

        private async void TimerCommentAdd_Tick(object sender, EventArgs e)
        {
            await Task.Delay(100);
            if (!string.IsNullOrEmpty(textBoxVideoId.Text) && !string.IsNullOrEmpty(_newComment))
                await _youtubeApi.AddComment(textBoxVideoId.Text, _newComment);
            _newComment = "";
            timerCommentAdd.Stop();
        }

        private void dgwCompetitionHeader_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwCompetitionDetail.DataSource = null;
            labelSelectedComp.Text = "";
            if (e.RowIndex < 0)
                return;

            this.Cursor = Cursors.WaitCursor;
            var data = dgwCompetitionHeader.Rows[e.RowIndex].DataBoundItem as CompetitionModel;
            labelSelectedComp.Text = data.Question;

            Helper.CnnOpen();
            var result = Helper.Cnn.Query<CompetitionResultModel>(@"
                Select * FROM dbo.fn_validAnswers (@Id)", new { Id = data.Id }, commandTimeout: 300).ToList();

            if (result.Any())
            {
                dgwCompetitionDetail.DataSource = result;
                dgwCompetitionDetail.FormatGrid(true);
            }

            Helper.CnnClose();
            this.Cursor = Cursors.Default;
        }

        private void dgwWinnerOfDay_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwWinnerDetail.DataSource = null;
            labelSelectedUser.Text = "";

            if (e.RowIndex < 0)
                return;

            var data = dgwWinnerOfDay.Rows[e.RowIndex].DataBoundItem as WinnerOfDayModel;
            labelSelectedUser.Text = data.DisplayName;

            Helper.CnnOpen();
            var result = Helper.Cnn.Query<WinnerDetailsModel>(@"
                    Select Sequence
	                    ,PublishedAt 
	                    ,AuthorDisplayName as DisplayName
	                    ,AuthorChannelUrl
	                    ,Question
	                    ,Answer
	                    ,MessageText
	                    ,Score
	                    ,Gap
	                    ,1 as TotalAnswersOfUser
	                    ,AuthorChannelId
                    From validAnswers_vw 
                    Where AuthorChannelId=@Channel
	                    AND CAST(PublishedAt AS DATE)=CAST(@date AS DATE) "
                , new { Channel = data.AuthorChannelId, date = dtQAAnalysis.Value.Date }, commandTimeout: 300).ToList();

            Helper.CnnClose();

            if (result.Any())
            {
                dgwWinnerDetail.DataSource = result;
                dgwWinnerDetail.FormatGrid();
                dgwWinnerDetail.Columns["AuthorChannelUrl"].Visible = false;
            }

            this.Cursor = Cursors.Default;
        }

        private void textBoxSearchUser_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSearchUser.Text.Trim()))
                buttonShowChats.PerformClick();
        }

        private void textBoxSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonShowChats.PerformClick();
        }

        private void buttonSelectBroadcast_Click(object sender, EventArgs e)
        {
            if (dgwLiveVideos.CurrentRow == null || CurrentBroadcast == null)
            {
                MessageBox.Show("Listeden yayın seçin!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(CurrentBroadcast.LiveChatId))
            {
                MessageBox.Show("Seçilen yayının LiveChatId bilgisi boş olamaz!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Başka yayın seçilememesi için butonu kapatıyoruz.
            buttonSelectBroadcast.Enabled = false;
            buttonGetLiveBroadCasts.Enabled = false;
            buttonShowService.Enabled = true;
            buttonShowComp.Enabled = true;
            buttonShowResultForm.Enabled = true;
            labelVideoInfo.Visible = true;
            dgwLiveVideos.Enabled = false;
            dgwLiveVideos.Cursor = Cursors.No;
            CheckSubForms();
        }

        private void _frmCompetitions_QuestionCompleted(object sender, ShowResultModel e)
        {
            if (CheckSubForms())
            {
                _frmQuestionSummary.ShowResults(e);
            }
        }

        private void buttonShowService_Click(object sender, EventArgs e)
        {
            if (CheckSubForms())
            {
                _frmGetChats.Show();
                _frmGetChats.BringToFront();
            }
        }

        private void buttonShowComp_Click(object sender, EventArgs e)
        {
            if (CheckSubForms())
            {
                _frmCompetitions.Show();
                _frmCompetitions.BringToFront();
            }
        }

        private bool CheckSubForms()
        {
            if (CurrentBroadcast == null)
            {
                MessageBox.Show("Önce bir yayın seçmelisiniz!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (Application.OpenForms.OfType<frmGetChats>().Count() == 0)
                _frmGetChats = new frmGetChats(CurrentBroadcast.Id, CurrentBroadcast.LiveChatId, _youtubeApi);

            if (Application.OpenForms.OfType<frmCompetitions>().Count() == 0)
                _frmCompetitions = new frmCompetitions(CurrentBroadcast.Id, CurrentBroadcast.LiveChatId, _youtubeApi);

            if (Application.OpenForms.OfType<FrmQuestionSummary>().Count() == 0)
            {
                _frmQuestionSummary = new FrmQuestionSummary();
                _frmCompetitions.QuestionCompleted += _frmCompetitions_QuestionCompleted;
            }

            return true;
        }

        private void buttonShowResultForm_Click(object sender, EventArgs e)
        {
            _frmQuestionSummary.Show();
            _frmQuestionSummary.BringToFront();
        }

        private void dtWinnerOfWeek_ValueChanged(object sender, EventArgs e)
        {
            var start = dtWinnerOfWeek.Value.GetFirstDayOfWeek();
            var end = dtWinnerOfWeek.Value.GetLastWorkDayOfWeek();
            labelWeekDays.Text = $"{start.ToLongDateString()} - {end.ToLongDateString()}";
        }

        private async void buttonShowWinnerOfWeek_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwWinnerOfWeek.DataSource = null;

            var start = dtWinnerOfWeek.Value.GetFirstDayOfWeek();
            var end = dtWinnerOfWeek.Value.GetLastWorkDayOfWeek();

            Helper.CnnOpen();
            var weekDetail = Helper.Cnn.Query<WinnerOfDayModel>($@"
                     SELECT TOP 20 AuthorChannelId
	                    ,AuthorChannelUrl
	                    ,AuthorDisplayName as DisplayName
	                    ,SUM(Score) TotalScore
	                    ,COUNT(DISTINCT(CompetitionId)) TotalCompetitions
	                    ,COUNT(DISTINCT(CAST(PublishedAt AS DATE))) TotalDays
	                    ,ROW_NUMBER() OVER (ORDER BY SUM(Score) DESC) Sequence
	                    ,'' as IsSubscripted
                    FROM ValidAnswers_vw
                    WHERE CAST(PublishedAt AS DATE) BETWEEN CAST('{start}' as DATE) AND CAST('{end}' as DATE)
                    GROUP BY AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
                    ORDER BY TotalScore DESC ").OrderByDescending(x => x.TotalScore).ToList();

            Helper.CnnClose();

            if (weekDetail.Any())
            {
                dgwWinnerOfWeek.DataSource = weekDetail.ToSortableGridList();
                dgwWinnerOfWeek.FormatGrid(true);
            }

            this.Cursor = Cursors.Default;
            dgwWinnerOfWeek.Columns.Cast<DataGridViewColumn>().ToList()
                .ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            labelCheckSubscriptionWeek.Visible = true;

            await CheckUsersForSubscription(dgwWinnerOfWeek);

            labelCheckSubscriptionWeek.Visible = false;
            dgwWinnerOfWeek.Columns.Cast<DataGridViewColumn>().ToList()
                .ForEach(f => f.SortMode = DataGridViewColumnSortMode.Automatic);
        }
    }
}