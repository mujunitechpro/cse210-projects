// ChecklistGoal.cs
using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent(ref int score)
    {
        if (IsComplete())
        {
            Console.WriteLine($"  '{_shortName}' is already fully complete!");
            return;
        }

        _amountCompleted++;
        score += _points;

        if (IsComplete())
        {
            score += _bonus;
            Console.WriteLine($"  Amazing! You completed '{_shortName}' for the {_amountCompleted}/{_target} time!");
            Console.WriteLine($"  You earned {_points} points PLUS a bonus of {_bonus} points! 🎉");
        }
        else
        {
            Console.WriteLine($"  Nice! You recorded '{_shortName}' ({_amountCompleted}/{_target}) and earned {_points} points.");
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}