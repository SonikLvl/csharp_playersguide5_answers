//324 The Potion Masters of Pattren
Console.Title = "The Potion Masters of Pattren";

Potion potion = new Potion(PotionType.Water);
Ingredient ingredient;

while (true)
{
    Console.WriteLine("--------------------------\n"+$"You have {PotionDisplay(potion)}.");
    Console.WriteLine("What do you want to add?\n" +
                      "0 - Water(start over), 1 - Stardust, 2 - Venom, 3 - DragonBreath, 4 - ShadowGlass, 5 - EyeshineGem");
    try
    {
        ingredient = (Ingredient)Convert.ToInt32(Console.ReadLine());
        potion = ingredient switch
        {
            Ingredient.Water => potion with { _potionType = PotionType.Water },
            Ingredient.Stardust when potion._potionType == PotionType.Water => potion with { _potionType = PotionType.Elixir },
            Ingredient.Venom when potion._potionType == PotionType.Elixir => potion with { _potionType = PotionType.Poison },
            Ingredient.DragonBreath when potion._potionType == PotionType.Elixir => potion with { _potionType = PotionType.Flying },
            Ingredient.ShadowGlass when potion._potionType == PotionType.Elixir => potion with { _potionType = PotionType.Invisibility },
            Ingredient.EyeshineGem when potion._potionType == PotionType.Elixir => potion with { _potionType = PotionType.NightSight },
            Ingredient.ShadowGlass when potion._potionType == PotionType.NightSight => potion with { _potionType = PotionType.CloudyBrew },
            Ingredient.EyeshineGem when potion._potionType == PotionType.Invisibility => potion with { _potionType = PotionType.CloudyBrew },
            Ingredient.Stardust when potion._potionType == PotionType.CloudyBrew => potion with { _potionType = PotionType.Wraith },
            _ => potion with { _potionType = PotionType.Ruined },
        };
    }
    catch (Exception) 
    {
        Console.WriteLine($"Yeah youre done. You have {PotionDisplay(potion)}");
        Environment.Exit(0); 
    }
    
}

string PotionDisplay(Potion potion)
{
    return potion._potionType switch
    {
        PotionType.Water => "water",
        PotionType.Elixir => "Elixir potion",
        PotionType.Poison => "Poison potion",
        PotionType.Flying => "Flying potion",
        PotionType.Invisibility => "Invisibility potion",
        PotionType.NightSight => "Night Sight potion",
        PotionType.CloudyBrew => "cloudy brew",
        PotionType.Wraith => "Wraith potion",
        PotionType.Ruined => "ruined potion",
        _ => "What is that?"
    };
}
public record Potion(PotionType _potionType);
public enum PotionType { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
enum Ingredient { Water, Stardust, Venom, DragonBreath, ShadowGlass, EyeshineGem }