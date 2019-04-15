namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class competitions
    {
        public competitions()
        {
            this.LiveChatId = "";
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        //[Required]
        [StringLength(800)]
        public string LiveChatId { get; set; }

        [Required]
        [StringLength(800)]
        public string VideoId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Question { get; set; }

        [Required]
        [StringLength(1000)]
        public string Answer { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
