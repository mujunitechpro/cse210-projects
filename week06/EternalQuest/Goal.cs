// Eternal Quest Program 
using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    
    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    // Polymorphism each subclass overrides 
    public abstract void RecordEvent(ref int score);
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
