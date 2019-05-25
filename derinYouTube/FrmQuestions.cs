using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        private readonly Enumeration.FormTypeEnum _type;
        public QuestionViewModel SelectedQuestion;



        public FrmQuestions(Enumeration.FormTypeEnum type)
        {
            _type = type;
            InitializeComponent();
            this.dgwQ.DoubleBuffered(true);
            dtQuestionDate.Value = DateTime.Today;
        }

        private void buttonNewQuestions_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            richTextBoxQuestion.Text = "";
            richTextBoxAnswers.Text = "";

            numOrder.Value = dgwQ.RowCount + 1;
            richTextBoxQuestion.Focus();
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

            try
            {
                using (var db = new DbEntities())
                {
                    db.questions.Add(new questions
                    {
                        Code = numOrder.Value.ToString(),
                        Question = richTextBoxQuestion.Text,
                        Answer = richTextBoxAnswers.Text,
                        InsertDate = DateTime.Now,
                        QuestionDate = dtQuestionDate.Value
                    });
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show($"Soru kaydedilemedi..\r\n{ex.ToMessage()}", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Soru kaydedilemedi..\r\n{ex.Message + ex.InnerException?.Message}", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ShowQuestions();
            Clear();
        }

        private void ShowQuestions()
        {
            dgwQ.DataSource = null;
            using (var db = new DbEntities())
            {
                var model = db.questions.Where(x => DbFunctions.TruncateTime(x.QuestionDate) == DbFunctions.TruncateTime(dtQuestionDate.Value))
                    .Select(x => new QuestionViewModel
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Question = x.Question,
                        Answer = x.Answer,
                        InsertDate = x.InsertDate,
                        QuestionDate = x.QuestionDate
                    }).ToList().OrderBy(x => x.Order);

                if (model.Any())
                {
                    dgwQ.DataSource = model.ToSortableGridList();
                    dgwQ.FormatGrid();

                    if (_type == Enumeration.FormTypeEnum.Select)
                        dgwQ.Columns["InsertDate"].Visible = false;
                }

                labelCount.Text = dgwQ.RowCount.ToString();
            }
        }

        private void FrmQuestions_Load(object sender, EventArgs e)
        {
            if (_type == Enumeration.FormTypeEnum.Select)
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
            if (_type == Enumeration.FormTypeEnum.New)
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
                    try
                    {
                        using (var db = new DbEntities())
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

                    catch (DbEntityValidationException ex)
                    {
                        MessageBox.Show($"Soru kaydedilemedi..\r\n{ex.ToMessage()}", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Soru kaydedilemedi..\r\n{ex.Message + ex.InnerException?.Message}", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void dgwQ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_type == Enumeration.FormTypeEnum.Select && e.RowIndex != -1 && e.ColumnIndex != -1)
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

        private void DtQuestionDate_ValueChanged(object sender, EventArgs e)
        {
            ShowQuestions();
        }
    }
}