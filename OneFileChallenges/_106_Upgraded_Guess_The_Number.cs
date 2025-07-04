//106 Taking a Number
Console.Title = "Guess the number";


int desiredNum = AskForNumberInRange("User 1, enter the desired number: ");
Console.Clear();

int guessedNum = AskForNumberInRange("User 2, guess the number.");

while (desiredNum != guessedNum)
{
    Console.WriteLine(guessedNum > desiredNum ? $"{guessedNum} is too high" : $"{guessedNum} is too low");

    guessedNum = AskForNumberInRange("What do you think next? ");
}
Console.WriteLine($"Thats right it is {guessedNum}!");


//Help Methods
int AskForNumber(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
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