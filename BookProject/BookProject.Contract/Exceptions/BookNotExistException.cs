using System;

namespace BookProject.Contract.Exceptions
{
    public class BookNotExistException : Exception
    {
        public BookNotExistException()
        {
        }
        public BookNotExistException(string message) : base(message)
        {
        }
        public BookNotExistException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
