//331 Navigating Operand City
Console.Title = "Navigating Operand City";

BlockCoordinate blockCoordinate = new BlockCoordinate(4, 4);
BlockOffset blockOffset = new BlockOffset(0, 4);
Console.WriteLine("Initial: " + blockCoordinate);
blockCoordinate += blockOffset;
Console.WriteLine("With offset: " + blockCoordinate);
blockCoordinate = blockCoordinate + (BlockOffset)Direction.North;
Console.WriteLine("Direction north: " + blockCoordinate);

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset) => new BlockCoordinate(coordinate.Row + offset.RowOffset, coordinate.Column + offset.ColumnOffset);
    public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction) => new BlockCoordinate(coordinate.Row + direction switch { Direction.East => +1, Direction.West => -1, _ => 0}, coordinate.Column + direction switch { Direction.North => +1, Direction.South => -1, _ => 0 });
    
    public int this[int index]
    {
        get
        {
            if (index == 0) return Row;
            else return Column;
        }
    }
}
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction) => direction switch
    {
        Direction.North => new BlockOffset(0, 1),
        Direction.East => new BlockOffset(1, 0),
        Direction.South => new BlockOffset(0, -1),
        Direction.West => new BlockOffset(-1, 0),
        _ => new BlockOffset(0, 0)
    };
}
public enum Direction { North, East, South, West }
