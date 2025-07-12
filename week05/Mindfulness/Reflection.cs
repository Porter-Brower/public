using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _experiencePrompts = new List<string>()
    {
        "Remember a time you overcame a big challenge.",
        "Think of when you stood up for someone else.",
        "Recall a time you put others before yourself.",
        "Picture a moment when you felt truly strong."
    };

    private List<string> _reflectionQuestions = new List<string>()
    {
        "What made this experience meaningful?",
        "How did this change you afterwards?",
        "Would you do it the same way again?",
        "How did you feel at the end of it?",
        "What did you learn about yourself?"
    };

    public ReflectionActivity()
        : base("Reflection Session",
        "Look inward and revisit moments when you showed resilience.\nThis helps you see your strengths more clearly.")
    {
    }

    public void Run()
    {
        Start();

        Random random = new Random();
        string chosenPrompt = _experiencePrompts[random.Next(_experiencePrompts.Count)];
        Console.WriteLine($"\nPrompt: {chosenPrompt}");
        Console.WriteLine("Now think about these questions...");

        int timeUsed = 0;
        int questionTime = 5;

        foreach (string question in Shuffle(_reflectionQuestions))
        {
            if (timeUsed + questionTime > _sessionDuration) break;

            Console.Write($"> {question} ");
            ShowSpinner(questionTime);
            timeUsed += questionTime;
        }

        End();
    }

    private List<string> Shuffle(List<string> list)
    {
        List<string> shuffled = new List<string>(list);
        Random rng = new Random();
        int n = shuffled.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string temp = shuffled[k];
            shuffled[k] = shuffled[n];
            shuffled[n] = temp;
        }
        return shuffled;
    }
}
