namespace ChessConsole.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMoves { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece()
        {
        }

        public Piece(Position position, Color color, Chessboard chessboard)
        {
            Position = position;
            Color = color;
            Chessboard = chessboard;
            AmountMoves = 0;
        }
    }
}