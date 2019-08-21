using PokerMP.Interfaces;
using PokerMP.Models;

namespace PokerMP.Contexts
{
    public class StartHandContext : IStartHandContext
    {
        public StartHandContext(Card firstCard, Card secondCard, int handNumber, int moneyLeft, int smallBlind, string firstPlayerName)
        {
            FirstCard = firstCard;
            SecondCard = secondCard;
            HandNumber = handNumber;
            MoneyLeft = moneyLeft;
            SmallBlind = smallBlind;
            FirstPlayerName = firstPlayerName;
        }

        public Card FirstCard { get; }

        public Card SecondCard { get; }

        public int HandNumber { get; }

        public int MoneyLeft { get; }

        public int SmallBlind { get; }

        public string FirstPlayerName { get; }
    }
}
