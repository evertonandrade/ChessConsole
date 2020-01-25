using System;

namespace ChessConsole.Board.Exceptions
{
    public class PositionException : Exception
    {
        public PositionException(string message) : base(message)
        {
            
        }
    }
}