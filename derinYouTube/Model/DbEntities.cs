namespace derinYouTube.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;

    public partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
        }

        public virtual DbSet<competitionAnswers> competitionAnswers { get; set; }
        public virtual DbSet<competitions> competitions { get; set; }
        public virtual DbSet<liveBroadcasts> liveBroadcasts { get; set; }
        public virtual DbSet<liveBroadcastsViewCount> liveBroadcastsViewCount { get; set; }
        public virtual DbSet<liveChatMessages> liveChatMessages { get; set; }
        public virtual DbSet<questions> questions { get; set; }
        public virtual DbSet<chatCountByTime_vw> chatCountByTime_vw { get; set; }
        public virtual DbSet<competitions_vw> competitions_vw { get; set; }
        public virtual DbSet<validAnswers_vw> validAnswers_vw { get; set; }
        public virtual DbSet<viewerCountByTime_vw> viewerCountByTime_vw { get; set; }
        public virtual DbSet<winnerOfDay_vw> winnerOfDay_vw { get; set; }

        public virtual IList<winnerOfDay_vw> winnerOfDay_proc(DateTime date)
        {
            IList<winnerOfDay_vw> result = ((IObjectContextAdapter) this).ObjectContext
                .ExecuteStoreQuery<winnerOfDay_vw>("getWinnerOfDay @p0", date).ToList<winnerOfDay_vw>();
            return result;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<competitions>()
                .Property(e => e.LiveChatId)
                .IsUnicode(false);

            modelBuilder.Entity<competitions>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<competitions>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<competitions>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.BroadcastId)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.ChannelId)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.LiveChatId)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.LiveStatus)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcasts>()
                .Property(e => e.ChannelTitle)
                .IsUnicode(false);

            modelBuilder.Entity<liveBroadcastsViewCount>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.MessageId)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.AuthorChannelId)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.AuthorChannelUrl)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.AuthorDisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.LiveChatId)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.MessageText)
                .IsUnicode(false);

            modelBuilder.Entity<liveChatMessages>()
                .Property(e => e.NumericMessage)
                .IsUnicode(false);
            
            modelBuilder.Entity<questions>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<questions>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<questions>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<chatCountByTime_vw>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<chatCountByTime_vw>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<competitions_vw>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<competitions_vw>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<competitions_vw>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.AuthorChannelId)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.AuthorChannelUrl)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.AuthorDisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.LiveChatId)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.MessageText)
                .IsUnicode(false);

            modelBuilder.Entity<validAnswers_vw>()
                .Property(e => e.Gap)
                .HasPrecision(37, 0);

            modelBuilder.Entity<viewerCountByTime_vw>()
                .Property(e => e.VideoId)
                .IsUnicode(false);

            modelBuilder.Entity<viewerCountByTime_vw>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<winnerOfDay_vw>()
                .Property(e => e.AuthorChannelId)
                .IsUnicode(false);

            modelBuilder.Entity<winnerOfDay_vw>()
                .Property(e => e.AuthorChannelUrl)
                .IsUnicode(false);

            modelBuilder.Entity<winnerOfDay_vw>()
                .Property(e => e.AuthorDisplayName)
                .IsUnicode(false);
        }
    }
}
