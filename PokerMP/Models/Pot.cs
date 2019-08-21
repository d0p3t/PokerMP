using System.Collections.Generic;

namespace PokerMP.Models
{
    public struct Pot
    {
        public int AmountOfMoney { get; }
        public IReadOnlyList<string> ActivePlayer { get; }

        public Pot(int amountOfMoney, IReadOnlyList<string> activePlayer)
        {
            AmountOfMoney = amountOfMoney;
            ActivePlayer = activePlayer;
        }
    }
}
