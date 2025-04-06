namespace ChessLogic
{
    public enum Player
    {
        None,
        White,
        Black
    }
    public static class PLayerExtensions
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                ChessLogic.Player.Black => ChessLogic.Player.White,
                _ => Player.None,
            };
        }
    }
}
