using System;
using System.Threading;

class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _sessionDuration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_activityName} ---");
        Console.WriteLine($"{_description}\n");

        bool validInput = false;
        while (!validInput)
        {
            Console.Write("How many seconds would you like this session to be? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _sessionDuration) && _sessionDuration > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number.");
            }
        }

        Console.WriteLine("\nPrepare yourself...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nNice work! Take a moment to feel proud.");
        ShowSpinner(2);
        Console.WriteLine($"You just finished the {_activityName} for {_sessionDuration} seconds.");
        ShowSpinner(2);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
