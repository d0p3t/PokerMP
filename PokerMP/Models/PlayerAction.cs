using PokerMP.Enums;

namespace PokerMP.Models
{
    public class PlayerAction
    {
        public PlayerActionType Type { get; }
        public int Money { get; internal set; }

        private static readonly PlayerAction FoldObject = new PlayerAction(PlayerActionType.Fold);
        private static readonly PlayerAction CheckCallObject = new PlayerAction(PlayerActionType.CheckCall);

        private PlayerAction(PlayerActionType type)
        {
            Type = type;
        }

        private PlayerAction(int money, PlayerActionType type = PlayerActionType.Raise)
        {
            Type = type;
            Money = money;
        }

        public static PlayerAction Fold()
        {
            return FoldObject;
        }

        public static PlayerAction CheckOrCall()
        {
            return CheckCallObject;
        }

        /// <summary>
        /// Creates a new object containing information about the player action and the raise amount
        /// </summary>
        /// <param name="withAmount">
        /// The amount to raise with.
        /// If amount is less than the minimum amount for raising then the game will take this minimum amount from the players money.
        /// If amount is more or equal to the players money the player will be in all-in state
        /// </param>
        /// <returns>A new player action object containing information about the player action and the raise amount</returns>
        public static PlayerAction Raise(int withAmount)
        {
            if (withAmount <= 0)
            {
                return CheckOrCall();
            }

            return new PlayerAction(withAmount);
        }

        public static PlayerAction Post(int blind)
        {
            return new PlayerAction(blind, PlayerActionType.Post);
        }

        public override string ToString()
        {
            return Type == PlayerActionType.Raise || Type == PlayerActionType.Post ? $"{Type}({Money})" : Type.ToString();
        }
    }
}
