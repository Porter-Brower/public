using System;
// D=distance,S=Speed,P=Pace
public class Running : Activity // Inherits from Activity
{
    private double _distance; // kilometers

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes) 
    {
        _distance = distance;
    }

    public override double D_Distance() => _distance;

    public override double S_Speed()
    {
        return (_distance / M_Minutes()) * 60; // S = d / t * 60 this is to get kph
    }

    public override double P_Pace()
    {
        return M_Minutes() / _distance; // P = t / d
    }
}
