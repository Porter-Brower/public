using System;

class Program
{
    static void Main(string[] args)
    {
        // easy if you want to change the scripture, you'll just have to adjust these 2 lines!
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine("Memorize the scripture below. Press Enter to hide more words or type 'quit' to exit.\n");
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\n> ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine("Final round!!!!! let's go!!!! — you thing you can handle this? ok ! here's the fully hidden scripture:\n");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nYou Got it! Congradulations Great job memorizing.");
        }
    }
}
