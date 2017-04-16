using System;

namespace nz_puzzle_game_solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello New Zealand World!");
            Console.WriteLine();

            var game = new Game();
            game.Run();

            Console.WriteLine();
            Console.WriteLine("Ending program...");
            Console.ReadLine();
        }
    }
}
