public abstract class Goal // This is the abstract base class for all types of goals
{
    protected string _name;// The name

   
     protected string _description;//  description of the goal

    // How many points the user earns for completing this goal
    protected int _points; // points the person earns for completing this goal

   
    public Goal(string name, string description, int points)
    {
        _name = name;                // Set the goal's name
        _description = description;  // Set the goal's description
        _points = points;            // Set the point value of the goal
    }

    
    public abstract int RecordEvent();

   
    public abstract string GetStatus();

   
    public abstract string SaveString();  //  converts the goal into a string format for saving to the file.
}
