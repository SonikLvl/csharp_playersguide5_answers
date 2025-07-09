//315 The Long Game
Console.Title = "The Long Game";

int score;

Console.Write("What is your name? ");
string username = Console.ReadLine();
score = File.Exists($"{username}.txt") ? Convert.ToInt32(File.ReadAllText($"{username}.txt")) : 0;
while (true) { 
    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
    {
        Console.WriteLine(score);
        score++;
    }
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        Console.WriteLine("Exit");
        File.WriteAllText($"{username}.txt", Convert.ToString(score));
        Environment.Exit(0);
    }
}