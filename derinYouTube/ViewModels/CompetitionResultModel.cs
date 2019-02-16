using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class CompetitionResultModel
    {
        public long Sequence { get; set; }
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }
        [Browsable(false)]
        public DateTime PublishedAt { get; set; }
        [DisplayName("Puslished Time")]
        public string PuslishedTime
        {
            get { return this.PublishedAt.ToString(); }
        }
        public int Score { get; set; }
        public string Answer { get; set; }
        [DisplayName("Users Answer")]
        public string MessageText { get; set; }
        public decimal Gap { get; set; }
        [DisplayName("Channel Url")]
        public string AuthorChannelUrl { get; set; }
    }
}
