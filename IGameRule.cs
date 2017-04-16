using System;

namespace nz_puzzle_game_solver
{
    public interface IGameRule {
        bool IsValid(GameTile tile, GameBoard board, GameMove target);
    }

    public class TargetTileOfSameTypeNotAllowedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, GameMove target)
        {
            return tile.EqualsType(board.GetGameTile(target.X, target.Y));
        }
    }

    public class SurroundingTileOfSameTypeNotAllowedRule : IGameRule
    {
        public bool IsValid(GameTile tile, GameBoard board, GameMove target)
        {
            var x = target.X;
            var y = target.Y;

            Func<int, int, bool> match = (x1,y1) => tile.EqualsType(board.GetGameTile(x1, y1));

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
