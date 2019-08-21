using System.Collections.Generic;
using PokerMP.Interfaces;
using PokerMP.Models;

namespace PokerMP.Contexts
{
    public class EndRoundContext : IEndRoundContext
    {
        public EndRoundContext(IReadOnlyCollection<PlayerActionAndName> roundActions)
        {
            this.RoundActions = roundActions;
        }

        public IReadOnlyCollection<PlayerActionAndName> RoundActions { get; }
    }
}
