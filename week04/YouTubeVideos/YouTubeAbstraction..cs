using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int LengthInSeconds { get; }
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Bake Bread", "Alice", 600);
        video1.AddComment(new Comment("Bob", "Looks delicious!"));
        video1.AddComment(new Comment("Carol", "Thanks for the tips!"));
        video1.AddComment(new Comment("Dave", "Can't wait to try this!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Learn C# Basics", "Ben", 1200);
        video2.AddComment(new Comment("Eva", "Very helpful!"));
        video2.AddComment(new Comment("Frank", "Great explanation."));
        video2.AddComment(new Comment("Grace", "Subscribed!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Guitar Tutorial", "Chris", 900);
        video3.AddComment(new Comment("Hannah", "Awesome lesson!"));
        video3.AddComment(new Comment("Ian", "I learned a lot."));
        video3.AddComment(new Comment("Jill", "More videos please!"));
        videos.Add(video3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
