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
        public string Question { get; set; }
        public string Answer { get; set; }
        [Browsable(false)]
        public DateTime StartTime { get; set; }
        [Browsable(false)]
        public DateTime EndTime { get; set; }
        [DisplayName("Start Time")]
        public string StartTimeStr
        {
            get { return this.StartTime.ToString(); }
        }
        [DisplayName("End Time")]
        public string EndTimeStr
        {
            get { return this.EndTime.ToString(); }
        }
        [DisplayName("Total Answers")]
        public int TotalAnswers { get; set; }
        [DisplayName("Valid Answers")]
        public int ValidAnswers { get; set; }
        [DisplayName("Total Users")]
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
