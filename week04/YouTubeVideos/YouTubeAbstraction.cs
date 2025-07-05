using System;
using System.Collections.Generic;

public class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public int Likes { get; private set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Likes = 0;
        Comments = new List<Comment>();
    }

    public void Play()
    {
        Console.WriteLine($"Playing video: {Title} by {Author}");
    }

    public void Like()
    {
        Likes++;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Likes: {Likes}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Author}: {comment.Text}");
        }
    }
}

public static class YouTubeProgram
{
    public static void Run()
    {
        Video video = new Video("Cool Coding Tutorial", "Alice", 300);
        video.Play();
        video.Like();
        video.Like();

        video.AddComment(new Comment("Bob", "Great video!"));
        video.AddComment(new Comment("Carol", "Very helpful, thanks!"));

        video.DisplayInfo();
    }
}
