using System.Collections.Generic;
using System.Linq;

namespace nz_puzzle_game_solver
{
    public class SolvingAttempt 
    {
        private static int _attemptCounter;

        public SolvingAttempt() 
        {
            Id = ++_attemptCounter;
        }

        private readonly List<GameTileMove> _gameMoveHistory = new List<GameTileMove>();
        public void Add(GameTileMove move) 
        {
            _gameMoveHistory.Add(move);
        }

        public bool HasBeenPlayed(GameTileMove move) 
        {
            return _gameMoveHistory.Any(x => x.Tile.EqualsType(move.Tile) && x.Location.Equals(move.Location));
        }
        public long Count => _gameMoveHistory.Count;

        public int Id { get; private set; }
    }
}