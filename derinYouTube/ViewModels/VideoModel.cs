﻿using System;
using System.Collections.Generic;

namespace derinYouTube
{
    public class VideoModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedData { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        
    }
}