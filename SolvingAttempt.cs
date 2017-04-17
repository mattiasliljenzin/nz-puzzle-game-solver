using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private StringBuilder _tileHistoryTrail = new StringBuilder(); 
        public void Add(GameTileMove move) 
        {
            _gameMoveHistory.Add(move);
            _tileHistoryTrail.Append(CreateTileHistoryTrail(move));
            TileHistoryTrail = _tileHistoryTrail.ToString();
        }

        private string CreateTileHistoryTrail(GameTileMove move) {
            return string.Format("-> {0} ({1},{2})", move.Tile.Icon, move.Location.X, move.Location.Y);
        }

        private bool HasBeenPlayed(GameTileMove move) 
        {
            return _gameMoveHistory.Any(x => x.Tile.EqualsType(move.Tile) && x.Location.Equals(move.Location));
        }

        public string TileHistoryTrail {get; private set;}
        public string ToTileHistoryTrail(GameTileMove appendMove) => TileHistoryTrail + CreateTileHistoryTrail(appendMove);

        public long Count => _gameMoveHistory.Count;

        public int Id { get; private set; }
    }
}