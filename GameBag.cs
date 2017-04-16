using System.Collections.Generic;
using System.Linq;

namespace nz_puzzle_game_solver
{
    internal class GameBag
    {
        public GameBag() {
            Tiles.AddRange(Generate<SheepTile>(3));
            Tiles.AddRange(Generate<MapTile>(3));
            Tiles.AddRange(Generate<KiwiTile>(3));
            Tiles.AddRange(Generate<FernTile>(3));
            Tiles.AddRange(Generate<CityTile>(4));
        }

        public List<GameTile> Tiles => new List<GameTile>(16);

        private IEnumerable<T> Generate<T>(int count) where T : GameTile, new() {
            return Enumerable.Range(0, count).Select(x => new T());
        }

        
    }
}