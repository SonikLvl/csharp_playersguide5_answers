//210 POld Robot
Console.Title = "The Old Robot";

RobotCommand[] commands = new RobotCommand[3];
RobotCommand command;
string userInput;

for (int i = 0; i<3; i++)
{
    userInput = Console.ReadLine();

    command = userInput switch
    {
        "off" => new OffCommand(),
        "on" => new OnCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
        _ => new OffCommand()
    };
    commands[i] = command;
}
Robot robot = new Robot() { Commands = commands }; 
robot.Run();
public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}
class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered)
            robot.Y++;
    }
}
class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered)
            robot.Y--;
    }
}
class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered)
            robot.X--;
    }
}
class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered)
            robot.X++;
    }
}
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; init; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}