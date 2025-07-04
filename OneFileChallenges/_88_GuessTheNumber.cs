//88 The Prototype
Console.Title = "Guess the number";

Console.Write("User 1, enter the desired number: ");
int desiredNum = Convert.ToInt32(Console.ReadLine());
Console.Clear();

Console.Write("User 2, guess the number.");
int guessedNum = Convert.ToInt32(Console.ReadLine());
while (desiredNum != guessedNum)
{
    Console.WriteLine(guessedNum > desiredNum ? $"{guessedNum} is too high" : $"{guessedNum} is too low");

    Console.Write("What do you think next? ");
    guessedNum = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine($"Thats right it is {guessedNum}!");