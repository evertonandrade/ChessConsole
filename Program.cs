using System;
using ChessConsole.Board;
using ChessConsole.Board.Exceptions;
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
                    try
                    {
                        Console.Clear();
                        Screen.ShowMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position source = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(source);

                        bool[,] possiblePositions = match.Chessboard.Piece(source).PossibleMoves();
                    
                        Console.Clear();
                        Screen.ShowBoard(match.Chessboard, possiblePositions);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position target  = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinationPosition(source, target);
                    
                        match.PerformPlay(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

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
