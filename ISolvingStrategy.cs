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
            var attemptLimit = 10000;
            var attempts = new List<SolvingAttempt>();
            
            for (int i = 0; i < attemptLimit; i++)
            {
                var attempt = new SolvingAttempt();
                attempts.Add(attempt);

                Console.WriteLine("Attempt {0}: Starting...", attempt.Id);

                foreach (var tile in bag.GetTiles())
                {
                    foreach (var point in board.GetGameTileLocations())
                    {
                        var move = new GameTileMove(tile, point);
                        
                        if (attempts.Any(x => x.HasBeenPlayed(move))) continue;

                        if (rules.All(x => x.IsValid(tile, board, point)))
                        {   
                            Console.WriteLine("Attempt {0}: Moving {1} to ({2},{3})", attempt.Id, move.Tile.Name, move.Location.X, move.Location.Y);
                            
                            board.PlaceMove(move);
                            attempt.Add(move);
                            bag.Remove(tile);
                        }
                    }
                }

                if (board.GameIsCompleted)
                {
                    PrintGameCompletedMessage(board);
                    return true;
                }
                else 
                {
                    Console.WriteLine("Attempt {0}: Failed", attempt.Id);
                }
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