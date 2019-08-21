using System;

namespace PokerMP
{
    public class InternalPokerGameException : Exception
    {
        public InternalPokerGameException(string message) : base(message) { }
    }
}
