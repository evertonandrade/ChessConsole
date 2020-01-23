using System.Collections.Generic;
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
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;
        
        public ChessMatch()
        {
            Chessboard = new Chessboard(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            InsertPiecesInMatch();
        }

        public void MakeMovement(Position source, Position target)
        {
            Piece piece = Chessboard.RemovePiece(source);
            piece.IncrementAmountMoves();
            Piece CapturedPiece = Chessboard.RemovePiece(target);
            Chessboard.InsertPiece(piece, target);
            if (CapturedPiece != null)
            {
                _capturedPieces.Add(CapturedPiece);
            }
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

        public HashSet<Piece> PiecesCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece xPiece in _capturedPieces)
            {
                if (xPiece.Color == color)
                {
                    aux.Add(xPiece);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInTheGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece xPiece in _pieces)
            {
                if (xPiece.Color == color)
                {
                    aux.Add(xPiece);
                }
            }
            aux.ExceptWith(PiecesCaptured(color));
            return aux;
        }

        public void InsertNewPiece(char column, int line, Piece piece)
        {
            Chessboard.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            _pieces.Add(piece);
        }

        public void InsertPiecesInMatch()
        {
            InsertNewPiece('a', 8, new Rook(Chessboard, Color.Black));
            InsertNewPiece('a', 1, new Rook(Chessboard, Color.White));
            InsertNewPiece('h', 1, new Rook(Chessboard, Color.White));
            InsertNewPiece('h', 8, new Rook(Chessboard, Color.Black));
            InsertNewPiece('e', 1, new King(Chessboard, Color.White));
            InsertNewPiece('e', 8, new King(Chessboard, Color.Black));
        }
    }
}