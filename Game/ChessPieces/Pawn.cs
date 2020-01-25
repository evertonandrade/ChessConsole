using ChessConsole.Board;

namespace ChessConsole.Game.ChessPieces
{
    public class Pawn : Piece
    {
        public Pawn()
        {
        }

        public Pawn(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }
        
        public bool CanMove(Position position)
        {
            Piece piece = Chessboard.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public bool ThereIsEnemy(Position position)
        {
            Piece piece = Chessboard.Piece(position);
            return (piece != null) && (piece.Color != Color);
        }

        private bool FreePosition(Position position)
        {
            return Chessboard.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Lines, Chessboard.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Line - 1, Position.Column);
                if (Chessboard.ValidPosition(position) && FreePosition(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line - 2, Position.Column);
                if (Chessboard.ValidPosition(position) && FreePosition(position) && AmountMoves == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line - 1, Position.Column - 1);
                if (Chessboard.ValidPosition(position) && ThereIsEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line - 1, Position.Column + 1);
                if (Chessboard.ValidPosition(position) && ThereIsEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Line + 1, Position.Column);
                if (Chessboard.ValidPosition(position) && FreePosition(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line + 2, Position.Column);
                if (Chessboard.ValidPosition(position) && FreePosition(position) && AmountMoves == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line + 1, Position.Column - 1);
                if (Chessboard.ValidPosition(position) && ThereIsEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line + 1, Position.Column + 1);
                if (Chessboard.ValidPosition(position) && ThereIsEnemy(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }
            
            
            return matrix;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}