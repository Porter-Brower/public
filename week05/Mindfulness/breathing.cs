class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Exercise",
        "Slow down, focus, and relax by pacing your breathing.\nThis short exercise helps clear your mind.")
    {
    }

    public void Run()
    {
        Start();

        int secondsPassed = 0;
        bool longerExhale = true;

        while (secondsPassed < _sessionDuration)
        {
            Console.Write("\nInhale... ");
            ShowCountdown(4);
            secondsPassed += 4;

            if (secondsPassed >= _sessionDuration) break;

            int exhaleTime = longerExhale ? 6 : 5;
            Console.Write("Exhale... ");
            ShowCountdown(exhaleTime);
            secondsPassed += exhaleTime;

            longerExhale = !longerExhale;
        }

        End();
    }
}
