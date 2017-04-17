using System;

namespace nz_puzzle_game_solver
{
    public interface IGameRule {
        bool IsValid(GameTile tile, GameBoard board, Point p);
    }

    public class TargetTileOfSameTypeNotAllowedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, Point p)
        {
            var existingTile = board.GetGameTile(p);
            //Console.WriteLine("Moving {0} to {1} ({2},{3}) - {4} (single)", tile.Name, existingTile?.Name, p.X, p.Y, !tile.EqualsType(existingTile));
            
            return existingTile == null ? false : !tile.EqualsType(existingTile); 
        }
    }

    public class TargetTileHasAlreadyBeenPlacedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, Point p)
        {
            var existingTile = board.GetGameTile(p);
            return existingTile == null ? false : existingTile.IsInitialTile;
        }
    }

    public class SurroundingTileOfSameTypeNotAllowedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, Point p)
        {
            Func<int, int, bool> moveIsAllowed = (x1,y1) => {
                var existingTile = board.GetGameTile(new Point(x1, y1));
                if(existingTile == null) return true;
                var m = !tile.EqualsType(existingTile); 
                //Console.WriteLine("Moving {0} to {1} ({2},{3}) - {4} (multi)", tile.Name, existingTile?.Name, x1, y1, !tile.EqualsType(existingTile));
                return m;
            };

            var x = p.X;
            var y = p.Y;

            if (!moveIsAllowed(x - 1, y - 1)) return false;
            if (!moveIsAllowed(x, y - 1)) return false;
            if (!moveIsAllowed(x + 1, y - 1)) return false;

            if (!moveIsAllowed(x - 1, y)) return false;
            if (!moveIsAllowed(x + 1, y)) return false;

            if (!moveIsAllowed(x - 1, y + 1)) return false;
            if (!moveIsAllowed(x, y + 1)) return false;
            if (!moveIsAllowed(x + 1, y + 1)) return false;

            return true;
        }
    }

}
