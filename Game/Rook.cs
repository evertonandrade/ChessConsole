using ChessConsole.Board;

namespace ChessConsole.Game
{
    public class Rook : Piece
    {
        public Rook()
        {
        }

        public Rook(Chessboard chessboard, Color color) : base(chessboard, color)
        {
            
        }

        public override string ToString()
        {
            return "T";
        }
    }
}