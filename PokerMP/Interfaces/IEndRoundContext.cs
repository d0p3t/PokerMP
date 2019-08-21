using System.Collections.Generic;
using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IEndRoundContext
    {
        IReadOnlyCollection<PlayerActionAndName> RoundActions { get; }
    }
}
