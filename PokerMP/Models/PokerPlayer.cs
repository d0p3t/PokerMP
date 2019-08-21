using System;
using PokerMP.Enums;

namespace PokerMP.Models
{
    public class PokerPlayer
    {
        public PokerClient Client;

        public Guid ID => Client.ID;
        public int NetId => Client.NetID;
        public string Name => Client.Name;

        public Card FirstCard { get; set; }
        public Card SecondCard { get; set; }

        public long Balance { get; set; }
        public int Bet { get; set; }
        public bool Folder { get; set; }
        public HandRankType HandRank { get; set; }
    }
}
