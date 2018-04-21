﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using derinYouTube.ViewModels;
using LiveBroadcastsResource = Google.Apis.YouTube.v3.LiveBroadcastsResource;

namespace derinYouTube
{
    public class YouTubeApi
    {
        private static YouTubeService ytService = Auth();

        private static YouTubeService Auth()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly, YouTubeService.Scope.YoutubeForceSsl },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(
                        "YouTubeCommentAPI") // Console>Credentials>ProductName ile aynı olmalı yoksa Api 403 Forbidden dönüyor
                ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeCommentAPI"
            });

            return service;
        }

        public static string ParseChannelId(object channelId)
        {
            try
            {
                return channelId.ToString()
                    .Split(':')[1].Trim().Replace(Convert.ToChar(34), Convert.ToChar(125))
                    .Replace("}", "");
            }
            catch (Exception)
            {
                return channelId?.ToString() ?? "";
            }
        }

        public static LinkedList<CommentModel> GetCommentsByVideoId(string videoId)
        {
            var requestList = "snippet,replies";
            var request = ytService.CommentThreads.List(requestList);
            request.VideoId = videoId;
            request.MaxResults = 100;

            var comments = new LinkedList<CommentModel>();
            var nextPage = "";

            while (nextPage != null)
            {
                request.PageToken = nextPage;
                var response = request.Execute();

                var i = 0;
                foreach (var item in response.Items)
                {
                    var comment = new CommentModel();
                    comment.Id = item.Id;
                    comment.DisplayName = item.Snippet.TopLevelComment.Snippet.AuthorDisplayName;
                    comment.UserChannelId = ParseChannelId(item.Snippet.TopLevelComment.Snippet.AuthorChannelId);
                    comment.PublishedDate = item.Snippet.TopLevelComment.Snippet.PublishedAt.Value;
                    comment.TextOriginal = item.Snippet.TopLevelComment.Snippet.TextOriginal;
                    comment.RepliesCount = item.Replies?.Comments.Count ?? 0;
                    comment.RepliedCommentId = "";

                    if (comment.RepliesCount > 0)
                    {
                        foreach (var comm in item.Replies.Comments)
                        {
                            var replyComm = new CommentModel();
                            replyComm.RepliedCommentId = item.Id;
                            replyComm.Id = comm.Id;
                            replyComm.DisplayName = comm.Snippet.AuthorDisplayName;
                            replyComm.UserChannelId = ParseChannelId(comm.Snippet.AuthorChannelId);
                            replyComm.PublishedDate = comm.Snippet.PublishedAt.Value;
                            replyComm.TextOriginal = comm.Snippet.TextOriginal;
                            replyComm.RepliesCount = 0;

                            comments.AddLast(replyComm);
                        }
                    }

                    comments.AddLast(comment);
                }

                nextPage = response.NextPageToken;
            }

            return comments;
        }

        public static LinkedList<VideoModel> GetPlayListById(string playListId)
        {
            var requestList = "snippet,contentDetails";
            var request = ytService.PlaylistItems.List(requestList);
            request.PlaylistId = playListId;
            request.MaxResults = 50;

            var videos = new LinkedList<VideoModel>();
            var nextPage = "";

            while (nextPage != null)
            {
                request.PageToken = nextPage;
                var response = request.Execute();

                foreach (var item in response.Items)
                {
                    if (requestList.Contains("snippet"))
                    {
                        var video = new VideoModel();
                        video.Title = item.Snippet.Title;
                        video.Description = item.Snippet.Description;
                        video.PublishedDate = item.Snippet.PublishedAt.Value;
                        video.ChannelId = item.Snippet.ChannelId;
                        video.ChannelTitle = item.Snippet.ChannelTitle;

                        videos.AddLast(video);
                    }
                    else
                    {
                        videos.AddLast(GetVideInfoById(item.ContentDetails.VideoId));
                    }
                }

                nextPage = response.NextPageToken;
            }

            return videos;

        }

        public static VideoModel GetVideInfoById(string videoId)
        {
            try
            {
                var request = ytService.Videos.List("snippet");
                request.Id = videoId;
                var video = new VideoModel();

                var response = request.Execute();
                if (response.Items.Count == 0)
                {
                    MessageBox.Show("Video bulunamadı.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }

                video.Id = videoId;
                video.Title = response.Items[0].Snippet.Title;
                video.Description = response.Items[0].Snippet.Description;
                video.PublishedDate = response.Items[0].Snippet.PublishedAt.Value;
                video.ChannelId = response.Items[0].Snippet.ChannelId;
                video.ChannelTitle = response.Items[0].Snippet.ChannelTitle;

                return video;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Video sorgulanırken hata alındı.\r\n" + ex.Message + ex.InnerException?.Message, "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static LinkedList<VideoModel> GetLiveBroadCasts(bool activeOnly = false)
        {
            var videos = new LinkedList<VideoModel>();
            try
            {
                var request = ytService.LiveBroadcasts.List("id, snippet, contentDetails, status");
                request.Mine = true;
                request.MaxResults = 50;

                var nextPage = "";
                while (nextPage != null)
                {
                    request.PageToken = nextPage;
                    var response = request.Execute();

                    foreach (var item in response.Items)
                    {
                        if (activeOnly && item.Status.LifeCycleStatus != "live")
                            continue;
                        var video = new VideoModel()
                        {
                            Id = item.Id,
                            Title = item.Snippet.Title,
                            ChannelId = item.Snippet.ChannelId ?? "",
                            LiveChatId = item.Snippet.LiveChatId ?? "",
                            Description = item.Snippet.Description,
                            LiveStatus = item.Status.LifeCycleStatus,
                            ChannelTitle = "",
                            PublishedDate = item.Snippet.PublishedAt,
                            ActualStartTime = item.Snippet.ActualStartTime,
                            ActualEndTime = item.Snippet.ActualEndTime
                        };


                        videos.AddLast(video);
                    }

                    nextPage = response.NextPageToken;
                }

            }
            catch (Exception ex)
            {

            }

            return videos;
        }

        public static LinkedList<LiveChatModel> GetLiveCommentsByChatId(string liveChatId)
        {
            var comments = new LinkedList<LiveChatModel>();
            try
            {
                var requestList = "id,snippet,authorDetails";
                var request = ytService.LiveChatMessages.List(liveChatId, requestList);
                request.MaxResults = 500; //Acceptable values are 200 to 2000, inclusive. The default value is 500.

                var nextPage = "";

                while (nextPage != null)
                {
                    request.PageToken = nextPage;
                    var response = request.Execute();
                    if (response.Items.Count == 0)
                    {
                        nextPage = null;
                        break;
                    }

                    foreach (var item in response.Items)
                    {
                        var comment = new LiveChatModel
                        {
                            MessageId = item.Id,
                            PublishedAt = item.Snippet.PublishedAt?.ToString() ?? "",
                            ChannelUrl = item.AuthorDetails.ChannelUrl,
                            DisplayMessage = item.Snippet.DisplayMessage,
                            DisplayName = item.AuthorDetails.DisplayName,
                            IsVerified = item.AuthorDetails.IsVerified ?? false,
                            IsChatModerator = item.AuthorDetails.IsChatModerator ?? false,
                            IsChatOwner = item.AuthorDetails.IsChatOwner ?? false,
                            IsChatSponsor = item.AuthorDetails.IsChatSponsor ?? false
                        };

                        comments.AddLast(comment);
                    }

                    nextPage = response.NextPageToken;
                }
            }
            catch (Exception ex)
            {

            }

            return comments;
        }

        public static void AsyncGetLiveCommentsByChatId(string liveChatId, string videoId)
        {
            try
            {
                while (IsVideoLive(videoId))
                {
                    var requestList = "id,snippet,authorDetails";
                    var request = ytService.LiveChatMessages.List(liveChatId, requestList);
                    request.MaxResults = 500; //Acceptable values are 200 to 2000, inclusive. The default value is 500.

                    var nextPage = "";

                    while (nextPage != null)
                    {
                        request.PageToken = nextPage;
                        var response = request.ExecuteAsync(CancellationToken.None);
                        if (response.Result.Items.Count == 0)
                        {
                            nextPage = null;
                            break;
                        }

                        foreach (var item in response.Result.Items)
                        {
                            var chat = new LiveChatModel
                            {
                                MessageId = item.Id,
                                PublishedAt = item.Snippet.PublishedAt?.ToString() ?? "",
                                ChannelUrl = item.AuthorDetails.ChannelUrl,
                                DisplayMessage = item.Snippet.DisplayMessage,
                                DisplayName = item.AuthorDetails.DisplayName,
                                IsVerified = item.AuthorDetails.IsVerified ?? false,
                                IsChatModerator = item.AuthorDetails.IsChatModerator ?? false,
                                IsChatOwner = item.AuthorDetails.IsChatOwner ?? false,
                                IsChatSponsor = item.AuthorDetails.IsChatSponsor ?? false
                            };

                            if (Helper.LiveChatModels.All(x => x.MessageId != chat.MessageId))
                            {
                                Helper.LiveChatModels.AddLast(chat);
                                Helper.DtLiveChats.Rows.Add(chat.MessageId, chat.PublishedAt, chat.DisplayMessage,
                                    chat.DisplayName, chat.ChannelUrl, chat.IsVerified, chat.IsChatOwner,
                                    chat.IsChatSponsor, chat.IsChatModerator);

                                //DtLiveChats.Columns.Add("MessageId", typeof(string));
                                //DtLiveChats.Columns.Add("PublishedAt", typeof(string));
                                //DtLiveChats.Columns.Add("DisplayMessage", typeof(string));
                                //DtLiveChats.Columns.Add("DisplayName", typeof(string));
                                //DtLiveChats.Columns.Add("ChannelUrl", typeof(string));
                                //DtLiveChats.Columns.Add("IsVerified", typeof(bool));
                                //DtLiveChats.Columns.Add("IsChatOwner", typeof(bool));
                                //DtLiveChats.Columns.Add("IsChatSponsor", typeof(bool));
                                //DtLiveChats.Columns.Add("IsChatModerator", typeof(bool));
                            }
                        }

                        nextPage = response.Result.NextPageToken;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static bool IsVideoLive(string videoId)
        {
            var request = ytService.LiveBroadcasts.List("status");
            request.Id = videoId;

            var response = request.Execute();

            return response.Items[0].Status.LifeCycleStatus == "live";
        }
    }
}
