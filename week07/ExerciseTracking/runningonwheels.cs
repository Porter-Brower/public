using System;
// D=distance,S=Speed,P=Pace
public class Cycling : Activity
{
    private double _speed; // User provides the speed directly (in kph)

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double D_Distance()
    {
        return (_speed * M_Minutes()) / 60; // D = s * t
    }

    public override double S_Speed() => _speed;

    public override double P_Pace()
    {
        return 60 / _speed; // P = 60 / s
    }
}
