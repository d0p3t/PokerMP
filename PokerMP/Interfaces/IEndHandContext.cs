using System.Collections.Generic;
using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IEndHandContext
    {
        Dictionary<string, ICollection<Card>> ShowdownCards { get; }
    }
}
