using System;
using System.ComponentModel;

namespace derinYouTube.ViewModels
{
    public class VideoModel
    {
        public string Id { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [Browsable(false)]
        public string Description { get; set; }
        [DisplayName("Yayın Saati")]
        public DateTime? PublishedDate { get; set; }
        [DisplayName("Kanal Id")]
        public string ChannelId { get; set; }
        [Browsable(false)]
        public string ChannelTitle { get; set; }
        [DisplayName("Başlangıç Saati")]
        public DateTime? ActualStartTime { get; set; }
        [DisplayName("Bitiş Saati")]
        public DateTime? ActualEndTime { get; set; }
        [DisplayName("Durum")]
        public string LiveStatus { get; set; }
        [DisplayName("Live Chat Id")]
        public string LiveChatId { get; set; }
        [Browsable(false)]
        public DateTime? ScheduledStartTime { get; set; }
    }
}
    
