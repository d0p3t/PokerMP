using System.Collections.Generic;

namespace PokerMP.Contexts
{
    public class GameContext
    {
        public string Name;
        public string OpponentName;

        public int MoneyLeft;
        public int OpponentMoneyLeft;

        public bool OnButton;

        public string FirstCard;
        public string SecondCard;

        public int CurrentPot;

        public int MoneyToCall;

        public List<string> CommunityCards = new List<string>();

        public bool CanAction;

        public string WinnerName;
    }
}
