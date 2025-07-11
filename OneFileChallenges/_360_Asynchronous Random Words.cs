//360 Asynchronous Random Words
Console.Title = "Asynchronous Random Words";


while (true)
{
    Console.WriteLine("Enter a word: ");
    string? _userinput = Console.ReadLine();

    Display(_userinput);
}
async Task Display(string? userinput)
{
    DateTime dateTime = DateTime.Now;
    Console.WriteLine(userinput+" took " + await RandomlyRecreateAsync(userinput) + " tries.");
    Console.WriteLine((DateTime.Now - dateTime).TotalSeconds + " seconds");
}

int RandomlyRecreate(string? word)
{
    if (word == null) return 0;
    Random random = new Random();

    int iterator = 0;
    foreach (char letter in word)
    {
        while(letter != (char)('a' + random.Next(26)) && letter != (char)' ')
            iterator++;
        iterator++;
    }
    return iterator;
}
Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
}
