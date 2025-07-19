// This class represents a goal that is completed once and then never again. aka tha name simple goal
public class SimpleGoal : Goal
{
        private bool _isComplete; // This will tracks whether the goal has been completed or not


// these next 5 liines will set up a SimpleGoal with a name, description, points, and whether it's already completed
    public SimpleGoal(string name, string description, int points, bool complete = false) 
        : base(name, description, points) // Pass the shared info to the base class (Goal)
    {
        _isComplete = complete; // Set whether the goal is already marked complete
    }

    
    // It gives points if it's the first time, and shows a message.
    public override int RecordEvent()
    {
        // If the goal has not been completed yet 
        if (!_isComplete)
        {
            _isComplete = true; // Mark it completed
            Console.WriteLine($"Goal '{_name}' completed! +{_points} points!"); // Notify the person
            return _points; // Award the points
        }

        // If the goal was already completed
        Console.WriteLine($"Goal '{_name}' is already complete."); // Let the person know
        return 0; // No points will be awarded
    }

    
    public override string GetStatus()
    {
        // If completed, show [X], otherwise [ ] i dont really like the X but i think it does it job but if you have any recomondation im open brother nathan 
        return $"{(_isComplete ? "[X]" : "[ ]")} {_name} ({_description})";
    }

        public override string SaveString()
    {
        // Format: type|name|description|points|complete
        return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
    }
}
