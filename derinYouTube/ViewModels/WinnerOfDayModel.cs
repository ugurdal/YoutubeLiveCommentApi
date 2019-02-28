using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class WinnerOfDayModel
    {
        [Browsable(false)]
        public DateTime Day { get; set; }
        public long Sequence { get; set; }
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }
        [DisplayName("Total Score")]
        public int TotalScore { get; set; }
        [DisplayName("Total Competitions")]
        public int TotalCompetitions { get; set; }
        [DisplayName("Channel Url")]
        public string AuthorChannelUrl { get; set; }
        [Browsable(false)]
        public string AuthorChannelId { get; set; }
    }
}
