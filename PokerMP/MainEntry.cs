using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using PokerMP.Enums;
using PokerMP.Models;

namespace PokerMP
{
    public class MainEntry : BaseScript
    {
        private readonly bool EnableTournaments;
        private readonly bool EnableHeadsUp;
        private readonly bool EnableSelfStorage;

        private HeadsUpHost HeadsUpHost;
        private TenManGameHost TenManHost;
        private SelfStorage SelfStorage;

        public List<PokerClient> Clients;

        public MainEntry()
        {
            Clients = new List<PokerClient>();

            EnableTournaments = API.GetConvarInt("pokermp_enable_tournaments", 1) == 1;
            EnableHeadsUp = API.GetConvarInt("pokermp_enable_headsup", 1) == 1;
            EnableSelfStorage = API.GetConvarInt("pokermp_enable_selfstorage", 1) == 1;
        }

        [Tick]
        public async Task OnFirstTick()
        {
            Tick -= OnFirstTick;

            if(EnableHeadsUp)
            {
                HeadsUpHost = new HeadsUpHost();
                RegisterScript(HeadsUpHost);
            }

            if(EnableTournaments)
            {
                TenManHost = new TenManGameHost();
                RegisterScript(TenManHost);
            }

            if(EnableSelfStorage)
            {
                SelfStorage = new SelfStorage();
                RegisterScript(SelfStorage);
            }

            await Task.FromResult(0);
        }

        [EventHandler("pokermp_register_as_client")]
        public void RegisterClient([FromSource]Player player)
        {
            string name = player.Name;
            int netId = Convert.ToInt32(player.Handle);

            PokerClient pokerClient = new PokerClient { NetID = netId, Name = name };

            if(!Clients.Exists(x => x.NetID == netId))
            {
                Clients.Add(pokerClient);
                player.TriggerEvent("pokermp_register_success", "You are now registered in the system.");
            } else
            {
                player.TriggerEvent("pokermp_error", "You are already a registered client.");
            }
        }

        [EventHandler("pokermp_joinroom")]
        public void JoinRoom([FromSource]Player player, string guidString, int type)
        {
            int netId = Convert.ToInt32(player.Handle);

            PokerClient pokerClient = Clients.FirstOrDefault(x => x.NetID == netId);

            if(pokerClient == null)
            {
                API.CancelEvent();
                return;
            }

            Guid guid = Guid.Parse(guidString);

            RoomType roomType = (RoomType)type;

            bool success = false;

            switch (roomType)
            {
                case RoomType.HeadsUp:
                    break;
                case RoomType.FiveMan:
                    break;
                case RoomType.TenMan:
                    success = TenManHost.AddParticipant(pokerClient, guid);
                    break;
                default:
                    break;
            }

            player.TriggerEvent("pokermp_joinroom_result", success, guidString);
        }

        [EventHandler("playerDropped")]
        public void PlayerDropped([FromSource]Player player, string reason)
        {
            int netId = Convert.ToInt32(player.Handle);

            PokerClient client = Clients.FirstOrDefault(x => x.NetID == netId);

            if (client != null)
            {
                TenManHost.RemoveParticipantFromAll(client);
                // other hosts too
            }
        }
    }
}
