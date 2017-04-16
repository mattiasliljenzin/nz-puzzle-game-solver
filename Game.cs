namespace nz_puzzle_game_solver
{
    public class Game 
    {
        private readonly GameBoard Board = new GameBoard();
        public Game() {}
        public void Run() 
        {
            Board.Initialize();
            Board.Print();
        }
    }
}
