//78_Watchtower
while (true)
{
    Console.Write("What x?");
    int x = Convert.ToInt32(Console.ReadLine());

    Console.Write("What y?");
    int y = Convert.ToInt32(Console.ReadLine());

    string direction = "";

    if (x == 0 && y == 0)
    {
        direction = "here";
    }
    else
    {
        if (y != 0) direction = y > 0 ? "N" : "S";
        if (x != 0) direction += x > 0 ? "E" : "W";
    }

    Console.WriteLine($"Enemy is {direction}");
}
