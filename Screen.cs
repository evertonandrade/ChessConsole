using System;
using System.Collections.Generic;
using ChessConsole.Board;
using ChessConsole.Game;

namespace ChessConsole
{
    public class Screen
    {

        public static void ShowMatch(ChessMatch match)
        {
            ShowBoard(match.Chessboard);
            Console.WriteLine();
            ShowCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn);
            Console.WriteLine("Aguardando jogada da " + match.CurrentPlayer);
        }

        public static void ShowCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ShowSetOfThePieces(match.PiecesCaptured(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ShowSetOfThePieces(match.PiecesCaptured(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ShowSetOfThePieces(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece xPiece in set)
            {
                Console.Write(xPiece + " ");
            }
            Console.Write("]");
        }
        
        public static void ShowBoard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    ShowPiece(chessboard.Piece(i, j));
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        
        public static void ShowBoard(Chessboard chessboard, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor ChangedBackground = ConsoleColor.DarkGray;
            
            for (int i = 0; i < chessboard.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = ChangedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    ShowPiece(chessboard.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void ShowPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else if (piece.Color == Color.Black)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}