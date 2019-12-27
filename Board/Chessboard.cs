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
    }
}