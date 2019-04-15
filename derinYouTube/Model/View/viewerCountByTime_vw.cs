namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class viewerCountByTime_vw
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(800)]
        public string VideoId { get; set; }

        [StringLength(5)]
        public string Time { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ViewerCount { get; set; }
    }
}
