using System;
using ChessConsole.Board;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);
            Chessboard b = new Chessboard(8,8);
            Console.WriteLine(p);
            Console.WriteLine(b);
        }
    }
}
