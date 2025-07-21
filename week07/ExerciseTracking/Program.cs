using System;
using System.Collections.Generic; // needed for the Lists<>

class Program // D=distance,S=Speed,P=Pace
{
    static void Main(string[] args)
    {
        
        List<Activity> activities = new List<Activity>();// Creates a list to store all the types of activitie

        // one of each activity! speedy-gon-soles(Running),running on wheels(cycling),running in the water(swimming).
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 4.8)); // 4.8 km run
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 20));  // 20 kph cycling for 45 min
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 40, 30)); // 30 laps in 40 min

        
        foreach (Activity act in activities) // Loop through the list and print summaries
        {
            Console.WriteLine(act.U_Summary());
        }
    }
}
