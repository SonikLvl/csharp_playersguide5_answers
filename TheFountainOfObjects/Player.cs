namespace TheFountainOfObjects
{
    public class Player
    {
        public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;
        public int ShotCount { get; set; } = 3;
        public Room[,] Grid { get; private set; }
        private GridManager GridManager { get; init; } // main game needs only to know player to be able to interact with Gridmanager 
        public Player(Room[,] grid, GridManager gridManager)
        {
            Grid = grid;
            GridManager = gridManager;
        }
        public Room CurrentRoom() => Grid[Row, Column];
        public void ChangeMaelstromPosition() => Grid = GridManager.ChangeMaelstromPosition(CurrentRoom(), Grid);
        public void KillMonster(Room room) => Grid = GridManager.KillMonster(room, Grid);
        public bool IsNerby(RoomType roomType) => GridManager.IsNerby(Grid, CurrentRoom(), roomType);


        public void Command(ICommand command)
        {
            command?.Run(this);
            new GameOverCheck().Run(this);
        }

        //FOR TEST PURPOSES
        public string MaelstromsPos()
        {
            string maelstroms = "";
            foreach (var room in Grid)
            {
                if(room.Type == RoomType.Maelstrom || room.Type == RoomType.Amaroks || room.Type == RoomType.Fountain) { 
                maelstroms += room.Type + " ";
                maelstroms += room.ToString();
                maelstroms += "; ";
                }
            }
            return maelstroms;
        }
    }
}
