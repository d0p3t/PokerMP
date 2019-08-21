using System.Collections.Generic;
using PokerMP.Enums;
using PokerMP.Interfaces;
using PokerMP.Models;

namespace PokerMP.Contexts
{
    public class StartRoundContext : IStartRoundContext
    {
        public StartRoundContext(
            GameRoundType roundType,
            IReadOnlyCollection<Card> communityCards,
            int moneyLeft,
            int currentPot,
            Pot currentMainPot,
            List<Pot> currentSidePots)
        {
            RoundType = roundType;
            CommunityCards = communityCards;
            MoneyLeft = moneyLeft;
            CurrentPot = currentPot;
            CurrentMainPot = currentMainPot;
            CurrentSidePots = currentSidePots;
        }

        public GameRoundType RoundType { get; }

        public IReadOnlyCollection<Card> CommunityCards { get; }

        public int MoneyLeft { get; }

        public int CurrentPot { get; }

        public Pot CurrentMainPot { get; }

        public IReadOnlyCollection<Pot> CurrentSidePots { get; }
    }
}
