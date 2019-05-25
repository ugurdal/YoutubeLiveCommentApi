using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class QuestionViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Sıra")]
        public int Order
        {
            get
            {
                return Helper.IsNumeric(this.Code)
                    ? Convert.ToInt32(this.Code)
                    : 999;
            }
        }

        [Browsable(false)]
        public string Code { get; set; }

        [DisplayName("Soru")]
        public string Question { get; set; }

        [DisplayName("Cevap")]
        public string Answer { get; set; }

        [DisplayName("Kayıt Tarihi")]
        public DateTime InsertDate { get; set; }

        [DisplayName("Sorulacağı Tarih")]
        public DateTime QuestionDate { get; set; }
    }
}
