using System;
using System.Collections.Generic;

// Enhancement: Added mood tracking to journal entries
// Each entry now records the user's mood along with the date, prompt, and response

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        Random rand = new Random();

        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load journal from file");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1–5): ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[rand.Next(prompts.Length)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("Your mood today (e.g., Happy, Sad, Grateful): ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToString("MM/dd/yyyy"),
                        _prompt = prompt,
                        _response = response,
                        _mood = mood
                    };

                    myJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry added.\n");
                    break;

                case "2":
                    Console.WriteLine("\nYour Journal Entries:\n");
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.\n");
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.\n");
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1–5.\n");
                    break;
            }
        }
    }
}
