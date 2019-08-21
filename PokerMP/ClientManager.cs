using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using PokerMP.Models;

namespace PokerMP
{
    internal class ClientManager : BaseScript
    {
        public List<PokerClient> Clients { get; private set; }

        public ClientManager()
        {
            Clients = new List<PokerClient>();
        }

        public bool AddClient(int netId)
        {
            var id = netId.ToString();
            var ip = API.GetPlayerEndpoint(id); // make sure player still exists

            if(ip == null)
            {
                return false;
            }

            string name = API.GetPlayerName(id);

            if(name == string.Empty)
            {
                return false;
            }

            PokerClient newClient = new PokerClient { ID = Guid.NewGuid() , NetID = netId, Name = name };

            Clients.Add(newClient);

            return true;
        }

        public bool RemoveClient(int netId)
        {
            PokerClient existingClient = Clients.Find(x => x.NetID == netId);

            if(existingClient == null)
            {
                return false;
            }

            Clients.Remove(existingClient);

            return true;
        }
    }
}
