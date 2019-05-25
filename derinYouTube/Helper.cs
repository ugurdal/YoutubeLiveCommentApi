using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using derinYouTube.ViewModels;

namespace derinYouTube
{
    public static class Helper
    {
        public static LinkedList<LiveChatModel> LiveChatModels = new LinkedList<LiveChatModel>();
        //public static DataTable DtLiveChats = new DataTable();

        //public static void GenerateDataTableColumns()
        //{
        //    DtLiveChats.Columns.Add("MessageId", typeof(string));
        //    DtLiveChats.Columns.Add("PublishedAt", typeof(string));
        //    DtLiveChats.Columns.Add("DisplayMessage", typeof(string));
        //    DtLiveChats.Columns.Add("DisplayName", typeof(string));
        //    DtLiveChats.Columns.Add("ChannelUrl", typeof(string));
        //    DtLiveChats.Columns.Add("IsVerified", typeof(bool));
        //    DtLiveChats.Columns.Add("IsChatOwner", typeof(bool));
        //    DtLiveChats.Columns.Add("IsChatSponsor", typeof(bool));
        //    DtLiveChats.Columns.Add("IsChatModerator", typeof(bool));
        //}

        public static string ConnectionString = "Data Source=.;Initial Catalog=YoutubeCommentDb;User ID=drn;Password=sis;Trusted_Connection=False;Persist Security Info=True";

        public static SqlConnection Cnn;

        public static bool IsNumeric(string s)
        {
            return Regex.Match(s, @"^\d+$").Success;
        }

        public static bool IsNumericArti(string s)
        {
            var value = Regex.Match(s, @"^\d+$").Success;
            if (value)
            {
                return Convert.ToDecimal(s) > 0;
            }
            return false;
        }

        public static string ToDescription<TEnum>(this TEnum enumObj)
        {
            var fi = enumObj.GetType().GetField(enumObj.ToString());
            var attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return enumObj.ToString();
        }

    }

}

