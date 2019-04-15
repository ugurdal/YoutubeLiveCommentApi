namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class liveBroadcasts
    {
        public int Id { get; set; }

        [Required]
        [StringLength(800)]
        public string BroadcastId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string ChannelId { get; set; }

        //[Required]
        [StringLength(800)]
        public string LiveChatId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string LiveStatus { get; set; }

        //[Required]
        public string ChannelTitle { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ActualStartTime { get; set; }

        public DateTime? ActualEndTime { get; set; }

        public DateTime? ScheduledStartTime { get; set; }

        public liveBroadcasts()
        {
            this.LiveChatId = "";
            this.ChannelTitle = "";
        }
    }
}
