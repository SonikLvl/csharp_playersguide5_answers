//195 Packing Inventory
Console.Title = "Packing Inventory";

Pack pack = new Pack(10, 10);
int userChoise;
Console.WriteLine(pack.MaxCapability());
while (true)
{
    Console.WriteLine($"\n{pack.ToString()}" +
        "\nWhat do you want to do?\n" +
                      "0 - Add Arrow, 1 - Add Bow, 2 - Add Rope, 3 - Add Water, 4 - Add Food, 5 - Add Sword, 6 - Show taken Weight and Volume, 7 - Show max Weight and Volume, 8 - Show Item count");
    userChoise = Convert.ToInt32(Console.ReadLine());
    switch (userChoise)
    {
        case 0:
            pack.Add(new Arrow());
            break;
        case 1:
            pack.Add(new Bow());
            break;
        case 2:
            pack.Add(new Rope());
            break;
        case 3:
            pack.Add(new Water());
            break;
        case 4:
            pack.Add(new Food());
            break;
        case 5:
            pack.Add(new Sword());
            break;
        case 6:
            Console.WriteLine($"Pack has Weight of {pack.currentWeight},  Volume of {pack.currentVolume}");
            break;
        case 7:
            Console.WriteLine(pack.MaxCapability());
            break;
        case 8:
            Console.WriteLine("Number of items "+pack.NumberOfItems());
            break;
        default:
            Console.WriteLine("Nothing for that.");
            break;
    }
}

class InventoryItem
{
    public float Weight { get; init; }
    public float Volume { get; init; }
    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}
class Arrow() : InventoryItem(0.1f, 0.05f) { public override string ToString() { return "Arrow"; } }
class Bow() : InventoryItem(1f, 4f) { public override string ToString() { return "Bow"; } }
class Rope() : InventoryItem(1f, 1.5f) { public override string ToString() { return "Rope"; } }
class Water() : InventoryItem(2f, 3f) { public override string ToString() { return "Water"; } }
class Food() : InventoryItem(1f, 0.5f) { public override string ToString() { return "Food"; } }
class Sword() : InventoryItem(5f, 3f) { public override string ToString() { return "Sword"; } }

class Pack
{
    private float MaxWeight { get; init; }
    private float MaxVolume { get; init; }
    public float currentWeight { get; private set; }
    public float currentVolume { get; private set; }
    public List<InventoryItem> ItemList = new List<InventoryItem>();

    public Pack(float maxWeight, float maxVolume)
    {
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public bool Add(InventoryItem item)
    {
        if(item.Weight+ currentWeight <= MaxWeight && item.Volume + currentVolume <= MaxVolume)
        {
            ItemList.Add(item);
            currentWeight += item.Weight;
            currentVolume += item.Volume;

            Console.WriteLine($"{item} was added.");
            return true;
        }
        else
        {
            Console.WriteLine("Item cannot fit in the Pack.");
            return false;
        }
    }
    public string MaxCapability() => $"Pack has Max Weight of {MaxWeight}, Max Volume of {MaxVolume}";
    public int NumberOfItems() => ItemList.Count();

    public override string ToString()
    {
        string items = "";
        foreach (var item in ItemList)
        {
            items += item.ToString();
            items += " ";
        }
        return "Pack contains " + items;
    }
}