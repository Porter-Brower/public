using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _listingPrompts = new List<string>()
    {
        "Who are people that you appreciate right now?",
        "What personal strengths are you grateful for?",
        "Name moments that made you smile this week.",
        "List things that help you feel calm."
    };

    public ListingActivity()
        : base("Gratitude Listing",
        "Jot down as many positive thoughts as you can.\nThis simple act can boost your mood and focus on good things.")
    {
    }

    public void Run()
    {
        Start();

        Random rand = new Random();
        string chosenPrompt = _listingPrompts[rand.Next(_listingPrompts.Count)];

        Console.WriteLine($"\nPrompt: {chosenPrompt}");
        Console.Write("Starting in: ");
        ShowCountdown(3);

        int itemCount = 0;
        DateTime end = DateTime.Now.AddSeconds(_sessionDuration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string entry = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(entry))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"\nYou listed {itemCount} items. Well done! feel you inner peacse");
        End();
    }
}
