namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class validAnswers_vw
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompetitionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1000)]
        public string AuthorChannelId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1000)]
        public string AuthorChannelUrl { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1000)]
        public string AuthorDisplayName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Score { get; set; }

        public DateTime? PublishedAt { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(800)]
        public string LiveChatId { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(800)]
        public string VideoId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1000)]
        public string Question { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(1000)]
        public string Answer { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(1000)]
        public string MessageText { get; set; }

        public decimal? Gap { get; set; }

        public long? Sequence { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserAnswerCount { get; set; }
    }
}
