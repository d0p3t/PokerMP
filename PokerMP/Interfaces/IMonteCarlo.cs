using System.Collections.Generic;
using PokerMP.Models;

namespace PokerMP.Interfaces
{
    internal interface IMonteCarlo
    {
        float CalculateWinningChance(Card firstCard, Card secondCard, IReadOnlyCollection<Card> communityCards);
    }
}
