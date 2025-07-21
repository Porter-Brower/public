using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===");
            Console.WriteLine(" 1. Breathing Exercise");
            Console.WriteLine(" 2. Reflection Session");
            Console.WriteLine(" 3. Gratitude Listing");
            Console.WriteLine(" 4. Exit");
            Console.Write("\nChoose an activity (1-4): ");

            string choice = Console.ReadLine()?.Trim();

            if (choice == "1")
            {
                var breathe = new BreathingActivity();
                breathe.Run();
            }
            else if (choice == "2")
            {
                var reflect = new ReflectionActivity();
                reflect.Run();
            }
            else if (choice == "3")
            {
                var list = new ListingActivity();
                list.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nThanks for taking time to be mindful today!");
                break;
            }
            else
            {
                Console.WriteLine("\nNot a valid option. Please pick 1, 2, 3, or 4.");
                System.Threading.Thread.Sleep(1500);
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
