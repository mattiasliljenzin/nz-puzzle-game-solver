using System;

namespace nz_puzzle_game_solver
{
    public abstract class GameTile
    {
        public abstract string Name { get; }
        public abstract char Icon { get; }
        public abstract ConsoleColor Color { get; } 

        public bool IsInitialTile { get; set; }
        public bool EqualsType(GameTile tile) {
            return string.Equals(this.Name, tile.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    public class KiwiTile : GameTile
    {
        public override string Name => "Kiwi";
        public override char Icon => 'K';
        public override ConsoleColor Color => ConsoleColor.Red;
    }

    public class MapTile : GameTile
    {
        public override string Name => "Map";
        public override char Icon => 'M';
        public override ConsoleColor Color => ConsoleColor.Blue;
    }

    public class SheepTile : GameTile
    {
        public override string Name => "Sheep";
        public override char Icon => 'S';
        public override ConsoleColor Color => ConsoleColor.White;
    }

    public class CityTile : GameTile
    {
        public override string Name => "City";
        public override char Icon => 'C';
        public override ConsoleColor Color => ConsoleColor.Black;
    }

    public class FernTile : GameTile
    {
        public override string Name => "Fern";
        public override char Icon => 'F';
        public override ConsoleColor Color => ConsoleColor.Green;
    }
}
