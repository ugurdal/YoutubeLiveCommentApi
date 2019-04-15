namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class liveChatMessages
    {
        public int Id { get; set; }

        [Required]
        public string MessageId { get; set; }

        [Required]
        [StringLength(1000)]
        public string AuthorChannelId { get; set; }

        [Required]
        [StringLength(1000)]
        public string AuthorChannelUrl { get; set; }

        [Required]
        [StringLength(1000)]
        public string AuthorDisplayName { get; set; }

        [Required]
        [StringLength(800)]
        public string LiveChatId { get; set; }

        [Required]
        [StringLength(800)]
        public string VideoId { get; set; }

        public DateTime? PublishedAt { get; set; }

        public bool? HasDisplayContent { get; set; }

        [Required]
        public string MessageText { get; set; }

        public bool? IsVerified { get; set; }

        public bool? IsChatOwner { get; set; }

        public bool? IsChatSponsor { get; set; }

        public bool? IsChatModerator { get; set; }

        public bool IsMessageNumeric { get; set; }

        [Required]
        [StringLength(1000)]
        public string NumericMessage { get; set; }
    }
}