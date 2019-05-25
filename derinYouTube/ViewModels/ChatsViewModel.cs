using derinYouTube.Extensions;
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
        [DisplayName("İzleyici Adı")]
        public string AuthorDisplayName { get; set; }
        [DisplayName("Saat")]
        public string PublishedAtStr
        {
            get { return this.PublishedAt.ToTarih(); }
        }
        [DisplayName("Mesaj")]
        public string MessageText { get; set; }
        [DisplayName("Kanal Id")]
        public string AuthorChannelId { get; set; }
        [DisplayName("Kanal Url")]
        public string AuthorChannelUrl { get; set; }
        [Browsable(false)]
        public DateTime? PublishedAt { get; set; }
    }
}
