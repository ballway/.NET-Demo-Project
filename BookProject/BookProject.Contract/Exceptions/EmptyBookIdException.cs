using System;

namespace BookProject.Contract.Exceptions
{
    public class EmptyBookIdException : Exception
    {
        public EmptyBookIdException()
        {
        }
        public EmptyBookIdException(string message) : base(message)
        {
        }
        public EmptyBookIdException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
