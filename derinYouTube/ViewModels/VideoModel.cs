using System;

namespace derinYouTube.ViewModels
{
    public class VideoModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public string LiveStatus { get; set; }
        public string LiveChatId { get; set; }
        public DateTime? ScheduledStartTime { get; set; }
    }
}
    
