//124 Hunting the Manticore
Console.Title = "Hunting the Manticore";
Console.ForegroundColor = ConsoleColor.White;

int cityHealth = 15;
int manticoreHealth = 10;
int round = 1;
int damage = 1;

int manticoreLocation;
int guessedLocation;

//Player 1 
manticoreLocation = AskForNumberInRange("Player 1, How far from the city do you put the Manticore? ");
Console.Clear();

//Player 2
Console.WriteLine("Player 2, it is your turn.");

while (cityHealth > 0 && manticoreHealth > 0)
{

    Console.WriteLine(DisplayRoundText(round, cityHealth, manticoreHealth));
    damage = ShotType();
    Console.WriteLine($"The canon will deal {damage} damage.");
    Console.ForegroundColor = ConsoleColor.White;

    guessedLocation = AskForNumberInRange("Where will land the next shot? ");

    if (guessedLocation == manticoreLocation)
    {
        Console.WriteLine("That round was a DIRECT hit!");
        manticoreHealth -= damage;
    }
    else
    {
        Console.WriteLine(guessedLocation > manticoreLocation ? "That round OVERSHOT the target." : "That round FELL SHORT of the target.");
        cityHealth--;
    }
    round++;

}
Console.WriteLine(cityHealth != 0 ? "City is saved!!!" : "City is destroyed((((");



//Help Methods
string DisplayRoundText(int round, int cityHealth, int manticoreHealth)
{
    return "----------------------------------------------------------------------------\n" +
          $"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10";
}

int ShotType()
{
    if (round % 3 == 0 && round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        return 10;
    }
    else if (round % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return 3;
    }
    else if (round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        return 3;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        return 1;
    }
}

int AskForNumberInRange(string text, int min = 0, int max = 100)
{
    Console.Write(text);
    while (true)
    {
        int num = Convert.ToInt32(Console.ReadLine());
        if (num < min)
        {
            Console.Write($"Must be more then {min}\n");
            continue;
        }
        if (num > max)
        {
            Console.Write($"Must be less then {max}\n");
            continue;
        }
        return num;
    }
}