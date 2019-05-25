using Dapper;
using derinYouTube.Extensions;
using derinYouTube.Model;
using derinYouTube.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derinYouTube
{
    public partial class frmGetChats : Form
    {
        private string _videoId;
        private string _liveChatId;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private LinkedList<LiveChatModel> _liveChats;
        private readonly YouTubeApi _youtubeApi;
        private int _chatCount;
        private int _requestCount;

        public frmGetChats(string videoId, string liveChatId, YouTubeApi api)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _videoId = videoId;
            _liveChatId = liveChatId;
            Control.CheckForIllegalCrossThreadCalls = false;
            _youtubeApi = api;

            timerViewerCount.Stop();
            timerException.Stop();
            timerChatCount.Stop();
        }

        private int ChatCount
        {
            get { return _chatCount; }
            set
            {
                Task.Run(() =>
                {
                    _chatCount = value;
                    textBoxChatCount.Text = _chatCount.ToString();
                });
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

        private void FrmGetChats_Load(object sender, EventArgs e)
        {
            textBoxVideoId.Text = _videoId;
            textBoxLiveChatId.Text = _liveChatId;
        }

        private void TextBoxVideoId_TextChanged(object sender, EventArgs e)
        {
            _videoId = textBoxVideoId.Text;
        }

        private void TextBoxLiveChatId_TextChanged(object sender, EventArgs e)
        {
            _liveChatId = textBoxLiveChatId.Text;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (_tokenSource.IsCancellationRequested)
                return;

            if (DialogResult.Yes == MessageBox.Show("Servis durdurulacak, emin misiniz?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                _tokenSource.Cancel();
                buttonGetChats.Enabled = true;
                pbWorking.Visible = false;
                timerViewerCount.Stop();
            }
        }


        private async void ButtonGetChats_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLiveChatId.Text))
            {
                MessageBox.Show("Live Chat ID okunamadı!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            timerViewerCount.Start();
            timerChatCount.Start();
            await Task.Delay(200);

            _tokenSource = new CancellationTokenSource();
            _liveChats = new LinkedList<LiveChatModel>();
            buttonGetChats.Enabled = false;
            pbWorking.Visible = true;
            ChatCount = 0;

            try
            {
                //TODO: Yoğunluk her sn istek geliyor. Progress bunlardan birini işlemeden diğer istek gelirse hata alacak veya kaydemeyecek. Çözüm bulunmalı
                Progress<ReportChatModel> progress1 = new Progress<ReportChatModel>();
                progress1.ProgressChanged += ReportProgress;

                Progress<ReportChatModel> progress2 = new Progress<ReportChatModel>();
                progress2.ProgressChanged += ReportProgress2;

                await _youtubeApi.GetLiveChatsAsync(textBoxLiveChatId.Text, textBoxVideoId.Text, _tokenSource.Token, progress1);
                //await Task.Delay(5000);
                //_youtubeApi.GetLiveChatsAsync(textBoxLiveChatId.Text, textBoxVideoId.Text, _tokenSource.Token, progress2);
            }
            catch (OperationCanceledException ox)
            {
                MessageBox.Show($"Servis durduruldu.\r\"{ox.Message}", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
                            MessageBox.Show($"Yorumlar veritabanına kaydedilemedi!\r\n{ex.Message}", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            });

            //ClearMultipleAnswers();
        }

        private async Task SaveChatsToDatabase2(LinkedList<LiveChatModel> liveChats, long? pollingIntervalMillis)
        {
            if (liveChats == null || !liveChats.Any())
                return;

            CurrentService = 2;
            textBoxFirstChatTime.Text = liveChats.First.Value.PublishedAt;
            textBoxLastChatTime.Text = liveChats.Last.Value.PublishedAt;
            textBoxChatCountInPackage.Text = liveChats.Count.ToString();
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
                            MessageBox.Show($"Yorumlar veritabanına kaydedilemedi!\r\n{ex.Message}", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            });

            //ClearMultipleAnswers();
        }

        private async void TimerViewerCount_Tick(object sender, EventArgs e)
        {
            await Task.Delay(200);
            try
            {
                await Task.Run(() =>
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
                });
            }
            catch (Exception ex)
            {
                ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
            }
        }

        private void TimerException_Tick(object sender, EventArgs e)
        {
            labelShowError.Text = "";
            labelShowError.Visible = false;
            timerException.Stop();
        }

        private async void TimerChatCount_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
              {
                  try
                  {
                      using (var connection = new SqlConnection(Helper.ConnectionString))
                      {
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

        private void frmGetChats_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
