using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using derinYouTube.ViewModels;

namespace derinYouTube
{
    public static class Helper
    {
        public static LinkedList<LiveChatModel> LiveChatModels = new LinkedList<LiveChatModel>();
        public static DataTable DtLiveChats = new DataTable();

        public static void GenerateDataTableColumns()
        {
            DtLiveChats.Columns.Add("MessageId", typeof(string));
            DtLiveChats.Columns.Add("PublishedAt", typeof(string));
            DtLiveChats.Columns.Add("DisplayMessage", typeof(string));
            DtLiveChats.Columns.Add("DisplayName", typeof(string));
            DtLiveChats.Columns.Add("ChannelUrl", typeof(string));
            DtLiveChats.Columns.Add("IsVerified", typeof(bool));
            DtLiveChats.Columns.Add("IsChatOwner", typeof(bool));
            DtLiveChats.Columns.Add("IsChatSponsor", typeof(bool));
            DtLiveChats.Columns.Add("IsChatModerator", typeof(bool));
        }
    }
}

