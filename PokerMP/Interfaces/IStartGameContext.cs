using System.Collections.Generic;

namespace PokerMP.Interfaces
{
    public interface IStartGameContext
    {
        IReadOnlyCollection<string> PlayerNames { get; }
        int StartMoney { get; }
    }
}
