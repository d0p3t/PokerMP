using System;

namespace PokerMP.Models
{
    public class PokerClient
    {
        public Guid ID = Guid.NewGuid();

        public int NetID;

        public string Name;

        public int? CurrentRoomID;

        public bool inGame;

        public int[] RGB = new int[3];

        public override string ToString()
        {
            return $"'{Name}' ( ID:{ID} )";
        }
    }
}
