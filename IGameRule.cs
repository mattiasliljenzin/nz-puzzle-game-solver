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
            return existingTile == null ? false : !tile.EqualsType(existingTile); 
        }
    }

    public class SurroundingTileOfSameTypeNotAllowedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, Point p)
        {
            Func<int, int, bool> moveIsAllowed = (x1,y1) => {
                var existingTile = board.GetGameTile(new Point(x1, y1));
                return existingTile == null ? false : !tile.EqualsType(existingTile); 
            };

            var x = p.X;
            var y = p.Y;

            if (moveIsAllowed(x - 1, y - 1)) return true;
            if (moveIsAllowed(x, y - 1)) return true;
            if (moveIsAllowed(x + 1, y - 1)) return true;

            if (moveIsAllowed(--x, y)) return true;
            if (moveIsAllowed(++x, y)) return true;

            if (moveIsAllowed(x - 1, y + 1)) return true;
            if (moveIsAllowed(x, y + 1)) return true;
            if (moveIsAllowed(x + 1, y + 1)) return true;

            return false;
        }
    }

}
