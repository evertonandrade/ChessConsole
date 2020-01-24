namespace ChessConsole.Board
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMoves { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece()
        {
        }

        public Piece(Chessboard chessboard, Color color)
        {
            Position = null;
            Color = color;
            Chessboard = chessboard;
            AmountMoves = 0;
        }

        public void IncrementAmountMoves()
        {
            AmountMoves++;
        }
        
        public void DecrementAmountMoves()
        {
            AmountMoves--;
        }

        public bool ThereArePossibleMovements()
        {
            bool[,] matrix = PossibleMoves();
            for (int i = 0; i < Chessboard.Lines; i++)
            {
                for (int j = 0; j < Chessboard.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoves();
        
        
    }
}