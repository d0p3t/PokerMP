using System.Collections.Generic;
using PokerMP.Enums;
using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IStartRoundContext
    {
        IReadOnlyCollection<Card> CommunityCards { get; }
        int CurrentPot { get; }
        int MoneyLeft { get; }
        GameRoundType RoundType { get; }
        Pot CurrentMainPot { get; }
        IReadOnlyCollection<Pot> CurrentSidePots { get; }
    }
}
