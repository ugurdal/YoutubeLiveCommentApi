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
using System.Threading;
using derinYouTube.ViewModels;

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
                        new FileDataStore("YouTubeCommentAPI") // Console>Credentials>ProductName ile aynı olmalı yoksa Api 403 Forbidden dönüyor
                    ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeCommentAPI"
            });

            return service;
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
                    comment.UserChannelId = item.Snippet.TopLevelComment.Snippet.AuthorChannelId.ToString();
                    comment.PublishedDate = item.Snippet.TopLevelComment.Snippet.PublishedAt.Value;
                    comment.TextOriginal = item.Snippet.TopLevelComment.Snippet.TextOriginal;
                    comment.RepliesCount = item.Replies?.Comments.Count ?? 0;

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

                var i = 0;
                foreach (var item in response.Items)
                {
                    if (requestList.Contains("snippet"))
                    {
                        var video = new VideoModel();
                        video.Title = item.Snippet.Title;
                        video.Description = item.Snippet.Description;
                        video.PublishedData = item.Snippet.PublishedAt.Value;
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
            var request = ytService.Videos.List("snippet");
            request.Id = videoId;
            var video = new VideoModel();

            var response = request.Execute();
            if (response.Items.Count == 0)
            {
                // Video not found...
            }
            else
            {
                video.Id = videoId;
                video.Title = response.Items[0].Snippet.Title;
                video.Description = response.Items[0].Snippet.Description;
                video.PublishedData = response.Items[0].Snippet.PublishedAt.Value;
                video.ChannelId = response.Items[0].Snippet.ChannelId;
                video.ChannelTitle = response.Items[0].Snippet.ChannelTitle;
            }
            return video;
        }


    }
}
