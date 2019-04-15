namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("liveBroadcastsViewCount")]
    public partial class liveBroadcastsViewCount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(800)]
        public string VideoId { get; set; }

        public DateTime Date { get; set; }

        public long Count { get; set; }
    }
}
