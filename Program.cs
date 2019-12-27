using System;
using ChessConsole.Board;
using ChessConsole.Game;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard tab = new Chessboard(8,8);
            tab.InsertPiece(new King(tab, Color.Black), new Position(0, 0));
            tab.InsertPiece(new Rook(tab, Color.White), new Position(0, 3));
            tab.InsertPiece(new Rook(tab, Color.Black), new Position(0, 6));
            Screen.ShowBoard(tab);
        }
    }
}
