using PokerMP.Interfaces;

namespace PokerMP.Models
{
    public abstract class PlayerDecorator : IPlayer
    {
        protected PlayerDecorator(IPlayer player)
        {
            Player = player;
        }

        public virtual string Name => Player.Name;

        public int BuyIn => Player.BuyIn;

        protected IPlayer Player { get; }

        public virtual void StartGame(IStartGameContext context)
        {
            Player.StartGame(context);
        }

        public virtual void StartHand(IStartHandContext context)
        {
            Player.StartHand(context);
        }

        public virtual void StartRound(IStartRoundContext context)
        {
            Player.StartRound(context);
        }

        public virtual PlayerAction PostingBlind(IPostingBlindContext context)
        {
            return Player.PostingBlind(context);
        }

        public virtual PlayerAction GetTurn(IGetTurnContext context)
        {
            return Player.GetTurn(context);
        }

        public virtual void EndRound(IEndRoundContext context)
        {
            Player.EndRound(context);
        }

        public virtual void EndHand(IEndHandContext context)
        {
            Player.EndHand(context);
        }

        public virtual void EndGame(IEndGameContext context)
        {
            Player.EndGame(context);
        }
    }
}
