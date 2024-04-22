namespace exercise_30;

public class RobotCommand
{
    public void Run(Robot robot)
    {
        
    }
}

public class OnCommand : RobotCommand
{
    public new void Run(Robot robot)
    {
        robot.isPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public new void Run(Robot robot)
    {
        robot.isPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public new void Run(Robot robot)
    {
        robot.Y--;
    }
}
public class SouthCommand : RobotCommand
{
    public new void Run(Robot robot)
    {
        robot.Y++;
    }
}
public class EastCommand : RobotCommand
{
    public new void Run(Robot robot)
    {
        robot.X++;
    }
}
public class WestCommand : RobotCommand
{
    public new void Run(Robot robot)
    {
        robot.X--;
    }
}