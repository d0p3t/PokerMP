using System.Collections.Generic;
using PokerMP.Interfaces;

namespace PokerMP.Contexts
{
    public class StartGameContext : IStartGameContext
    {
        public StartGameContext(IReadOnlyCollection<string> playerNames, int startMoney)
        {
            this.PlayerNames = playerNames;
            this.StartMoney = startMoney;
        }

        public IReadOnlyCollection<string> PlayerNames { get; }

        public int StartMoney { get; }
    }
}
