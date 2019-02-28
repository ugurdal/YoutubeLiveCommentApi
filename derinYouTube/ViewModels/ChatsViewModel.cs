using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class ChatsViewModel
    {
        [DisplayName("Display Name")]
        public string AuthorDisplayName { get; set; }
        [DisplayName("Puslished Time")]
        public string PublishedAtStr
        {
            get { return this.PublishedAt?.ToString() ?? ""; }
        }
        [DisplayName("Message")]
        public string MessageText { get; set; }
        [DisplayName("Channel Id")]
        public string AuthorChannelId { get; set; }
        [DisplayName("Channel Url")]
        public string AuthorChannelUrl { get; set; }
        [Browsable(false)]
        public DateTime? PublishedAt { get; set; }
    }
}
