using System;
using ChessConsole.Board;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard b = new Chessboard(8,8);
            Screen.ShowBoard(b);
        }
    }
}
