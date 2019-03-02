﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace derinYouTube.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class YoutubeCommentDbEntities : DbContext
    {
        public YoutubeCommentDbEntities()
            : base("name=YoutubeCommentDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<competitionAnswers> competitionAnswers { get; set; }
        public virtual DbSet<competitions> competitions { get; set; }
        public virtual DbSet<liveChatMessages> liveChatMessages { get; set; }
        public virtual DbSet<competitions_vw> competitions_vw { get; set; }
        public virtual DbSet<winnerOfDay_vw> winnerOfDay_vw { get; set; }
        public virtual DbSet<validAnswers_vw> validAnswers_vw { get; set; }
        public virtual DbSet<questions> questions { get; set; }
        public virtual DbSet<liveBroadcastsViewCount> liveBroadcastsViewCount { get; set; }
        public virtual DbSet<liveBroadcasts> liveBroadcasts { get; set; }
    
        public virtual int findAnswers(Nullable<int> competitionId)
        {
            var competitionIdParameter = competitionId.HasValue ?
                new ObjectParameter("competitionId", competitionId) :
                new ObjectParameter("competitionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("findAnswers", competitionIdParameter);
        }
    }
}
