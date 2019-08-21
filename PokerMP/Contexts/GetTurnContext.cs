using System.Collections.Generic;
using PokerMP.Enums;
using PokerMP.Interfaces;
using PokerMP.Models;

namespace PokerMP.Contexts
{
    public class GetTurnContext : IGetTurnContext
    {
        public GetTurnContext(
            GameRoundType roundType,
            IReadOnlyCollection<PlayerActionAndName> previousRoundActions,
            int smallBlind,
            int moneyLeft,
            int currentPot,
            int myMoneyInTheRound,
            int currentMaxBet,
            int minRaise,
            Pot mainPot,
            List<Pot> sidePots)
        {
            RoundType = roundType;
            PreviousRoundActions = previousRoundActions;
            SmallBlind = smallBlind;
            MoneyLeft = moneyLeft;
            CurrentPot = currentPot;
            MyMoneyInTheRound = myMoneyInTheRound;
            CurrentMaxBet = currentMaxBet;
            MinRaise = minRaise;
            MainPot = mainPot;
            SidePots = sidePots;
        }

        public GameRoundType RoundType { get; }

        public IReadOnlyCollection<PlayerActionAndName> PreviousRoundActions { get; }

        public int SmallBlind { get; }

        public int MoneyLeft { get; }

        public int CurrentPot { get; }

        public int MyMoneyInTheRound { get; }

        public int CurrentMaxBet { get; }

        public bool CanCheck => this.MyMoneyInTheRound == this.CurrentMaxBet;

        public bool CanRaise => this.MinRaise > 0 && this.MoneyLeft > this.MoneyToCall;

        public int MoneyToCall
        {
            get
            {
                var temp = this.CurrentMaxBet - this.MyMoneyInTheRound;
                if (temp >= this.MoneyLeft)
                {
                    // The player does not have enough money to make a full call
                    return this.MoneyLeft;
                }
                else
                {
                    return temp;
                }
            }
        }

        public bool IsAllIn => this.MoneyLeft <= 0;

        public int MinRaise { get; }

        public Pot MainPot { get; }

        public IReadOnlyCollection<Pot> SidePots { get; }
    }
}
