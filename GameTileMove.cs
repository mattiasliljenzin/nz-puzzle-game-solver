namespace nz_puzzle_game_solver
{
    public class GameTileMove
    {
        public GameTile Tile {get; set;}
        public Point Location {get;set;}
        
        public GameTileMove(GameTile tile, Point location)
        {
            Tile = tile;
            Location = location;
        }
    }
}