//191 The Point
Console.Title = "The Point";

Point point1 = new Point(2, 3);
Point point2 = new Point(-4, 0);

point1.DisplayPoint();
point2.DisplayPoint();

public class Point
{
    public float _x { get; set; }
    public float _y { get; set; }

    public Point(float x, float y)
    {
        _x = x;
        _y = y;
    }
    public static Point Pointo => new Point(0.0f, 0.0f);
    public void DisplayPoint()
    {
        Console.WriteLine($"point on coordinaes ({_x},{_y})");
    }
}