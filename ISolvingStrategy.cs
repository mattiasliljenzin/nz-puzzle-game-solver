using System;
using System.Collections.Generic;
using System.Linq;

namespace nz_puzzle_game_solver
{
    public interface ISolvingStrategy
    {
        bool Solve(GameBoard board, GameBag bag, IList<IGameRule> rules);
    }

    public class BruteForceStrategy : ISolvingStrategy
    {
        public bool Solve(GameBoard board, GameBag bag, IList<IGameRule> rules)
        {
            var attemptLimit = 5;
            var attempts = new List<SolvingAttempt>();
            
            Console.WriteLine("Trying to solve with BruteForceStrategy!");
            Console.WriteLine("Number of attempts set to " + attemptLimit);

            for (int i = 0; i < attemptLimit; i++)
            {
                board.Initialize();
                
                var attempt = new SolvingAttempt();
                attempts.Add(attempt);

                Console.WriteLine("Attempt {0}: Starting...", attempt.Id);

                foreach (var tile in bag.GetTiles())
                {
                    //Console.WriteLine("Processing tile..");
                    foreach (var point in board.GetGameTileLocations())
                    {
                        var move = new GameTileMove(tile, point);
                        
                        if (attempts.Any(x => x.HasBeenPlayed(move))) {
                            Console.WriteLine("Attempt {0}: FAILED (already played) - Moving {1} to ({2},{3})", attempt.Id, move.Tile.Name, move.Location.X, move.Location.Y);
                            continue;                            
                        }

                        //Console.WriteLine();
                        var existingTile = board.GetGameTile(point);
                        //Console.WriteLine("Attempt {0}: Trying to move {1} to {2} ({3},{4})", attempt.Id, move.Tile.Name, existingTile.Name, move.Location.X, move.Location.Y);
                            
                        if (rules.All(x => x.IsValid(tile, board, point)))
                        {   
                            //Console.WriteLine("Attempt {0}: Success - Moving {1} to {2} ({3},{4})", attempt.Id, move.Tile.Name, existingTile.Name, move.Location.X, move.Location.Y);
                            
                            board.PlaceMove(move);
                            attempt.Add(move);

                            if (board.IsGameCompleted)
                            {
                                PrintGameCompletedMessage(board);
                                return true;
                            }
                            continue;
                        }
                        else {
                            //Console.WriteLine("Attempt {0}: FAILED (invalid rule(s)) - Moving {1} to ({2},{3})", attempt.Id, move.Tile.Name, move.Location.X, move.Location.Y);
                        }
                    }
                }
                Console.WriteLine("Attempt {0}: Failed. Number of tiles placed: {1}", attempt.Id, board.PlacedTilesCount);
                Console.WriteLine();
            }

            return false;
        }

        private static void PrintGameCompletedMessage(GameBoard board)
        {
            Console.WriteLine("Game completed!");
            Console.WriteLine("===============");
            board.Print();
            Console.WriteLine();
        }
    }
}