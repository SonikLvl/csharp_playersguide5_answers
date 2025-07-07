//242 The Fountain of Objects
using TheFountainOfObjects;

Console.Title = "The Fountain of Objects";
//INTRODUCTION
Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.\r\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns.\r\nYou must navigate the Caverns with your other senses.\r\n" +
    "You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.\r\n" +
    "Find the Fountain of Objects, activate it, and return to the entrance.\r\n");
Console.WriteLine();
//MAIN GAME
GridManager gridmanager = new GridManager(); //SUGGESTION encapsylate gridmanager to player

Console.WriteLine("Choose world size 1 - small(4x4), 2 - medium(6x6), 3 - large(8x8), 4 - custom.");
int worldChoice = Convert.ToInt32(Console.ReadLine());
Room[,] grid = CreateGrid();

Player player = new Player(grid, gridmanager);

while (true)
{
    GameDisplay(player);
}



//Game methods
Room[,] CreateGrid()
{
    return worldChoice switch
    {
        1 => gridmanager.CreateGrid(4, 4),
        2 => gridmanager.CreateGrid(6, 6, 2, 1,2),
        3 => gridmanager.CreateGrid(8, 8, 4, 2,3),
        4 => CustomGrid(),
        _ => gridmanager.CreateGrid(6, 6)
    };
}
Room[,] CustomGrid()
{
    Console.Write("Choose width: ");
    int width = Convert.ToInt32(Console.ReadLine());
    Console.Write("Choose height: ");
    int height = Convert.ToInt32(Console.ReadLine());
    Console.Write($"Choose pit count(must be less then {(width* height)-2}): ");
    int pitCount = Convert.ToInt32(Console.ReadLine());
    Console.Write($"Choose maelstrom count(must be less then {(width * height) - (2 + pitCount)}): ");
    int maelstromCount = Convert.ToInt32(Console.ReadLine());
    Console.Write($"Choose amarok count(must be less then 8): ");
    int amarokCount = Convert.ToInt32(Console.ReadLine());
    return gridmanager.CreateGrid(width, height, pitCount, maelstromCount, amarokCount);
}
void GameDisplay(Player player)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    //Console.WriteLine(player.MaelstromsPos()); //TEST
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine($"You are in the room at {player.CurrentRoom()}. You have {player.ShotCount} shots."); //invokes ToString automatically

    Console.Write(RoomSpecification(player.CurrentRoom().Type));
    Console.Write(NearPit(player));
    Console.Write(NearMaelstrom(player));
    Console.Write(NearAmarok(player));
    Console.ForegroundColor = ConsoleColor.Gray;

    Console.Write("What will you do? ");

    Console.ForegroundColor = ConsoleColor.Magenta;
    string userInput = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Gray;

    UserCommand(userInput, player);
}
string RoomSpecification(RoomType roomType)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    return roomType switch
    {
        RoomType.Empty => "",
        RoomType.Entarance => "You see light coming from the cavern entrance.\n",
        RoomType.Fountain => "You hear water dripping in this room. The Fountain of Object must be here.\n",
        _ => ""
    };
}
string NearPit(Player player)
{
    if (player.IsNerby(RoomType.Pit))
        return "You feel a draft. There is a pit in nearby room.\n";
    return "";
}

string NearMaelstrom(Player player)
{
    if (player.IsNerby(RoomType.Maelstrom))
        return "You hear the growling and groaning of a maelstrom nearby.\n";
    return "";
}
string NearAmarok(Player player)
{
    if (player.IsNerby(RoomType.Amaroks))
        return "You can smell the rotten stench of an amarok in a nearby room.\n";
    return "";
}
void UserCommand(string userInput, Player player)
{
    userInput = userInput.ToLower();
    switch (userInput)
    {
        case "move west":
            player.Command(new WestCommand());
            break;
        case "move east":
            player.Command(new EastCommand());
            break;
        case "move south":
            player.Command(new SouthCommand());
            break;
        case "move north":
            player.Command(new NorthCommand());
            break;
        case "shoot west":
            player.Command(new WestShoot());
            break;
        case "shoot east":
            player.Command(new EastShoot());
            break;
        case "shoot south":
            player.Command(new SouthShoot());
            break;
        case "shoot north":
            player.Command(new NorthShoot());
            break;
        case "enable fountain":
            player.Command(new EnableFountain());
            break;
        case "exit":
            player.Command(new Exit());
            break;
        default:
            Console.WriteLine("Nothing for that. Try 'move/shoot east/south/west/north'. Then 'enable fountain' or 'exit'.");
            break;
    }
}



