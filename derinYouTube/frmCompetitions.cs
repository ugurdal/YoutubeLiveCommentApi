using Dapper;
using derinYouTube.Extensions;
using derinYouTube.Model;
using derinYouTube.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derinYouTube
{
    public partial class frmCompetitions : Form
    {
        private List<QuestionViewModel> _questions;
        private int _currentQuestion;
        private string _newComment;
        private readonly string _videoId;
        private readonly string _liveChatId;
        private readonly YouTubeApi _youtubeApi;

        public frmCompetitions(string videoId, string liveChatId, YouTubeApi api)
        {
            InitializeComponent();
            _videoId = videoId;
            _liveChatId = liveChatId;
            _youtubeApi = api;

            dgwAnswers.DoubleBuffered(true);
            dgwAnswers.CellDoubleClick += DataGridViewCellDoubleClick;

            timerQuestion.Stop();
            timerException.Stop();
            timerAnswerCount.Stop();
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

        private void FrmCompetitions_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            if (string.IsNullOrEmpty(_liveChatId) || string.IsNullOrEmpty(_videoId))
            {
                MessageBox.Show("Canlı yayın bilgileri boş, yayın seçtikten sonra giriş yapın!",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }

            using (var db = new DbEntities())
            {
                _questions = db.questions.Where(x => DbFunctions.TruncateTime(x.QuestionDate) == DateTime.Today)
                    .Select(x => new QuestionViewModel
                    {
                        Id = x.Id,
                        Question = x.Question,
                        Answer = x.Answer,
                        Code = x.Code,
                        InsertDate = x.InsertDate,
                        QuestionDate = x.QuestionDate
                    }).ToList();
            }

            if (!_questions.Any() || _questions.Count != 10)
            {
                MessageBox.Show("Tarihi bugün olan 10 soru hazırlanmalı!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            CurrentQuestions = 1;
            buttonQuestionStop.Enabled = false;
        }

        private int CurrentQuestions
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                if (_currentQuestion == 0)
                    return;

                if (timerQuestion.Enabled)
                {
                    MessageBox.Show("Önce devam eden soruyu bitirin!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                NewQuestion();
                var question = _questions.SingleOrDefault(x => x.Order == _currentQuestion);
                if (question == null)
                {
                    MessageBox.Show($"{_currentQuestion } numaralı soru bulunamadı!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                textBoxQuestion.Text = question.Question;
                textBoxAnswers.Text = question.Answer;

                if (_currentQuestion < 1)
                    _currentQuestion = 1;
                if (_currentQuestion > 10)
                    _currentQuestion = 10;

                CheckButtonStates();

                switch (_currentQuestion)
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
            }
        }

        private void NewQuestion()
        {
            labelQuestionId.Text = "0";
            labelQuestionTime.Text = "0";
            textBoxQuestion.Text = "";
            textBoxAnswers.Text = "";
            textBoxQuestionStartAt.Text = "";
            textBoxQuestionStopAt.Text = "";
            richTextBoxAnswerDetails.Text = "";
            buttonQuestionStart.Enabled = true;
            buttonQuestionStop.Enabled = false;
            dgwAnswers.DataSource = null;
            timerQuestion.Stop();
            timerAnswerCount.Stop();
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

        private void ButtonPrevius_Click(object sender, EventArgs e)
        {
            CurrentQuestions--;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            CurrentQuestions++;
        }

        private async void TimerQuestion_Tick(object sender, EventArgs e)
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

        private void CheckButtonStates()
        {
            if (timerQuestion.Enabled)
            {
                buttonNext.Enabled = false;
                buttonPrevius.Enabled = false;
            }
            else
            {
                buttonPrevius.Enabled = CurrentQuestions > 1;
                buttonNext.Enabled = CurrentQuestions < 10;
            }
        }

        private async void ButtonQuestionStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxQuestion.Text) || string.IsNullOrEmpty(textBoxAnswers.Text) ||
                !Helper.IsNumericArti(textBoxAnswers.Text))
            {
                MessageBox.Show("Soru ve cevap doldurulmalı. Cevap numerik olmalı!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            timerQuestion.Start();
            timerAnswerCount.Start();
            CheckButtonStates();

            textBoxQuestionStartAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = true;
            buttonQuestionStart.Enabled = false;
            labelQuestion.Visible = true;
            labelQuestionCount.Visible = true;
            await SaveCompetition();
        }

        private async void ButtonQuestionStop_Click(object sender, EventArgs e)
        {
            timerQuestion.Stop();
            timerAnswerCount.Stop();
            CheckButtonStates();

            textBoxQuestionStopAt.Text = DateTime.Now.ToString();
            buttonQuestionStop.Enabled = false;
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
                            LiveChatId = _liveChatId,
                            VideoId = _videoId,
                            Question = textBoxQuestion.Text,
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

                                db.Database.ExecuteSqlCommand("EXEC clearMultipleChatMessages @p0", _videoId);
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
            await Task.Delay(100);
            this.Cursor = Cursors.WaitCursor;
            dgwAnswers.DataSource = null;
            richTextBoxAnswerDetails.Text = string.Empty;
            var result = new List<CompetitionResultModel>();
            var totalUserCount = 0;
            var totalAnswers = 0;
            var validAnswers = 0;
            var rightAnswers = 0;

            await Task.Run(() =>
            {
                //using (var db = new DbEntities())
                //{
                //    
                //    result = db.validAnswers_vw.Where(x => x.CompetitionId == competitionId).Select(x =>
                //        new CompetitionResultModel
                //        {
                //            Sequence = x.Sequence.Value,
                //            PublishedAt = x.PublishedAt.Value,
                //            DisplayName = x.AuthorDisplayName,
                //            AuthorChannelUrl = x.AuthorChannelUrl,
                //            Answer = x.Answer,
                //            MessageText = x.MessageText,
                //            Score = x.Score,
                //            Gap = x.Gap.Value,
                //            TotalAnswersOfUser = x.UserAnswerCount,
                //            AuthorChannelId = x.AuthorChannelId
                //        }).OrderByDescending(x => x.Score).ToList();
                //}

                Helper.Cnn.Open();
                result = Helper.Cnn.Query<CompetitionResultModel>(@"
                Select Top 100 Sequence
	                ,PublishedAt 
	                ,AuthorDisplayName as DisplayName
	                ,AuthorChannelUrl
	                ,Answer
	                ,MessageText
	                ,Score
	                ,Gap
	                ,1 as TotalAnswersOfUser
	                ,AuthorChannelId
                From validAnswers_vw 
                Where CompetitionId=@Id AND Score>0", new { Id = competitionId }, commandTimeout: 300).ToList();

                Helper.Cnn.Close();
            });

            if (result.Any())
            {
                dgwAnswers.DataSource = result;
                dgwAnswers.FormatGrid(true);
                rightAnswers = result.Count(x => x.Gap == 0m);

                var ix = 1;
                _newComment = "";
                _newComment = $"Sıra: {CurrentQuestions}\r\n";
                _newComment += $"Soru: {textBoxQuestion.Text}\r\n";
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
                //using (var db = new DbEntities())
                //{
                //    var compDetail = db.competitions_vw.FirstOrDefault(x => x.Id == competitionId);
                //    if (compDetail != null)
                //    {
                //        totalAnswers = compDetail.TotalAnswers.Value;
                //        totalUserCount = compDetail.TotalUser.Value;
                //        validAnswers = compDetail.ValidAnswers;
                //    }
                //}

                Helper.Cnn.Open();
                var compDetail = Helper.Cnn.Query<competitions_vw>($"Select * From competitions_vw Where Id={competitionId}").FirstOrDefault();
                if (compDetail != null)
                {
                    totalAnswers = compDetail.TotalAnswers.Value;
                    totalUserCount = compDetail.TotalUser.Value;
                    validAnswers = compDetail.ValidAnswers;
                }
                Helper.Cnn.Close();
            });

            richTextBoxAnswerDetails.Text = $"# Toplam {totalUserCount} farklı kullanıcı cevap verdi.\r\n";
            richTextBoxAnswerDetails.Text += $"# Toplam {totalAnswers} cevap verildi.\r\n";
            richTextBoxAnswerDetails.Text += $"# Geçerli cevap sayısı: {validAnswers}\r\n";
            richTextBoxAnswerDetails.Text += $"# Geçersiz cevap sayısı: {totalAnswers - validAnswers}\r\n";
            richTextBoxAnswerDetails.Text += $"# Doğru cevap sayısı: {rightAnswers}";

            this.Cursor = Cursors.Default;
        }

        private void TimerException_Tick(object sender, EventArgs e)
        {
            labelShowError.Text = "";
            labelShowError.Visible = false;
            timerException.Stop();
        }

        private async void TimerCommentAdd_Tick(object sender, EventArgs e)
        {
            await Task.Delay(100);
            if (!string.IsNullOrEmpty(_newComment))
                await _youtubeApi.AddComment(_videoId, _newComment);
            _newComment = "";
            timerCommentAdd.Stop();
        }

        private async void TimerAnswerCount_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
              {
                  try
                  {
                      Helper.Cnn.Open();
                      if (!string.IsNullOrEmpty(textBoxQuestionStartAt.Text) && string.IsNullOrEmpty(textBoxQuestionStopAt.Text))
                      {
                          var startAt = DateTime.Parse(textBoxQuestionStartAt.Text);
                          var count = Helper.Cnn
                          .Query<int>($"SELECT COUNT(*) FROM dbo.liveChatMessages WHERE VideoId='{_videoId}' AND PublishedAt>='{startAt}'")
                          .First();
                          labelQuestionCount.Text = count.ToString();
                      }
                      Helper.Cnn.Close();
                  }
                  catch (Exception ex)
                  {
                      ShowErrorOnPanel = ex.Message + ex.InnerException?.Message;
                  }
              });
        }

        private void frmCompetitions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
