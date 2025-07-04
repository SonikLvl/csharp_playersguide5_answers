//107 Recursive CountDown
Console.Title = "CountDown";
RecursiveCountDown(10);

int RecursiveCountDown(int currentIteration)
{
    Console.WriteLine($"Its {currentIteration}");

    if (currentIteration <= 0)
        return 0;
    return RecursiveCountDown(currentIteration - 1);
}