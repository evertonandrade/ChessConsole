using ChessConsole.Board;

namespace ChessConsole.Game.ChessPieces
{
    public class King : Piece
    {
        public King()
        {
        }

        public King(Chessboard chessboard, Color color) : base(chessboard, color)
        {
            
        }

        public bool CanMove(Position position)
        {
            Piece piece = Chessboard.Piece(position);
            return piece == null || piece.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Lines,Chessboard.Columns];
            
            Position position = new Position(0,0);
            //above
            position.SetValues(Position.Line - 1, Position.Column);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //ne
            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            // rigth
            position.SetValues(Position.Line , Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            // se
            position.SetValues(Position.Line  + 1, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            // below
            position.SetValues(Position.Line  + 1, Position.Column );
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            // so
            position.SetValues(Position.Line  + 1, Position.Column - 1 );
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            // left
            position.SetValues(Position.Line, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            // no
            position.SetValues(Position.Line  - 1, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            return matrix;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}