using System.Collections.Generic;
using System.Linq;

namespace nz_puzzle_game_solver
{
    public class GameBag
    {
        public GameBag() {
            //  Tiles.AddRange(Generate<SheepTile>(3));
            //  Tiles.AddRange(Generate<MapTile>(3));
            //  Tiles.AddRange(Generate<KiwiTile>(3));
            //  Tiles.AddRange(Generate<FernTile>(3));
            //  Tiles.AddRange(Generate<CityTile>(4));
            Tiles.Add(new CityTile());
            Tiles.Add(new MapTile());
            Tiles.Add(new SheepTile());
            Tiles.Add(new SheepTile());
            Tiles.Add(new KiwiTile());
            Tiles.Add(new KiwiTile());
            Tiles.Add(new KiwiTile());
            
            Tiles.Add(new FernTile());
            Tiles.Add(new FernTile());
            Tiles.Add(new FernTile());

            Tiles.Add(new CityTile());
            Tiles.Add(new CityTile());
            Tiles.Add(new CityTile());
            
            Tiles.Add(new MapTile());
            Tiles.Add(new MapTile());
            Tiles.Add(new SheepTile());
        }

        public IEnumerable<GameTile> GetTiles() 
        {
            return Tiles;
        }

        public bool Remove(GameTile tile) 
        {
            return Tiles.Remove(tile);
        }

        private List<GameTile> Tiles { get; } = new List<GameTile>(16);

        private IEnumerable<T> Generate<T>(int count) where T : GameTile, new() {
            return Enumerable.Range(0, count).Select(x => new T());
        }

        
    }
}