// Import system tools letd get this started!
using System;
using System.Collections.Generic;
using System.IO;

// This is the main class that runs the Eternal Quest program
class Program
{
    // The main starting point of the entire program
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>(); // This list will hold all created goals
        int score = 0;                       // Keeps track of the total score
        bool quit = false;                   // Controls the menu loop

        //  shows the menu repeatedly until the user chooses to quit which is option 6
        while (!quit)
        {
            // Display the game header and current score hope your competitve 
            Console.WriteLine("\nEternal Quest");
            Console.WriteLine($"Current Score: {score}");

            // Display the menu options we need 6 option create a new goal, list the goals, record, save goals, load the goals, and to quit if there done
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            // ask the person to chose
            Console.Write("Select an option: ");
            string choice = Console.ReadLine(); // Read the input

            // Respond based on the choice
            switch (choice)
            {
                case "1":
                    CreateGoal(goals); // Go to method that adds a new goal
                    break;
                case "2":
                    ShowGoals(goals); // Display current goals and progress
                    break;
                case "3":
                    score += RecordEvent(goals); // Mark a goal as completed and add points
                    break;
                case "4":
                    SaveGoals(goals, score); // Save progress to a file
                    break;
                case "5":
                    score = LoadGoals(goals); // Load goals and score from file
                    break;
                case "6":
                    quit = true; // End the loop and quit
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again."); // Catch typos or bad input
                    break;
            }
        }
    }


    static void CreateGoal(List<Goal> goals)
    {
        // Ask which type of goal they want to create
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine(); // Read the type number

        // Ask "youre" goals name i did your becasue it more meaningful at least i feel 
        Console.Write("Enter youre goal's name: ");
        string name = Console.ReadLine();
        // i decided to add instread of Enter the description; Enter a brief description different from your title to help visiulise the goal. becase when i was testing it out it i just kept lining my title and goas very similary. like i did title push up and discription pushups
        Console.Write("Enter a brief description different from your title to help visiulise the goal and don't cheat youreself!:");
        string desc = Console.ReadLine();
        Console.Write("Enter what points you feel this goal is worth to you! and don't cheat youreself: ");
        // with this enter what points you feel this goal is worth to you! its just more homey// adding as well don't cheat youreself: "); !:");
    
        int points = int.Parse(Console.ReadLine());

        // Decide which goal type to create based on input
        if (type == "1")
        {
            // Create a simple one-time goal
            goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            // Create a repeating eternal goal
            goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            // Ask for How many times to complete? 
            Console.Write("How many times do you want to complete? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points on completion: ");
            int bonus = int.Parse(Console.ReadLine());

            // Create a checklist goal with repetition and bonus
            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    // ========================
    // Show all current goals
    // ========================
    static void ShowGoals(List<Goal> goals)
    {
        Console.WriteLine("Your Goals:");

        // Loop through and display each goal
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    
    static int RecordEvent(List<Goal> goals)
    {
        ShowGoals(goals); // show list

        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1; 

        
        if (index >= 0 && index < goals.Count)
        {
            return goals[index].RecordEvent();
        }

        //  no points are earned mostly when something doesnt go right 
        return 0;
    }

  
    static void SaveGoals(List<Goal> goals, int score)
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score); // Save score at top of file

            // Save each goal as a line of text to help the person keep track as weel as da code
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.SaveString());
            }
        }

        Console.WriteLine("Goals saved.");
    }

        static int LoadGoals(List<Goal> goals)
    {
        goals.Clear(); // Start fresh
        string[] lines = File.ReadAllLines("goals.txt"); // Read all lines from file

        int score = int.Parse(lines[0]); // First line is the score

        // Process each saved goal line
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|'); // Break line into parts
            string type = parts[0];               // First part tells us the goal type

            if (type == "Simple")
            {
                goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            }
            else if (type == "Eternal")
            {
                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "Checklist")
            {
                goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                            int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
            }
        }

        Console.WriteLine("Goals loaded.");
        return score; // Return the loaded score
    }
}
