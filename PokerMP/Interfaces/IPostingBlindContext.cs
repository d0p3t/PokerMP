using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IPostingBlindContext
    {
        PlayerAction BlindAction { get; }

        int CurrentStackSize { get; }

        int CurrentPot { get; }
    }
}
