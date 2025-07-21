using System;  
// D=distance,S=Speed,P=Pace
public abstract class Activity // base class abstract is just the blue print which just means that we cannot create an object from it directly and so we'll make some child classes to do that for me
{
    private DateTime _date; // just storege of the activity 
    private int _minutes;   // storage for the actitivy time length 

    public Activity(DateTime date, int minutes) 
    {
        _date = date;
        _minutes = minutes;
    }
// These are getter methods so the child classes can access the private fields without having to maake it public 
    public DateTime d_Date() => _date; // 
    public int M_Minutes() => _minutes;

    // abstract methods 
    public abstract double D_Distance(); // activity will compute distance differently this will help me organise my code 
    public abstract double S_Speed();    // S = d / t
    public abstract double P_Pace();     // P = t / di
    // virtual method 
    public virtual string U_Summary()
    {
        
        return $"{_date.ToString("dd MMM yyyy")} Activity ({_minutes} min): Distance {D_Distance():0.0} km, Speed {S_Speed():0.0} kph, Pace: {P_Pace():0.0} min per km";
    }
}
