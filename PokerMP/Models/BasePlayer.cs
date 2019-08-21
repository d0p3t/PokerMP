﻿using System.Collections.Generic;
using PokerMP.Interfaces;

namespace PokerMP.Models
{
    public abstract class BasePlayer : IPlayer
    {
        public abstract string Name { get; }
        public abstract int BuyIn { get; }

        protected IReadOnlyCollection<Card> CommunityCards { get; private set; }

        protected Card FirstCard { get; private set; }
        protected Card SecondCard { get; private set; }

        public virtual void StartGame(IStartGameContext context) { }

        public virtual void StartHand(IStartHandContext context)
        {
            FirstCard = context.FirstCard;
            SecondCard = context.SecondCard;
        }

        public virtual void StartRound(IStartRoundContext context)
        {
            CommunityCards = context.CommunityCards;
        }

        public abstract PlayerAction PostingBlind(IPostingBlindContext context);
        public abstract PlayerAction GetTurn(IGetTurnContext context);

        public virtual void EndRound(IEndRoundContext context) { }
        public virtual void EndHand(IEndHandContext context) { }
        public virtual void EndGame(IEndGameContext context) { }
    }
}
