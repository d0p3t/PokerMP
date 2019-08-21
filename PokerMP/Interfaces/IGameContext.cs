using System.Collections.Generic;

namespace PokerMP.Interfaces
{
    public interface IGameContext
    {
        string Name { get; }

        int MoneyLeft { get; }

        bool OnButton { get; }

        string FirstCard { get; }
        string SecondCard { get; }

        int CurrentPot { get; }
        int MoneyToCall { get; }

        List<string> CommunityCards { get; }

        bool CanAction { get; }

        string WinnerName { get; }
    }
}
