using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Let’s create a video platform such as YouTube. It will be called MeTube. Your task is to store videos, videos’ views and likes. 
        //You will be receiving lines in the following format: "{videoName}-{views}" until you receive "stats time".
        //You should store video and its views, if the video already exists add the views to it.
        //You can receive a command to rate a video in the following format: "like:{video}" or "dislike:{video}".The like command will give a single like whereas the dislike command will remove a like, but the given video needs to exist.
        //After receiving "stats time" you will receive an order criterion – either "by views" or "by likes".If you receive "by views" order the videos by views in descending order, otherwise order the videos by likes in descending order.
        //Print each of the videos in the following format: "{video} - {views} views - {likes} likes"

        var videos = new List<Video>();

        string input = Console.ReadLine();

        while (input != "stats time")
        {
            //var inputTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            bool likeOrDislike = input.Contains(":");
            if (likeOrDislike)
            {
                var tokens = input.Split(':').ToArray();
                string parity = tokens[0];
                string videoName = tokens[1];

                bool videoExists = videos.Any(x => x.Name == videoName);
                if (videoExists)
                {
                    var currentVideo = videos.Find(x => x.Name == videoName);
                    switch (parity)
                    {
                        case "like":
                            currentVideo.Likes++;
                            break;

                        case "dislike":
                            currentVideo.Likes--;
                            break;
                        default:
                            break;
                    }
                }
            }

            bool newVideoOrAddViews = input.Contains("-");
            if(newVideoOrAddViews)
            {
                var inputTokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string videoName = inputTokens[0];
                int views = int.Parse(inputTokens[1]);

                bool newVideo = !videos.Any(x => x.Name == videoName);
                if (newVideo)
                {
                    var currentVideo = new Video
                    {
                        Name = videoName,
                        Views = views
                    };
                    videos.Add(currentVideo);
                }
                else //find and update views of the video
                {
                    var currentVideo = videos.Find(x => x.Name == videoName);
                    currentVideo.Views += views;
                }
            }

            input = Console.ReadLine();
        }

        var result = new List<Video>();
        var orderByCommand = Console.ReadLine();
        switch (orderByCommand)
        {
            case "by likes":
                result = videos.OrderByDescending(x => x.Likes).ToList();
                break;
            case "by views":
                result = videos.OrderByDescending(x => x.Views).ToList();
                break;

            default:
                break;
        }

        foreach (var vid in result)
        {
            Console.WriteLine($"{vid.Name} - {vid.Views} views - {vid.Likes} likes");
        }
    }
}