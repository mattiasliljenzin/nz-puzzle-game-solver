using System.Collections.Generic;
using System.Linq;

namespace nz_puzzle_game_solver
{
    public class GameBag
    {
        public GameBag() {
            Tiles.AddRange(Generate<SheepTile>(3));
            Tiles.AddRange(Generate<MapTile>(3));
            Tiles.AddRange(Generate<KiwiTile>(3));
            Tiles.AddRange(Generate<FernTile>(3));
            Tiles.AddRange(Generate<CityTile>(4));
        }

        public IEnumerable<GameTile> GetTiles() 
        {
            return Tiles;
        }

        public bool Remove(GameTile tile) 
        {
            return Tiles.Remove(tile);
        }

        private List<GameTile> Tiles => new List<GameTile>(16);

        private IEnumerable<T> Generate<T>(int count) where T : GameTile, new() {
            return Enumerable.Range(0, count).Select(x => new T());
        }

        
    }
}