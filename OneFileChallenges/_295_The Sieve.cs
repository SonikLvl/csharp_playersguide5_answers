//295 The Sieve
Console.Title = "The Sieve";

Console.WriteLine("What check you wanna perform? \n1 - Even, 2 - Positive, 3 - Multiple of 10");
int method = Convert.ToInt32(Console.ReadLine());
Sieve sieve = new Sieve(method switch { 
                        2 => IsPositive,
                        3 => IsMultipleof10,
                        _ => IsEven,
                        });
Console.Write("What number to check? ");
int num = Convert.ToInt32(Console.ReadLine());
if (sieve.IsGood(num))
{
    Console.Write("Number meets conditions");
}else Console.Write("Nah");
bool IsEven(int number)
    {
        if (number % 2 == 0)
            return true;
        return false;
    }
bool IsPositive(int number)
{
    if (number >= 0)
        return true;
    return false;
}
bool IsMultipleof10(int number)
{
    if (number % 10 == 0)
        return true;
    return false;
}
public class Sieve
{
    private readonly Func<int, bool> _delegate;

    public Sieve(Func<int, bool> func)
    {
        _delegate = func;
    }
    public bool IsGood(int number) => _delegate(number);
}

