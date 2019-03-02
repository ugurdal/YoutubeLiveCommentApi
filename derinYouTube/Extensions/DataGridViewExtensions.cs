using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace derinYouTube.Extensions
{
    public static class DataGridViewExtensions
    {
        private static string[] ColorColumns = new[]
        {
            "Score",
            "TotalAnswers",
            "ValidAnswers",
            "Answer",
            "MessageText",
            "TotalScore",
            "TotalCompetitions",
            "TotalAnswersOfUser"
        };

        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public static void FormatGrid(this DataGridView dgv)
        {
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.ValueType == typeof(decimal))
                {
                    //column.DefaultCellStyle.Format = "N0";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if ((column.ValueType == typeof(int) || column.ValueType == typeof(byte)) && column.Index != 0)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (ColorColumns.Contains(column.Name))
                {
                    column.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    column.DefaultCellStyle.ForeColor = Color.DarkRed;
                }

                //if (column.ValueType == typeof(DateTime))
                //{
                //    column.DefaultCellStyle.Format = "dd.MM.yyyy";
                //}

                //column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //column.HeaderCell.Style.Font = new Font("Tahoma", 9F);
            }

            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //for (int i = 0; i < dgv.Rows.Count; i++)
            //{
            //    dgv.Rows[i].Height = 25;
            //}
        }
    }
}
