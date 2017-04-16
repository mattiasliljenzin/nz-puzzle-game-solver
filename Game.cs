using System.Collections.Generic;

namespace nz_puzzle_game_solver
{
    public class Game 
    {
        private readonly GameBoard _board = new GameBoard();
        private readonly GameBag _bag = new GameBag();
        private readonly List<IGameRule> _rules = new List<IGameRule> 
        {
            new TargetTileOfSameTypeNotAllowedRule(),
            new SurroundingTileOfSameTypeNotAllowedRule()
        };

        public void Run() 
        {
            _board.Initialize();
            _board.Print();

            var strategy = new BruteForceStrategy();
            strategy.Solve(_board, _bag, _rules);
        }

    }

   

}
