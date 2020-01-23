using System.Diagnostics;
using ChessConsole.Board;
using ChessConsole.Board.Exceptions;

namespace ChessConsole.Game
{
    public class ChessMatch
    {
        public Chessboard Chessboard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        
        public ChessMatch()
        {
            Chessboard = new Chessboard(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
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

        public void PerformPlay(Position source, Position target)
        {
            MakeMovement(source, target);
            Turn++;
            SwitchPlayer();
        }

        private void SwitchPlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Chessboard.Piece(position) == null)
            {
                throw new BoardException("Não exite peça na posição de origem escolhida");
            }

            if (CurrentPlayer != Chessboard.Piece(position).Color)
            {
                throw new BoardException("A peça de origem escolhida não é sua");
            }

            if (!Chessboard.Piece(position).ThereArePossibleMovements())
            {
                throw new BoardException("Não há movimentos possiveis para essa peça");
            }
        }

        public void ValidateDestinationPosition(Position source, Position target)
        {
            if (!Chessboard.Piece(source).CanMoveTo(target))
            {
                throw new BoardException("Posição de destino inválida");
            }
        }

        public void InsertPiecesInMatch()
        {
            Chessboard.InsertPiece(new Rook(Chessboard, Color.Black), new ChessPosition('a', 8).ToPosition());
            Chessboard.InsertPiece(new Rook(Chessboard, Color.White), new ChessPosition('a', 1).ToPosition());
            Chessboard.InsertPiece(new Rook(Chessboard, Color.White), new ChessPosition('h', 1).ToPosition());
            Chessboard.InsertPiece(new Rook(Chessboard, Color.Black), new ChessPosition('h', 8).ToPosition());
            Chessboard.InsertPiece(new King(Chessboard, Color.White), new ChessPosition('e', 1).ToPosition());
            Chessboard.InsertPiece(new King(Chessboard, Color.Black), new ChessPosition('e', 8).ToPosition());
            


        }
    }
}