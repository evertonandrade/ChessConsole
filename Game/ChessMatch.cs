using ChessConsole.Board;

namespace ChessConsole.Game
{
    public class ChessMatch
    {
        public Chessboard Chessboard { get; private set; }
        private int _turn;
        private Color _currentPlayer;
        public bool Finished { get; private set; }
        
        public ChessMatch()
        {
            Chessboard = new Chessboard(8,8);
            _turn = 1;
            _currentPlayer = Color.White;
            InsertPiecesInMatch();
            Finished = false;
        }

        public void MakeMovement(Position source, Position target)
        {
            Piece piece = Chessboard.RemovePiece(source);
            piece.IncrementAmountMoves();
            Piece CapturedPiece = Chessboard.RemovePiece(target);
            Chessboard.InsertPiece(piece, target);
        }

        public void InsertPiecesInMatch()
        {
            Chessboard.InsertPiece(new Rook(Chessboard, Color.Black), new ChessPosition('c', 1).ToPosition());
        }
    }
}