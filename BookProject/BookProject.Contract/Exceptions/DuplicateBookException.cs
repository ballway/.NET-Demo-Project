using System;

namespace BookProject.Contract.Exceptions
{
    public class DuplicateBookException : Exception
    {
        public DuplicateBookException()
        {
        }
        public DuplicateBookException(string message) : base(message)
        {
        }
        public DuplicateBookException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
