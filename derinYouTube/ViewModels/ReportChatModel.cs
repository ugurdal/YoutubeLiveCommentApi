using derinYouTube.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class ReportChatModel
    {
        public LinkedList<LiveChatModel> LiveChats { get; set; }
        public long? PollingIntervalMillis { get; set; }
    }
}
