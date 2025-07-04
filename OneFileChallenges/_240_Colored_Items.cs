//240 Colored Items
Console.Title = "Colored Items";

Sword sword = new Sword();
Bow bow = new Bow();
Axe axe = new Axe();

ColoredItem<Sword> item1 = new ColoredItem<Sword>(sword, ConsoleColor.Cyan);
ColoredItem<Bow> item2 = new ColoredItem<Bow>(bow, ConsoleColor.Red);
ColoredItem<Axe> item3 = new ColoredItem<Axe>(axe, ConsoleColor.Magenta);

item1.Display();
item2.Display();
item3.Display();

public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>(T item, ConsoleColor color)
{
    public void Display()
    {
        Console.ForegroundColor = color;
        Console.WriteLine(item.ToString());
        Console.ForegroundColor = default;
    }
}