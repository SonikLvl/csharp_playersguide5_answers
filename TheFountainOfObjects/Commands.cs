namespace TheFountainOfObjects
{
    public interface ICommand
    {
        public void Run(Player player);
    }

    //MOVEMENT
    class NorthCommand : ICommand
    {
        public void Run(Player player)
        {
            if (player.Column < player.Grid.GetLength(1)-1) // check to not get negative coords for player
                player.Column++;
        }
    }
    class SouthCommand : ICommand
    {
        public void Run(Player player)
        {
            if (player.Column > 0)
                player.Column--;
        }
    }
    class WestCommand : ICommand
    {
        public void Run(Player player)
        {
            if (player.Row > 0)
                player.Row--;
        }
    }
    class EastCommand : ICommand
    {
        public void Run(Player player)
        {
            if (player.Row < player.Grid.GetLength(0)-1)
                player.Row++;
        }
    }

    //SHOOTING
    class NorthShoot : ICommand
    {
        public void Run(Player player)
        {
            if (player.Column < player.Grid.GetLength(1) - 1) // check to not get negative coords for player
            {
                if (player.ShotCount > 0)
                {
                    player.KillMonster(player.Grid[player.CurrentRoom().Row, player.CurrentRoom().Column + 1]);
                    player.ShotCount--;
                }
            }
        }
    }
    class SouthShoot : ICommand
    {
        public void Run(Player player)
        {
            if (player.Column > 0)
            {
                if (player.ShotCount > 0)
                {
                    player.KillMonster(player.Grid[player.CurrentRoom().Row, player.CurrentRoom().Column - 1]);
                    player.ShotCount--;
                }
            }
        }
    }
    class WestShoot : ICommand
    {
        public void Run(Player player)
        {
            if (player.Row > 0)
            {
                if (player.ShotCount > 0)
                {
                    player.KillMonster(player.Grid[player.CurrentRoom().Row - 1, player.CurrentRoom().Column]);
                    player.ShotCount--;
                }
            }
        }
    }
    class EastShoot : ICommand
    {
        public void Run(Player player)
        {
            if (player.Row < player.Grid.GetLength(0) - 1)
            {
                if (player.ShotCount > 0)
                {
                    player.KillMonster(player.Grid[player.CurrentRoom().Row + 1, player.CurrentRoom().Column]);
                    player.ShotCount--;
                }
            }
        }
    }

    //ELSE
    class EnableFountain : ICommand
    {
        public void Run(Player player)
        {
            if (player.CurrentRoom().Type == RoomType.Fountain) //SUGGESTION make check if fountain is already running
                GridManager.IsFountainRunning = true;
            if (GridManager.IsFountainRunning) { 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The Fountain of Objects is enabled!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
                Console.WriteLine("Nothing happens.");
        }
    }
    class Exit : ICommand
    {
        public void Run(Player player)
        {
            if (player.CurrentRoom().Type == RoomType.Entarance) 
            {
                if (GridManager.IsFountainRunning) { 
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("You won! The Fountain of Objects is enables and you saved your life!");
                }
                else { 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You escaped, but The Fountain of Objects is not active...");
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Environment.Exit(0);
            }
        }
    }
    class GameOverCheck : ICommand
    {
        public void Run(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            switch (player.CurrentRoom().Type)
            {
                case RoomType.Pit:
                    Console.WriteLine("You fell into the pit! GAMEOVER");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Environment.Exit(0);
                    break;
                case RoomType.Amaroks:
                    Console.WriteLine("You were eaten by Amarok! GAMEOVER");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Environment.Exit(0);
                    break;
                case RoomType.Maelstrom:
                    player.ChangeMaelstromPosition();

                    ICommand north = new NorthCommand();
                    ICommand east = new EastCommand();
                    north.Run(player);
                    east.Run(player);
                    east.Run(player); // two cells east and one north if hit maelstrom

                    Console.WriteLine("You stumbled into the maelstrom. Your new position is " + player.CurrentRoom());

                    Run(player); // recursive check if the new cell is pit or maelstrom
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
