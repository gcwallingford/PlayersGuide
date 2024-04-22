using exercise_30;

Console.WriteLine("Enter 3 commands");
Console.WriteLine("Commands:");
Console.WriteLine("(On/Off)");
Console.WriteLine("(North/South/East/West");
Robot robot = new Robot();
string? input1 = Console.ReadLine().ToLower();

if (input1 != "on")
{
    Console.WriteLine("Robot must be turned on to perform commands");
}
else
{
    robot.Commands[0] = new OnCommand();
    string? input2 = Console.ReadLine().ToLower();
    string? input3 = Console.ReadLine().ToLower();

    switch (input2)
    {
        case "off":
            robot.Commands[1] = new OffCommand();
            break;
        case "north":
            robot.Commands[1] = new NorthCommand();
            break;
        case "south":
            robot.Commands[1] = new SouthCommand();
            break;
        case "east":
            robot.Commands[1] = new EastCommand();
            break;
        case "west":
            robot.Commands[1] = new WestCommand();
            break;
    }

    switch (input3)
    {
        case "on":
            robot.Commands[2] = new OnCommand();
            break;
        case "off":
            robot.Commands[2] = new OffCommand();
            break;
        case "north":
            robot.Commands[2] = new NorthCommand();
            break;
        case "south":
            robot.Commands[2] = new SouthCommand();
            break;
        case "east":
            robot.Commands[2] = new EastCommand();
            break;
        case "west":
            robot.Commands[2] = new WestCommand();
            break;
    }
    robot.Run();
}

