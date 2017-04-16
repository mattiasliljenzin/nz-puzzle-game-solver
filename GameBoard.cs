using System;

namespace nz_puzzle_game_solver
{
    public class GameBoard {
        private const byte Rows = 4;
        private const byte Columns = 4;
        private readonly GameTile[,] Board = new GameTile[Rows, Columns];
        public void Initialize() 
        {
            Board[0, 0] = new SheepTile();
            Board[0, 1] = new KiwiTile();
            Board[0, 2] = new SheepTile();
            Board[0, 3] = new MapTile();

            Board[1, 0] = new CityTile();
            Board[1, 1] = new MapTile();
            Board[1, 2] = new CityTile();
            Board[1, 3] = new FernTile();

            Board[2, 0] = new KiwiTile();
            Board[2, 1] = new FernTile();
            Board[2, 2] = new KiwiTile();
            Board[2, 3] = new MapTile();

            Board[3, 0] = new MapTile();
            Board[3, 1] = new SheepTile();
            Board[3, 2] = new CityTile();
            Board[3, 3] = new FernTile();
        }

        public void Print() 
        {
            for (int i = 0; i < Rows; i++)
            {
                Console.WriteLine();
                Console.WriteLine("+----------------------+");
                Console.Write("| ");

                for (int j = 0; j < Columns; j++)
                {
                    var tile = Board[i, j];
                                
                    Console.ForegroundColor = tile.Color;
                    Console.Write("  {0}  ", tile.Icon);
                    Console.ResetColor();    
                }

                Console.Write(" |");
            }

            Console.WriteLine();
            Console.WriteLine("+----------------------+");
            Console.WriteLine();
        }
    }
}
