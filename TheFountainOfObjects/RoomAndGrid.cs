namespace TheFountainOfObjects
{
    public class GridManager 
    {
        public static bool IsFountainRunning { get; set; } = false; //shared field across classes (can be in player more on point in grid)
        public Room[,] CreateGrid(int width, int height, int pitCount = 1, int maelstromCount = 0, int amarokCount = 0) // creates a grid. One manager can have several grids
        {
            Room[,] grid = new Room[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i, j] = new Room(i, j, RoomType.Empty); // makes a grid with all empty rooms
                }
            }
            grid[0, 0] = grid[0, 0] with { Type = RoomType.Entarance }; // changing record property to have starting room

            RandomEmptyRoom(grid, RoomType.Fountain);//choosing random empty room to have fountain

            for (int i = 0; i < pitCount; i++)
            {
                RandomEmptyRoom(grid, RoomType.Pit);//choosing random empty room to have pit
            }
            for (int i = 0; i < maelstromCount; i++)
            {
                RandomEmptyRoom(grid, RoomType.Maelstrom);//choosing random empty room to have maelstrom
            }
            for (int i = 0; i < amarokCount; i++)
            {
                Room amarok = RandomEmptyRoom(grid, RoomType.Amaroks);
                if (IsNerby(grid, amarok, RoomType.Fountain))
                {
                    continue; //restarting the loop
                }
                else 
                {
                    i--;
                    grid[amarok.Row, amarok.Column] = amarok with { Type = RoomType.Empty }; 
                } //changing back to empty if conditions are not met
            }
            return grid;
        }

        private Room RandomEmptyRoom(Room[,] grid, RoomType roomType)
        {
            Random random = new Random();
            int row = random.Next(0, grid.GetLength(0));
            int column = random.Next(0, grid.GetLength(1));
            if (grid[row, column].Type == RoomType.Empty)
            {
                grid[row, column] = grid[row, column] with { Type = roomType };// changing record property to have one room with fountain
                return grid[row, column];
            }
            return RandomEmptyRoom(grid, roomType);
        }

        public Room[,] ChangeMaelstromPosition(Room currentPosition, Room[,] grid)
        {
            if (currentPosition.Type == RoomType.Maelstrom)
            {
                grid[currentPosition.Row, currentPosition.Column] = currentPosition with { Type = RoomType.Empty }; //make current position empty room
                RandomEmptyRoom(grid, RoomType.Maelstrom); //add new maelstrom
            }
            else Console.WriteLine("WARNING: No maelstorm passed to change position of.");
            return grid;
        }
        public Room[,] KillMonster(Room shotPosition, Room[,] grid)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (shotPosition.Type == RoomType.Maelstrom || shotPosition.Type == RoomType.Amaroks)
            {
                grid[shotPosition.Row, shotPosition.Column] = shotPosition with { Type = RoomType.Empty }; //make shot position empty room
                Console.WriteLine("You shot the monster!");
            }
            else Console.WriteLine("Nothing was shot.");
            Console.ForegroundColor = ConsoleColor.Gray;
            return grid;
        }

        public bool IsNerby(Room[,] grid, Room currentRoom, RoomType roomType) 
        {
            int row = currentRoom.Row;
            int column = currentRoom.Column;

            Room[] nearbyRooms = { //all posibble positions
                grid[IsIndexOfArray(row, grid.GetLength(0)-1, -1), IsIndexOfArray(column, grid.GetLength(1) - 1, -1)], // -1 -1
                grid[IsIndexOfArray(row, grid.GetLength(0)-1, 0), IsIndexOfArray(column, grid.GetLength(1) - 1, -1)], // 0 -1
                grid[IsIndexOfArray(row, grid.GetLength(0)-1, -1), IsIndexOfArray(column, grid.GetLength(1) - 1, 0)],  // -1 0
                grid[IsIndexOfArray(row, grid.GetLength(0)-1, 1), IsIndexOfArray(column, grid.GetLength(1) - 1, 1)], // 1 1
                grid[IsIndexOfArray(row, grid.GetLength(0) - 1, -1) , IsIndexOfArray(column, grid.GetLength(1) - 1, 1)],  //-1 1
                grid[IsIndexOfArray(row, grid.GetLength(0) - 1, 1) , IsIndexOfArray(column, grid.GetLength(1) - 1, -1)],  //1 -1
                grid[IsIndexOfArray(row, grid.GetLength(0) - 1, 0) , IsIndexOfArray(column, grid.GetLength(1) - 1, 1)], //0 1
                grid[IsIndexOfArray(row, grid.GetLength(0) - 1, 1) , IsIndexOfArray(column, grid.GetLength(1) - 1, 0)] }; //1 0

            foreach (var nearbyRoom in nearbyRooms)
            {
                if (nearbyRoom.Type == roomType)
                    return true;
            }
            return false;
        }
        private int IsIndexOfArray(int index, int max, int valueToAdd)
        {
            if (index + valueToAdd < 0) return index;
            if (index + valueToAdd > max) return index;
            return index + valueToAdd;
        }
    }

    public record Room(int Row, int Column, RoomType Type) //represents a room coords and type
    {
        public override string ToString()
        {
            return $"({Row}, {Column})";
        }
    }
    public enum RoomType { Empty, Fountain, Entarance, Pit, Maelstrom, Amaroks }
}

