using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using derinYouTube.Extensions;
using derinYouTube.Model;
using derinYouTube.ViewModels;

namespace derinYouTube
{
    public partial class FrmQuestions : Form
    {
        private readonly FormTypeEnum _type;
        public QuestionViewModel SelectedQuestion;

        public enum FormTypeEnum
        {
            New = 0,
            Select = 1
        }

        public FrmQuestions(FormTypeEnum type)
        {
            _type = type;
            InitializeComponent();
            this.dgwQ.DoubleBuffered(true);
        }

        private void buttonNewQuestions_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            richTextBoxQuestion.Text = "";
            richTextBoxAnswers.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxQuestion.Text) ||
                string.IsNullOrEmpty(richTextBoxAnswers.Text) || !Helper.IsNumericArti(richTextBoxAnswers.Text))
            {
                MessageBox.Show("Sıra, soru ve cevap doldurulmalı. Cevap numerik olmalı!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            using (var db = new YoutubeCommentDbEntities())
            {
                db.questions.Add(new questions
                {
                    Code = numOrder.Value.ToString(),
                    Question = richTextBoxQuestion.Text,
                    Answer = richTextBoxAnswers.Text,
                    InsertDate = DateTime.Now
                });
                db.SaveChanges();
            }

            Clear();
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            dgwQ.DataSource = null;
            using (var db = new YoutubeCommentDbEntities())
            {
                var model = db.questions.Select(x => new QuestionViewModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Question = x.Question,
                    Answer = x.Answer,
                    InsertDate = x.InsertDate
                }).ToList().OrderBy(x => x.Order);

                if (model.Any())
                {
                    dgwQ.DataSource = model.ToSortableGridList();
                    dgwQ.FormatGrid();
                }

                labelCount.Text = dgwQ.RowCount.ToString();
            }
        }

        private void FrmQuestions_Load(object sender, EventArgs e)
        {
            if (_type == FormTypeEnum.Select)
            {
                tsButtonDelete.Visible = false;
                tsButtonSave.Visible = false;
                tsButtonNew.Visible = false;
                richTextBoxAnswers.Visible = false;
                richTextBoxQuestion.Visible = false;
                numOrder.Visible = false;
                labelA.Visible = false;
                labelQ.Visible = false;
                labelOrder.Visible = false;

                splitContainerQ.SplitterDistance = 0;
                this.Text = "Soru Seçimi";
            }

            ShowQuestions();
        }

        private void dgwQ_SelectionChanged(object sender, EventArgs e)
        {
            if (_type == FormTypeEnum.New)
            {
                tsButtonDelete.Visible = dgwQ.SelectedRows.Count != 0;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgwQ.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Seçili sorular silinecek, emin misiniz?", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    using (var db = new YoutubeCommentDbEntities())
                    {
                        foreach (DataGridViewRow row in dgwQ.SelectedRows)
                        {
                            var data = row.DataBoundItem as QuestionViewModel;
                            var question = db.questions.Find(data.Id);
                            if (question != null)
                                db.questions.Remove(question);
                        }

                        db.SaveChanges();
                    }

                    ShowQuestions();
                }
            }
        }

        private void dgwQ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_type == FormTypeEnum.Select && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                var data = dgwQ.Rows[e.RowIndex].DataBoundItem as QuestionViewModel;
                SelectedQuestion = data;
                DialogResult = DialogResult.OK;
            }
        }

        private void richTextBoxAnswers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}