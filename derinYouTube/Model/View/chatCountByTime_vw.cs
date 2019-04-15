namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class chatCountByTime_vw
    {
        [Key]
        [StringLength(800)]
        public string VideoId { get; set; }

        [StringLength(5)]
        public string Time { get; set; }

        public int? ChatCount { get; set; }
    }
}
