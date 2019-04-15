namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class winnerOfDay_vw
    {
        [Column(TypeName = "date")]
        public DateTime? Day { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(1000)]
        public string AuthorChannelId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1000)]
        public string AuthorChannelUrl { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1000)]
        public string AuthorDisplayName { get; set; }

        public int? TotalScore { get; set; }

        public int? TotalCompetition { get; set; }

        public long? Sequence { get; set; }
    }
}
