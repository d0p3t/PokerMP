using PokerMP.Interfaces;

namespace PokerMP.Contexts
{
    public class EndGameContext : IEndGameContext
    {
        public string WinnerName { get; }

        public EndGameContext(string winnerName)
        {
            WinnerName = winnerName;    
        }
    }
}
