// This class represents a goal that is never fully completed — it repeats forever. so eternal lol
public class EternalGoal : Goal
{
    // this sets up an EternalGoal with name, description, and point value.
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) // Call the base class 
    {
       
    }

    // This is to records progress on this goal.
    // Since it's eternal though it will never be 100% finished just adds points every time.
    public override int RecordEvent()
    {
        Console.WriteLine($"Recorded '{_name}'! +{_points} points!"); // Show success message
        return _points; // Always award points
    }

    //  shows the goal in the list, using [∞] to mean "never finished"
    public override string GetStatus()
    {
        return $"[∞] {_name} ({_description})"; // Display status with infinity symbol
    }

    
    public override string SaveString() // will returns the goal’s data as a string to save to a file
    {
        // Format: type|name|description|points
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}
