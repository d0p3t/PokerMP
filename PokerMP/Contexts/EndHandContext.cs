using System.Collections.Generic;
using PokerMP.Interfaces;
using PokerMP.Models;

namespace PokerMP.Contexts
{
    public class EndHandContext : IEndHandContext
    {
        public Dictionary<string, ICollection<Card>> ShowdownCards { get; private set; }

        public EndHandContext(Dictionary<string, ICollection<Card>> showdownCards)
        {
            ShowdownCards = showdownCards;
        }
    }
}
