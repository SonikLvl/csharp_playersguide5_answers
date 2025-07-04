//226 Room Coordinates
Console.Title = "Room Coordinates";

Coordinate coord1 = new Coordinate(1,1);
Coordinate coord2 = new Coordinate(5,1);
Coordinate coord3 = new Coordinate(2,1);

Console.WriteLine(coord1.Adjacent(coord2));
Console.WriteLine(coord1.Adjacent(coord3));

public struct Coordinate
{
    private int Row { get; init; }
    private int Column { get; init; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public string Adjacent(Coordinate coordinate)
    {
        if(Math.Abs(Row - coordinate.Row) == 1 || Math.Abs(Column - coordinate.Column) == 1)
        {
            return $"({Row}, {Column}) is adjacent to ({coordinate.Row}, {coordinate.Column})";
        }
        return "Nah";
    }
}