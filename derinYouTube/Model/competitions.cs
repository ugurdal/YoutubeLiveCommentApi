//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class competitions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public competitions()
        {
            this.competitionAnswers = new HashSet<competitionAnswers>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string LiveChatId { get; set; }
        public string VideoId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public System.DateTime StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<competitionAnswers> competitionAnswers { get; set; }
    }
}
