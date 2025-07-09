//290 Exeptis Game
Console.Title = "Exepti’s Game";
Random random = new Random();
int oatmeal = random.Next(10);
List<int> chosenCookies = new List<int>();
char player = '1';

try
{
    while (true)
    {
        Console.Write($"Player {player} choose your number: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (!chosenCookies.Contains(choice))
            chosenCookies.Add(choice);
        else throw new Exception("Cookie already chosen.");
        player = (player == '1' ? '2' : '1');
    }
}catch(Exception E)
{
    Console.WriteLine(E);
}