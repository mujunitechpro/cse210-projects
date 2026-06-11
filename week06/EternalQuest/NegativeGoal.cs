// NegativeGoal.cs (EXCEEDS REQUIREMENTS)
// A "negative goal" — records bad habits and deducts points.
// Helps the users to track things they want to stop doing.

using System;

public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public NegativeGoal(string name, string description, int points, int timesRecorded)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override void RecordEvent(ref int score)
    {
        _timesRecorded++;
        score -= _points;
        if (score < 0) score = 0; 
        Console.WriteLine($"  Oh no! You recorded '{_shortName}' and lost {_points} points. Do better next time! 😬");
        Console.WriteLine($"  (Recorded {_timesRecorded} times total)");
    }

    public override bool IsComplete() => false; 
    public override string GetDetailsString()
    {
        return $"[✗] {_shortName} ({_description}) -- Recorded {_timesRecorded} times (costs {_points} pts each)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_shortName}|{_description}|{_points}|{_timesRecorded}";
    }
}