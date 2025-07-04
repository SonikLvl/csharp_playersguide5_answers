//83 Discounted Inventory
while (true)
{
    Console.Write("The following is available:\n" +
                  "1 - Rope\n" +
                  "2 - Tourches\n" +
                  "3 - Climbing equipment\n" +
                  "4 - Clean Water\n" +
                  "5 - Machete\n" +
                  "6 - Canoe\n" +
                  "7 - Food Supplies\n" +
                  "What number do you want to see the price of? ");
    int itemNum = Convert.ToInt32(Console.ReadLine());
    Console.Write("\nWhat is your name?");
    string? name = Console.ReadLine();

    string item = "";
    float cost = 0.0f;

    item = itemNum switch
    {
        1 => "Rope",
        2 => "Tourches",
        3 => "Climbing equipment",
        4 => "Clean Water",
        5 => "Machete",
        6 => "Canoe",
        7 => "Food Supplies",
        _ => "Unknown item"
    };
    cost = itemNum switch
    {
        1 => 10,
        2 => 15,
        3 => 25,
        4 => 1,
        5 => 20,
        6 => 200,
        7 => 1,
        _ => 100000000
    };
    if (name == "Sonik") cost /= 2;

    Console.WriteLine($"{item} costs {cost} gold.\n\n");
}
