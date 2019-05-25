using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using derinYouTube.Extensions;

namespace derinYouTube.ViewModels
{
    public class CompetitionResultModel
    {
        [DisplayName("Sıra")]
        public long Sequence { get; set; }
        
        [DisplayName("İzleyici Adı")]
        public string DisplayName { get; set; }
        
        [Browsable(false)]
        public DateTime PublishedAt { get; set; }
        
        [DisplayName("Mesaj Saati")]
        public string PuslishedTime
        {
            get { return this.PublishedAt.ToTarih() ; }
        }
        
        [DisplayName("Puan")]
        public int Score { get; set; }
        
        [Browsable(false)]
        public string Answer { get; set; }
        
        [DisplayName("İzleyicinin Cevabı")]
        public string MessageText { get; set; }
        
        [DisplayName("Fark")]
        public decimal Gap { get; set; }
        
        [Browsable(false)]
        [DisplayName("Kaç Cevap Yazdı?")] 
        public int TotalAnswersOfUser { get; set; }
        
        [DisplayName("Kanal Url")]
        public string AuthorChannelUrl { get; set; }
        
        [Browsable(false)]
        public string AuthorChannelId { get; set; }
    }
}
