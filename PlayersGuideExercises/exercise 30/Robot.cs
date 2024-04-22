namespace exercise_30;

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool isPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach (var command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {isPowered}]");
        }
    }
}

