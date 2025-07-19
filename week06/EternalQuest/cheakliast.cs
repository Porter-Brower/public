// This class represents a goal that must be completed a certain number of times.
// Example: Attend the temple 10 times or go running 5 times.
public class ChecklistGoal : Goal
{
    private int _timesCompleted; // # completed this goal
    private int _target;         // How many total times are needed to complete the goal
    private int _bonus;          // Extra bonus points when the target is reached

    //  sets up all needed info, including progress*
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed = 0)
        : base(name, description, points) // Pass shared values to base Goal class
    {
        _target = target;                 // total times needed to finish the goal
        _bonus = bonus;                   // points are awarded when the goal is fully complete!
        _timesCompleted = completed;      // current progress
    }

    //  called when the records a completion of this goal.
    public override int RecordEvent()
    {
        _timesCompleted++; // Increase the completion count by one

        // If completed the the required number of times to finsh the code
        if (_timesCompleted == _target)
        {
            Console.WriteLine($"Checklist goal '{_name}' completed great job my friend you did fantastic you're da bomb! Bonus +{_bonus} points!"); // celebration message
            return _points + _bonus; // Give normal points plus bonus
        }

        // If your still contiuing toward the goal
        Console.WriteLine($"Progress: {_timesCompleted}/{_target} +{_points} points."); // Show progress
        return _points; // Give only normal points
    }

    // This returns the status of the goal to display in the list
    public override string GetStatus()
    {
        // If completed, show [X], else show [ ]
        return $"[{(_timesCompleted >= _target ? "X" : " ")}] {_name} ({_description}) - Completed {_timesCompleted}/{_target}";
    }

    // This returns the goal's data in savable format for a file
    public override string SaveString()
    {
        // Format: type|name|description|points|target|bonus|completed this helps me when im swiching and cheaking the codes
        return $"Checklist|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_timesCompleted}";
    }
}
