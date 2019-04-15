using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows.Forms;
using derinYouTube.ViewModels;
using LiveBroadcastsResource = Google.Apis.YouTube.v3.LiveBroadcastsResource;
using Google.Apis.YouTube.v3.Data;
using derinYouTube.Model;

namespace derinYouTube
{
    public class YouTubeApi
    {
        private readonly string _jsonFilePath;
        private readonly string _applicationName;
        private readonly YouTubeService _service;

        public YouTubeApi(string jsonFilePath, string applicationName)
        {
            _jsonFilePath = jsonFilePath;
            _applicationName = applicationName;

            _service = Auth();
        }

        private YouTubeService Auth()
        {
            UserCredential credential;
            using (var stream = new FileStream(_jsonFilePath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly, YouTubeService.Scope.YoutubeForceSsl },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(_applicationName) // Console>Credentials>ProductName ile aynı olmalı yoksa Api 403 Forbidden dönüyor
                ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = _applicationName
            });

            return service;
        }

        public string ParseChannelId(object channelId)
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

        public LinkedList<CommentModel> GetCommentsByVideoId(string videoId)
        {
            var requestList = "snippet,replies";
            var request = _service.CommentThreads.List(requestList);
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

        public LinkedList<VideoModel> GetPlayListById(string playListId)
        {
            var requestList = "snippet,contentDetails";
            var request = _service.PlaylistItems.List(requestList);
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

        public VideoModel GetVideInfoById(string videoId)
        {
            try
            {
                var request = _service.Videos.List("snippet");
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

        public LinkedList<VideoModel> GetLiveBroadCasts(bool activeOnly = false)
        {
            var videos = new LinkedList<VideoModel>();
            try
            {
                var request = _service.LiveBroadcasts.List("id, snippet, status"); //contentDetails,statistics
                //request.Mine = true;
                request.MaxResults = 50;
                request.BroadcastStatus = LiveBroadcastsResource.ListRequest.BroadcastStatusEnum.All;
                request.BroadcastType = LiveBroadcastsResource.ListRequest.BroadcastTypeEnum.All;

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
                            ActualEndTime = item.Snippet.ActualEndTime,
                            ScheduledStartTime = item.Snippet.ScheduledStartTime
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

        public LinkedList<LiveChatModel> GetLiveCommentsByChatId(string liveChatId)
        {
            var comments = new LinkedList<LiveChatModel>();
            try
            {
                var requestList = "id,snippet,authorDetails";
                var request = _service.LiveChatMessages.List(liveChatId, requestList);
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
                            AuthorChannelUrl = item.AuthorDetails.ChannelUrl,
                            DisplayMessage = item.Snippet.DisplayMessage,
                            AuthorDisplayName = item.AuthorDetails.DisplayName,
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

        public async Task GetLiveChatsAsync(string liveChatId, string videoId, CancellationToken cancellationToken, IProgress<ReportChatModel> progress)
        {
            try
            {
                var isOnline = true;
                
                while (isOnline)
                {
                    var nextPage = "";
                    var requestList = "id,snippet,authorDetails";

                    while (nextPage != null)
                    {
                        var report = new ReportChatModel();
                        var output = new LinkedList<LiveChatModel>();

                        var request = _service.LiveChatMessages.List(liveChatId, requestList);
                        request.MaxResults = 1000;
                        request.PageToken = nextPage;
                        
                        var response = await request.ExecuteAsync(cancellationToken);

                        foreach (LiveChatMessage item in response.Items)
                        {
                            try
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                            }
                            catch (OperationCanceledException e)
                            {
                                //MessageBox.Show(e.Message);
                                
                            }

                            var chat = new LiveChatModel
                            {
                                MessageId = item.Id,
                                PublishedAt = item.Snippet.PublishedAt?.ToString() ?? "",
                                PublishedTime = item.Snippet.PublishedAt,
                                AuthorChannelUrl = item.AuthorDetails.ChannelUrl,
                                DisplayMessage = item.Snippet.DisplayMessage,
                                AuthorDisplayName = item.AuthorDetails.DisplayName,
                                IsVerified = item.AuthorDetails.IsVerified ?? false,
                                IsChatModerator = item.AuthorDetails.IsChatModerator ?? false,
                                IsChatOwner = item.AuthorDetails.IsChatOwner ?? false,
                                IsChatSponsor = item.AuthorDetails.IsChatSponsor ?? false,
                                AuthorChannelId = item.Snippet.AuthorChannelId,
                                LiveChatId = item.Snippet.LiveChatId,
                                VideoId = videoId
                            };

                            output.AddLast(chat);
                        }

                        report.LiveChats = output;
                        progress.Report(report);

                        nextPage = response.NextPageToken;
                        isOnline = !response.OfflineAt.HasValue;
                        
                        await Task.Delay(10000, cancellationToken);
                    }
                }

            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("iptal"))
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ulong GetCurrentStreamViewCount(string videoId)
        {
            try
            {
                ulong count = 0;
                var request = _service.Videos.List("snippet, liveStreamingDetails");
                request.Id = videoId;

                var response = request.Execute();
                if (response.Items.Any())
                {
                    count = response.Items[0].LiveStreamingDetails.ConcurrentViewers ?? 0;
                }
                return count;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool IsVideoLive(string videoId)
        {
            var request = _service.LiveBroadcasts.List("status");
            request.Id = videoId;

            var response = request.Execute();

            return response.Items[0].Status.LifeCycleStatus == "live";
        }

        public async Task<Enumeration.SucscriberStatus> IsUserSucscripted(string userChannelId, string channelId)
        {
            var result = Enumeration.SucscriberStatus.No;
            try
            {
                var request = _service.Subscriptions.List("id");
                request.ChannelId = userChannelId;
                request.ForChannelId = channelId;
                //request.MySubscribers = true;
                var list = await request.ExecuteAsync();
                result = list.Items.Any() 
                    ? Enumeration.SucscriberStatus.Yes
                    : Enumeration.SucscriberStatus.No;
            }
            catch (Exception e)
            {
                return Enumeration.SucscriberStatus.NotAllowed;
            }

            return result;
        }

        public async Task<List<string>> GetSubscriberList()
        {
            var result = new List<string>();
            try
            {
                var request = _service.Subscriptions.List("id, subscriberSnippet");
                request.Mine = true;
                var list = await request.ExecuteAsync();
                foreach (var item in list.Items)
                {
                    result.Add(item.SubscriberSnippet.ChannelId);
                }
            }
            catch (Exception e)
            {
                return new List<string>();
            }

            return result;
        }
    }
}
