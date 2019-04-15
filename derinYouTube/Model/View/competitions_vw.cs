namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class competitions_vw
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(800)]
        public string VideoId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1000)]
        public string Question { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1000)]
        public string Answer { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ValidAnswers { get; set; }

        public int? TotalAnswers { get; set; }

        public int? TotalUser { get; set; }
    }
}
