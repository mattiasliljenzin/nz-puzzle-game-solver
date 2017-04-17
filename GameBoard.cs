using System;
using System.Collections.Generic;
using System.Linq;

namespace nz_puzzle_game_solver
{
    public class GameBoard {
        private const byte Rows = 4;
        private const byte Columns = 4;
        private readonly GameTile[,] Board = new GameTile[Columns, Rows];
        public void Initialize() 
        {
            Board[0, 0] = new SheepTile() { IsInitialTile = true };
            Board[1, 0] = new KiwiTile() { IsInitialTile = true };
            Board[2, 0] = new SheepTile() { IsInitialTile = true };
            Board[3, 0] = new MapTile() { IsInitialTile = true };

            Board[0, 1] = new CityTile() { IsInitialTile = true };
            Board[1, 1] = new MapTile() { IsInitialTile = true };
            Board[2, 1] = new CityTile() { IsInitialTile = true };
            Board[3, 1] = new FernTile() { IsInitialTile = true };

            Board[0, 2] = new KiwiTile() { IsInitialTile = true };
            Board[1, 2] = new FernTile() { IsInitialTile = true };
            Board[2, 2] = new KiwiTile() { IsInitialTile = true };
            Board[3, 2] = new MapTile() { IsInitialTile = true };

            Board[0, 3] = new MapTile() { IsInitialTile = true };
            Board[1, 3] = new SheepTile() { IsInitialTile = true };
            Board[2, 3] = new CityTile() { IsInitialTile = true };
            Board[3, 3] = new FernTile() { IsInitialTile = true };
        }

        public void Print(bool placedTilesOnly = false) 
        {
            for (int i = 0; i < Rows; i++)
            {
                Console.WriteLine();
                Console.WriteLine("+----------------------+");
                Console.Write("| ");

                for (int j = 0; j < Columns; j++)
                {
                    var tile = Board[j, i];
                                
                    Console.ForegroundColor = tile.Color;

                    if (placedTilesOnly) {
                        Console.ForegroundColor = tile.IsInitialTile ? ConsoleColor.Black : ConsoleColor.White;
                    }

                    Console.Write("  {0}  ", tile.Icon);
                    Console.ResetColor();    
                }

                Console.Write(" |");
            }

            Console.WriteLine();
            Console.WriteLine("+----------------------+");
            Console.WriteLine();
        }

        private IEnumerable<GameTile> GetGameTiles() 
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    yield return Board[i, j];
                }
            }
        }

        public IEnumerable<Point> GetGameTileLocations() 
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    yield return new Point(i, j);
                }
            }
        }

        public GameTile GetGameTile(Point p) 
        {
            if (p.X < 0 || p.Y < 0) return null;
            if (p.X >= Rows || p.Y >= Columns) return null;
            
            return Board[p.X, p.Y];
        }

        public bool IsGameCompleted => GetGameTiles().All(x => x.IsInitialTile == false);

        public int PlacedTilesCount => GetGameTiles().Where(x => x.IsInitialTile == false).Count();

        public void PlaceMove(GameTileMove move) 
        {
            Board[move.Location.X, move.Location.Y] = move.Tile;

            var currentTileCount = PlacedTilesCount;
            if(currentTileCount > TileRecord) {
                TileRecord = currentTileCount;
            }
        }

        public int TileRecord {get;set;}
    }
}
