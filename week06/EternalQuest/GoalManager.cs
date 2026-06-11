// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _playerName;

    // --- EXCEEDS REQUIREMENTS ---
    private static readonly (int threshold, string title)[] Levels = new[]
    {
        (0,     "Novice Adventurer"),
        (500,   "Apprentice Hero"),
        (1500,  "Bronze Warrior"),
        (3000,  "Silver Knight"),
        (6000,  "Gold Champion"),
        (10000, "Platinum Legend"),
        (20000, "Diamond Sage"),
        (50000, "Eternal Quest Master"),
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _playerName = "Player";
    }

        public void Start()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        ✨ ETERNAL QUEST ✨            ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.Write("Enter your name, brave soul: ");
        _playerName = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(_playerName)) _playerName = "Hero";

        string choice;
        do
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event (accomplish a goal)");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice from the menu: ");
            choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": Console.WriteLine("\nFarewell, brave adventurer! Keep questing! 🏆"); break;
                default: Console.WriteLine("  Invalid choice. Please try again."); break;
            }
        } while (choice != "6");
    }


    public void DisplayPlayerInfo()
    {
        string level = GetLevel();
        Console.WriteLine($"  Player: {_playerName}  |  Score: {_score} points  |  Level: {level}");
    }

    private string GetLevel()
    {
        string current = Levels[0].title;
        foreach (var (threshold, title) in Levels)
            if (_score >= threshold) current = title;
        return current;
    }

    
    //  List goals
        public void ListGoalNames()
    {
        if (_goals.Count == 0) { Console.WriteLine("  No goals yet!"); return; }
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].ShortName}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\n--- Your Goals ---");
        if (_goals.Count == 0) { Console.WriteLine("  No goals yet!"); return; }
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
    }

   
    //  Create a goal
        public void CreateGoal()
    {
        Console.WriteLine("\n--- Create a New Goal ---");
        Console.WriteLine("  Types: 1) Simple  2) Eternal  3) Checklist  4) Negative (bad habit)");
        Console.Write("  Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine()?.Trim();

        Console.Write("  What is the short name of your goal? ");
        string name = Console.ReadLine()?.Trim();

        Console.Write("  What is a short description of it? ");
        string description = Console.ReadLine()?.Trim();

        Console.Write("  What is the amount of points associated with this goal? ");
        int.TryParse(Console.ReadLine()?.Trim(), out int points);

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("  Simple Goal created!");
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("  Eternal Goal created!");
                break;

            case "3":
                Console.Write("  How many times does this goal need to be accomplished? ");
                int.TryParse(Console.ReadLine()?.Trim(), out int target);
                Console.Write("  What is the bonus for accomplishing it that many times? ");
                int.TryParse(Console.ReadLine()?.Trim(), out int bonus);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("  Checklist Goal created!");
                break;

            case "4":
                Console.WriteLine("  (Points will be DEDUCTED each time you record this!)");
                _goals.Add(new NegativeGoal(name, description, points));
                Console.WriteLine("  Negative Goal created! Stay strong!");
                break;

            default:
                Console.WriteLine("  Invalid choice. No goal created.");
                break;
        }
    }

    
    //  Record an event
  
    public void RecordEvent()
    {
        Console.WriteLine("\n--- Record Goal Event ---");
        if (_goals.Count == 0) { Console.WriteLine("  No goals to record!"); return; }

        ListGoalNames();
        Console.Write("  Which goal did you accomplish? (number) ");
        if (!int.TryParse(Console.ReadLine()?.Trim(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("  Invalid selection.");
            return;
        }

        int scoreBefore = _score;
        _goals[index - 1].RecordEvent(ref _score);

        int gained = _score - scoreBefore;
        if (gained > 0)
            Console.WriteLine($"  Total Score: {_score} points  (+{gained})");
        else if (gained < 0)
            Console.WriteLine($"  Total Score: {_score} points  ({gained})");
        else
            Console.WriteLine($"  Total Score: {_score} points");

    
        string level = GetLevel();
        Console.WriteLine($"  Current Level: {level}");
    }

    
    //  Save goals
        public void SaveGoals()
    {
        Console.Write("\n  Enter filename to save to (e.g. goals.txt): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(filename)) filename = "goals.txt";

        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(_playerName);
        writer.WriteLine(_score);
        writer.WriteLine(_goals.Count);
        foreach (Goal g in _goals)
            writer.WriteLine(g.GetStringRepresentation());

        Console.WriteLine($"  Goals saved to '{filename}'!");
    }

    //  Load goals
    
    public void LoadGoals()
    {
        Console.Write("\n  Enter filename to load from (e.g. goals.txt): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(filename)) filename = "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine($"  File '{filename}' not found.");
            return;
        }

        _goals.Clear();

        using StreamReader reader = new StreamReader(filename);
        _playerName = reader.ReadLine();
        int.TryParse(reader.ReadLine(), out _score);
        int.TryParse(reader.ReadLine(), out int count);

        for (int i = 0; i < count; i++)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split('|');

            Goal g = parts[0] switch
            {
                "SimpleGoal" => new SimpleGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    bool.Parse(parts[4])),

                "EternalGoal" => new EternalGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3])),

                "ChecklistGoal" => new ChecklistGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])),

                "NegativeGoal" => new NegativeGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4])),

                _ => null
            };

            if (g != null) _goals.Add(g);
        }

        Console.WriteLine($"  Loaded {_goals.Count} goals for {_playerName} with {_score} points!");
    }
}