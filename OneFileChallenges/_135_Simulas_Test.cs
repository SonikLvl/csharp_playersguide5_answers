//135 Simula`s Test
Console.Title = "Simula`s Test";

Chest currentState = Chest.Locked;
string userInput;

while (true)
{
    Console.Write($"Chest is {currentState}. What do you want to do? ");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "unlock":
            if (currentState == Chest.Locked)
            {
                currentState = Chest.Closed;
                break;
            }
            goto default;
        case "lock":
            if (currentState == Chest.Closed)
            {
                currentState = Chest.Locked;
                break;
            }
            goto default;
        case "open":
            if (currentState == Chest.Closed)
            {
                currentState = Chest.Opened;
                break;
            }
            goto default;
        case "close":
            if (currentState == Chest.Opened)
            {
                currentState = Chest.Closed;
                break;
            }
            goto default;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

}

enum Chest { Opened, Closed, Locked }