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
            return tile.EqualsType(board.GetGameTile(p));
        }
    }

    public class SurroundingTileOfSameTypeNotAllowedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, Point p)
        {
            Func<int, int, bool> match = (x1,y1) => tile.EqualsType(board.GetGameTile(new Point(x1, y1)));

            var x = p.X;
            var y = p.Y;

            if (match(x - 1, y - 1)) return true;
            if (match(x, y - 1)) return true;
            if (match(x + 1, y - 1)) return true;

            if (match(--x, y)) return true;
            if (match(++x, y)) return true;

            if (match(x - 1, y + 1)) return true;
            if (match(x, y + 1)) return true;
            if (match(x + 1, y + 1)) return true;

            return false;
        }
    }

}
