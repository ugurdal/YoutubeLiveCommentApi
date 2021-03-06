﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class LiveChatModel
    {
        [Browsable(false)]
        public string MessageId { get; set; }
        [DisplayName("Date")]
        public string PublishedAt { get; set; }
        [DisplayName("Message")]
        public string DisplayMessage { get; set; }
        [DisplayName("Name")]
        public string AuthorDisplayName { get; set; }
        [DisplayName("Channel")]
        public string AuthorChannelUrl { get; set; }
        [Browsable(false)]
        public bool IsVerified { get; set; }
        [Browsable(false)]
        public bool IsChatOwner { get; set; }
        [DisplayName("Sponsor")]
        public bool IsChatSponsor { get; set; }
        [DisplayName("Moderator")]
        public bool IsChatModerator { get; set; }
        public DateTime? PublishedTime { get; set; }
        public string AuthorChannelId { get; set; }
        public string LiveChatId { get; set; }
        public string VideoId { get; set; }
        [Browsable(false)]
        public string ComputedMessage
        {
            get
            {
                var temp = this.DisplayMessage.Split(',')[0];
                return temp.Replace(".", "").Replace("-", "").Replace("+", "").Replace(" ", "");
            }
        }
        [Browsable(false)]
        public bool IsMessageNumeric
        {
            get { return Helper.IsNumeric(this.ComputedMessage); }
        }
        [Browsable(false)]
        public string NumericMessage
        {
            get
            {
                return this.IsMessageNumeric
                    ? this.ComputedMessage
                    : "0";
            }
        }
    }
}
