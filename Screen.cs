using System;
using ChessConsole.Board;

namespace ChessConsole
{
    public class Screen
    {
        public static void ShowBoard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.Lines; i++)
            {
                for (int j = 0; j < chessboard.Columns; j++)
                {
                    if (chessboard.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(chessboard.Piece(i, j) + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}