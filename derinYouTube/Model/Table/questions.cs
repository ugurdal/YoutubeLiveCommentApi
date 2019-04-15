namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class questions
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(800)]
        public string Question { get; set; }

        [Required]
        [StringLength(800)]
        public string Answer { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime InsertDate { get; set; }
    }
}
