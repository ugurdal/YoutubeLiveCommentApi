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
    
    public partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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
    }
}
