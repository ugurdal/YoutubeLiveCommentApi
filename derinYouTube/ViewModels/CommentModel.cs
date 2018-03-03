using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class CommentModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UserChannelId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string TextOriginal { get; set; }
        public int RepliesCount { get; set; }
    }
}
