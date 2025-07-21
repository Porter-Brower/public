using System;
// D=distance,S=Speed,P=Pace
public class Swimming : Activity
{
    private int _laps; // lap is 50 meters

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double D_Distance()
    {
        return (_laps * 50) / 1000.0; // Convert meters to km
    }

    public override double S_Speed()
    {
        return (D_Distance() / M_Minutes()) * 60;
    }

    public override double P_Pace()
    {
        return M_Minutes() / D_Distance();
    }

    
    public override string U_Summary()
    {
        return $"{d_Date():dd MMM yyyy} Swimming ({M_Minutes()} min): Distance {D_Distance():0.0} km, Speed {S_Speed():0.0} kph, Pace: {P_Pace():0.0} min per km";
    }
}
