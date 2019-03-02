using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class CompetitionModel
    {
        //[Browsable(false)]
        public int Id { get; set; }
        public string VideoId { get; set; }
        [DisplayName("Soru")]
        public string Question { get; set; }
        [DisplayName("Cevap")]
        public string Answer { get; set; }
        [Browsable(false)]
        public DateTime StartTime { get; set; }
        [Browsable(false)]
        public DateTime EndTime { get; set; }
        [DisplayName("Başlangıç Saati")]
        public string StartTimeStr
        {
            get { return this.StartTime.ToString(); }
        }
        [DisplayName("Bitiş Saati")]
        public string EndTimeStr
        {
            get { return this.EndTime.ToString(); }
        }
        [DisplayName("Toplam Cevap Sayısı")]
        public int TotalAnswers { get; set; }
        [DisplayName("Geçerli Cevap Sayısı")]
        public int ValidAnswers { get; set; }
        [DisplayName("Kaç Kişi Cevap Verdi?")]
        public int UserCount { get; set; }
        public string Duration
        {
            get
            {
                TimeSpan span = this.EndTime.Subtract(this.StartTime);
                return $"{span.Minutes} min {span.Seconds} sec";
            }
        }
    }
}
