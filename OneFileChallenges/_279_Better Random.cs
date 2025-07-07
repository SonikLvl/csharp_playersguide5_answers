//279 Better Random
Console.Title = "Better Random";
Random random = new Random();
random.NextDouble();
random.CoinFlip();
random.NextString(new string[]{ "", ""});
public static class RandomExtention
{
    public static double NextDouble(this Random random, double number)
    {
        return random.NextDouble() * number;
    }
    public static string NextString(this Random random, params string[] list)
    {
        return list[random.Next(list.Length)];
    }
    public static bool CoinFlip(this Random random, int number = 50)
    {
        int coinflip = random.Next(101);
        if (coinflip <= number)
            return true;
        else
            return false;
    }
}

