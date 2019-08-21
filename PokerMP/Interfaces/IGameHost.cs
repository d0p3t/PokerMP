using System.Collections.Generic;
using PokerMP.Models;

namespace PokerMP.Interfaces
{
    public interface IGameHost
    {
        IList<PokerRoom> Rooms { get; }
        void AddParticipant(PokerClient client, PokerRoom room);

    }
}
