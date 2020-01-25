using ChessConsole.Board;

namespace ChessConsole.Game.ChessPieces
{
    public class Knight : Piece
    {
        public Knight()
        {
        }

        public Knight(Chessboard chessboard, Color color) : base(chessboard, color)
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
            
            position.SetValues(Position.Line - 1, Position.Column - 2);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line - 2, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line - 2, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line - 1, Position.Column + 2);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line + 1, Position.Column + 2);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line + 2, Position.Column + 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line + 2, Position.Column - 1);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            
            position.SetValues(Position.Line + 1, Position.Column - 2);
            if (Chessboard.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            return matrix;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}