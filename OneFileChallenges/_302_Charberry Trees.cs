//302 Charberry Trees
Console.Title = "Charberry Trees";

CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);
while (true)
    tree.MaybeGrow();


public class CharberryTree
{
    private Random _random = new Random();
    public event Action? Ripened;
    public bool Ripe { get; set; }
    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened();
        }
    }
}

public class Notifier
{
    private void OnRipened() => Console.WriteLine("A charberry fruit has ripened!");
    public Notifier(CharberryTree charberryTree)
    {
        charberryTree.Ripened += OnRipened;
    }
}

public class Harvester
{
    CharberryTree _charberryTree;
    private void OnRipened() => _charberryTree.Ripe = false;

    public Harvester(CharberryTree charberryTree)
    {
        charberryTree.Ripened += OnRipened;
        _charberryTree = charberryTree;
    }
}