using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IStartHandContext
    {
        Card FirstCard { get; }
        string FirstPlayerName { get; }
        int HandNumber { get; }
        int MoneyLeft { get; }
        Card SecondCard { get; }
        int SmallBlind { get; }
    }
}
