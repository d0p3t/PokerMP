namespace PokerMP.Models
{
    public struct PlayerActionAndName
    {
        public PlayerActionAndName(string playerName, PlayerAction action)
        {
            PlayerName = playerName;
            Action = action;
        }

        public string PlayerName { get; }

        public PlayerAction Action { get; }
    }
}
