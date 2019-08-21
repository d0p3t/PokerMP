using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using PokerMP.Enums;
using PokerMP.Interfaces;
using PokerMP.Models;

namespace PokerMP
{
    internal class TenManGameHost : BaseScript
    {
        public IList<PokerRoom> Rooms { get; }

        public TenManGameHost() {
            Rooms = new List<PokerRoom>();

            Debug.WriteLine("10 Man Host - Enabled");
        }

        public void CreateGame(string title, int timeToRegister = 600)
        {
            PokerRoom newRoom = new PokerRoom(title, 100, RoomType.TenMan);

            Rooms.Add(newRoom);
        }


        public bool AddParticipant(PokerClient client, Guid guid)
        {
            try
            {
                var room = Rooms.FirstOrDefault(x => x.ID == guid);

                if(room == null)
                {
                    return false;
                }

                return room.AddParticipant(client, room.MoneyNeeded);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        public void RemoveParticipantFromAll(PokerClient client)
        {
            foreach (var room in Rooms)
            {
                if(room.IsParticipating(client.NetID))
                {
                    PokerPlayer pokerPlayer = room.Participants.First(x => x.NetId == client.NetID);

                    room.Participants.TryDequeue(out pokerPlayer);
                }
            }
        }


        [EventHandler("pokermp_tenman_getrooms")]
        public void GetRooms([FromSource]Player player)
        {
            var toSend = new List<PokerRoom>();

            foreach (var room in Rooms)
            {
                toSend.Add(new PokerRoom(room.Title, room.MoneyNeeded, RoomType.TenMan, room.TimeLeft)
                {
                    Participants = room.Participants,
                    Status = room.Status
                }); // Don't send sensitive information
            }

            player.TriggerEvent("pokermp_tenman_allrooms", JsonConvert.SerializeObject(toSend));
        }

        [Tick]
        public async Task OnUpdateTimeLeftTick()
        {
            try
            {
                // Not exact timing
                await Delay(1000);

                foreach (var room in Rooms)
                {
                    
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine($"^1Exception: {e.Message}^7");
                await Delay(5000);
            }

            await Task.FromResult(0);
        }
    }
}
