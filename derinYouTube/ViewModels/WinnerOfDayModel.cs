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
        
        [DisplayName("Sıra")]
        public long Sequence { get; set; }
        
        [DisplayName("İzleyici Adı")]
        public string DisplayName { get; set; }
        
        [DisplayName("Toplam Puan")]
        public int TotalScore { get; set; }
        
        [DisplayName("Kaç Yarışmaya Katıldı?")]
        public int TotalCompetitions { get; set; }

        [DisplayName("Kaç Farklı Gün Yarıştı?")]
        public int TotalDays { get; set; }

        [DisplayName("Kanal Url")]
        public string AuthorChannelUrl { get; set; }
        
        [Browsable(false)]
        public string AuthorChannelId { get; set; }

        [DisplayName("Migros Tv Kanalına Üye Mi?")]
        public string IsSubscripted { get; set; }
    }
}
