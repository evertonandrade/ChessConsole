using ChessConsole.Board;

namespace ChessConsole.Game.ChessPieces
{
    public class Bishop : Piece
    {
        public Bishop()
        {
        }

        public Bishop(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }
        
        public bool CanMove(Position position)
        {
            Piece piece = Chessboard.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Lines, Chessboard.Columns];

            Position position = new Position(0, 0);

            // NO
            position.SetValues(Position.Line - 1, Position.Column - 1);
            while (Chessboard.ValidPosition(position) && CanMove(position)) {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.Piece(position) != null && Chessboard.Piece(position).Color != Color) {
                    break;
                }
                position.SetValues(position.Line - 1, position.Column - 1);
            }
            
            //NE
            position.SetValues(Position.Line -1, Position.Column + 1);
            while (Chessboard.ValidPosition(position) && CanMove(position)) {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.Piece(position) != null && Chessboard.Piece(position).Color != Color) {
                    break;
                }
                position.SetValues(position.Line - 1, position.Column + 1);
            }
            
            // SE
            position.SetValues(Position.Line + 1, Position.Column + 1);
            while (Chessboard.ValidPosition(position) && CanMove(position)) {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.Piece(position) != null && Chessboard.Piece(position).Color != Color) {
                    break;
                }
                position.SetValues(position.Line + 1, position.Column + 1);
            }
            
            // SO
            position.SetValues(Position.Line + 1, Position.Column - 1);
            while (Chessboard.ValidPosition(position) && CanMove(position)) {
                matrix[position.Line, position.Column] = true;
                if (Chessboard.Piece(position) != null && Chessboard.Piece(position).Color != Color) {
                    break;
                }
                position.SetValues(position.Line + 1, position.Column - 1);
            }

            return matrix;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}