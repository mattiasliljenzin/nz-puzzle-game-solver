using System.Collections.Generic;

namespace nz_puzzle_game_solver
{
    public class Game 
    {
        private readonly GameBoard Board = new GameBoard();
        private readonly GameBag Bag = new GameBag();
        private readonly List<IGameRule> Rules = new List<IGameRule>();
        public void Run() 
        {
            Board.Initialize();
            Board.Print();
        }
    }

}
