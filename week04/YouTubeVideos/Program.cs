using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "iPhone 17 Review After 30 Days",
            "Tech Insights",
            840);

        video1.AddComment(new Comment("John", "The camera quality is amazing."));
        video1.AddComment(new Comment("Sarah", "I was considering buying this phone."));
        video1.AddComment(new Comment("Mike", "Thanks for the honest view"));

        videos.Add(video1);

        Video video2 = new Video(
            "Top 10 Travel Destinations",
            "Travel World",
            1200);

        video2.AddComment(new Comment("Emma", "I want to visit these places."));
        video2.AddComment(new Comment("Chris", "Amazing video!"));
        video2.AddComment(new Comment("Lily", "Beautiful scenery."));

        videos.Add(video2);

        Video video3 = new Video(
            "Easy Homemade Pizza",
            "Cooking Master",
            600);

        video3.AddComment(new Comment("David", "Looks delicious!"));
        video3.AddComment(new Comment("Sophia", "Trying this tonight."));
        video3.AddComment(new Comment("James", "Great recipe."));

        videos.Add(video3);

        
        Video video4 = new Video(
            "Football Highlights 2026",
            "mujuni Sports Channel",
            1500);

        video4.AddComment(new Comment("Alex", "What a match!"));
        video4.AddComment(new Comment("Daniel", "Amazing goals for the leading team."));
        video4.AddComment(new Comment("Grace", "Best highlights video ever."));

        videos.Add(video4);
        
        foreach (Video video in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}