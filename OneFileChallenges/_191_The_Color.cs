//191 The Color
Console.Title = "The Color";

myColor colorCustomF = new myColor(266, 23, 24);
myColor colorCustomT = new myColor(4, 5, 34);
myColor colorRed = myColor.Red;

colorCustomF.DisplayColor();
colorCustomT.DisplayColor();
colorRed.DisplayColor();

public class myColor
{
    private int _red { get; init; } = 0;
    private int _green { get; init; } = 0;
    private int _blue { get; init; } = 0;

    public myColor(int red, int green, int blue)
    {
        if (red > 255 || green > 255 || blue > 255) Console.WriteLine("Color value must be less then 255");
        else {
            _red = red;
            _green = green;
            _blue = blue;
        }
    }
    public static myColor White => new myColor(255, 255, 255);
    public static myColor Black => new myColor(0, 0, 0);
    public static myColor Red => new myColor(255, 0, 0);
    public static myColor Orange => new myColor(255, 165, 0);
    public static myColor Yellow => new myColor(255, 255, 0);
    public static myColor Green => new myColor(0, 128, 0);
    public static myColor Blue => new myColor(0, 0, 255);
    public static myColor Purple => new myColor(128, 0, 128);
    public void DisplayColor()
    {
        Console.WriteLine($"Color with values ({_red}, {_green}, {_blue})");
    }
}