//153-173 Vin Fletcher`s Arrows
Console.Title = "Vin Fletcher`s Arrows";

(Arrowhead arrowhead, Flenching flenching, int length) userInput;
int choice;
int arrowType;
Arrow arrow;

Console.Write("0 - Choose existing, 1 - Make it yourself \n" +
                  "How would you prefer to make your arrows? ");
choice = (int)Convert.ToInt32(Console.ReadLine());

if(choice == 0)
{
    ExistingArrow();
}
else
{
    DIYarrow();
}

void ExistingArrow()
{
    Console.Write("0 - Marksman, 1 - Elite, 2 - Beginner \n" +
                      "What arrow do you want? ");
    arrowType = (int)Convert.ToInt32(Console.ReadLine());
    if (arrowType == 0)
    {
        arrow = Arrow.MarksmanArrow();
    }else if(arrowType == 1)
    {
        arrow = Arrow.EliteArrow();
    }
    else
    {
        arrow = Arrow.BeginnerArrow();
    }
}
void DIYarrow()
{
    Console.Write("0 - Obsidian, 1 - Wood, 2 - Steel \n" +
                      "What arrowhead do you want? ");
    userInput.arrowhead = (Arrowhead)Convert.ToInt32(Console.ReadLine());

    Console.Write("0 - Plastic, 1 - TurkeyFeather, 2 - GooseFeather \n" +
                  "What flenching do you want? ");
    userInput.flenching = (Flenching)Convert.ToInt32(Console.ReadLine());

    Console.Write("What length do you want? ");
    userInput.length = Convert.ToInt32(Console.ReadLine());

    //Arrow arrow = new Arrow(userInput.arrowhead, userInput.flenching, userInput.length);
    arrow = new Arrow { Arrowhead = userInput.arrowhead, Flenching = userInput.flenching, Length = userInput.length };
}
Console.WriteLine($"That arrow will cost {arrow.Cost}");

class Arrow
{
    public Arrowhead Arrowhead { get; init; }
    public Flenching Flenching { get; init; }
    public int Length { get; init; }
    private float cost; //saving the value
    public float Cost //getter and setter(property) for the field cost
    {
        get
        {
            cost += Arrowhead switch
            {
                Arrowhead.Obsidian => 5,
                Arrowhead.Wood => 3,
                Arrowhead.Steel => 10,
                _ => 0
            };
            cost += Flenching switch
            {
                Flenching.Plastic => 10,
                Flenching.TurkeyFeather => 5,
                Flenching.GooseFeather => 3,
                _ => 0
            };
            cost += Length * 0.05f;
            return cost;
        }
        private set => cost = value;
        }
    

    //public Arrow(Arrowhead arrowhead, Flenching flenching, int length)
    //{
    //    Arrowhead = arrowhead;
    //    Flenching = flenching;
    //    Length = length;
    //}
    public static Arrow EliteArrow() => new Arrow { Arrowhead = Arrowhead.Steel, Flenching = Flenching.Plastic, Length = 95 };
    public static Arrow BeginnerArrow() => new Arrow { Arrowhead = Arrowhead.Wood, Flenching = Flenching.GooseFeather, Length = 75 };
    public static Arrow MarksmanArrow() => new Arrow { Arrowhead = Arrowhead.Steel, Flenching = Flenching.GooseFeather, Length = 65 };

    //public float GetCost()
    //{
    //    cost += Arrowhead switch 
    //    {
    //        Arrowhead.Obsidian => 5,
    //        Arrowhead.Wood => 3,
    //        Arrowhead.Steel => 10,
    //        _ => 0
    //    };
    //    cost += Flenching switch
    //    {
    //        Flenching.Plastic => 10,
    //        Flenching.TurkeyFeather => 5,
    //        Flenching.GooseFeather => 3,
    //        _ => 0
    //    };
    //    cost += Length * 0.05f;
    //    return cost;
    //}
}

enum Arrowhead { Steel, Wood, Obsidian}
enum Flenching { Plastic, TurkeyFeather, GooseFeather}