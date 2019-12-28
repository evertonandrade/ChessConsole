using ChessConsole.Board.Exceptions;

namespace ChessConsole.Board
{
    public class Chessboard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] _pieces;

        public Chessboard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _pieces = new Piece[Lines,Columns];
        }

        public Piece Piece(int line, int column)
        {
            return _pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return _pieces[position.Line, position.Column];
        }

        public bool ThereIsPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void InsertPiece(Piece piece, Position position)
        {
            if (ThereIsPiece(position))
            {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            _pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece aux = Piece(position);
            aux.Position = null;
            _pieces[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Posição Inválida!");
            }
        }
    }
}