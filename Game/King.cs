using ChessConsole.Board;

namespace ChessConsole.Game
{
    public class King : Piece
    {
        public King()
        {
        }

        public King(Chessboard chessboard, Color color) : base(chessboard, color)
        {
            
        }

        public override string ToString()
        {
            return "R";
        }
    }
}