// EternalGoal.cs

using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent(ref int score)
    {
        score += _points;
        Console.WriteLine($"  Great work! You recorded '{_shortName}' and earned {_points} points. Keep it up!");
    }

    public override bool IsComplete() => false; 
    public override string GetDetailsString()
    {
        return $"[∞] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}