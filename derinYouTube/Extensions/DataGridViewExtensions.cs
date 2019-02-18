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
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if ((column.ValueType == typeof(int) || column.ValueType == typeof(byte)) && column.Index != 0)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                //if (column.ValueType == typeof(DateTime))
                //{
                //    column.DefaultCellStyle.Format = "dd.MM.yyyy";
                //}

                //column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //column.HeaderCell.Style.Font = new Font("Tahoma", 9F);
            }

            //for (int i = 0; i < dgv.Rows.Count; i++)
            //{
            //    dgv.Rows[i].Height = 25;
            //}
        }
    }
}
