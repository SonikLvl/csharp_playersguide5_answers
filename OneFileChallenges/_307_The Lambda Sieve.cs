//307 The Lambda Sieve
Console.Title = "The Lambda Sieve";

Console.WriteLine("What check you wanna perform? \n1 - Even, 2 - Positive, 3 - Multiple of 10");
int method = Convert.ToInt32(Console.ReadLine());
Sieve sieve = new Sieve(method switch
{
    2 => x => x >= 0,
    3 => x => x % 10 == 0,
    _ => x => x % 2 == 0,
});
Console.Write("What number to check? ");
int num = Convert.ToInt32(Console.ReadLine());
if (sieve.IsGood(num))
{
    Console.Write("Number meets conditions");
}
else Console.Write("Nah");

public class Sieve
{
    private readonly Func<int, bool> _delegate;

    public Sieve(Func<int, bool> func)
    {
        _delegate = func;
    }
    public bool IsGood(int number) => _delegate(number);
}

