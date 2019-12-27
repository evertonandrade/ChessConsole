using System;

namespace ChessConsole.Board.Exceptions
{
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
            
        }
    }
}