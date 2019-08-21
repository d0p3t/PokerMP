using System.Collections.Generic;
using PokerMP.Helpers;
using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IHandEvaluator
    {
        BestHand GetBestHand(IEnumerable<Card> cards);
    }
}
