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
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Chessboard = new Chessboard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            InsertPiecesInMatch();
        }

        public Piece MakeMovement(Position source, Position target)
        {
            Piece piece = Chessboard.RemovePiece(source);
            piece.IncrementAmountMoves();
            Piece capturedPiece = Chessboard.RemovePiece(target);
            Chessboard.InsertPiece(piece, target);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMovement(Position source, Position target, Piece capturedPiece)
        {
            Piece piece = Chessboard.RemovePiece(target);
            piece.DecrementAmountMoves();
            if (capturedPiece != null)
            {
                Chessboard.InsertPiece(capturedPiece, target);
                _capturedPieces.Remove(capturedPiece);
            }
            Chessboard.InsertPiece(piece, source);
        }

        public void PerformPlay(Position source, Position target)
        {
            Piece capturedPiece = MakeMovement(source, target);

            if (ItsInCheck(CurrentPlayer))
            {
                UndoMovement(source, target, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (ItsInCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            
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

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece xPiece in PiecesInTheGame(color))
            {
                if (xPiece is King)
                {
                    return xPiece;
                }
            }

            return null;
        }

        public bool ItsInCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardException("Não tem rei da cor " + color + " no tabuleiro");
            }

            foreach (Piece xPiece in PiecesInTheGame(Adversary(color)))
            {
                bool[,] matrix = xPiece.PossibleMoves();
                if (matrix[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public void InsertNewPiece(char column, int line, Piece piece)
        {
            Chessboard.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            _pieces.Add(piece);
        }

        public void InsertPiecesInMatch()
        {
            InsertNewPiece('c', 1, new Rook(Chessboard, Color.White));
            InsertNewPiece('c', 2, new Rook(Chessboard, Color.White));
            InsertNewPiece('d', 2, new Rook(Chessboard, Color.White));
            InsertNewPiece('e', 2, new Rook(Chessboard, Color.White));
            InsertNewPiece('d', 1, new King(Chessboard, Color.White));
            InsertNewPiece('e', 1, new Rook(Chessboard, Color.White));

            InsertNewPiece('c', 8, new Rook(Chessboard, Color.Black));
            InsertNewPiece('c', 7, new Rook(Chessboard, Color.Black));
            InsertNewPiece('d', 7, new Rook(Chessboard, Color.Black));
            InsertNewPiece('e', 7, new Rook(Chessboard, Color.Black));
            InsertNewPiece('d', 8, new King(Chessboard, Color.Black));
            InsertNewPiece('e', 8, new Rook(Chessboard, Color.Black));
        }
    }
}