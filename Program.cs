using System;
using ChessConsole.Board;
using ChessConsole.Game;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.ShowBoard(match.Chessboard);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position source = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.Chessboard.Piece(source).PossibleMoves();
                    
                    Console.Clear();
                    Screen.ShowBoard(match.Chessboard, possiblePositions);
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position target  = Screen.ReadChessPosition().ToPosition();
                    
                    match.MakeMovement(source, target);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
