namespace derinYouTube.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class competitionAnswers
    {
        public int Id { get; set; }

        public int Fk_Competition { get; set; }

        public int Fk_LiveChatMessage { get; set; }

        public int Score { get; set; }

        public bool IsValid { get; set; }

        public virtual competitions competitions { get; set; }

        public virtual liveChatMessages liveChatMessages { get; set; }
    }
}
