using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CitizenFX.Core;
using PokerMP.Enums;
using PokerMP.Extensions;

namespace PokerMP.Models
{
    internal class PokerRoom : BaseScript
    {
        public Guid ID = Guid.NewGuid();

        public string Title;

        public int MaxParticipants;

        public int MoneyNeeded;

        public int TimeLeft;

        public float Ante { get; }

        public PokerPlayer PlayerInTurn;

        public int Button;

        public PokerPlayer ButtonPlayer => Participants.ElementAt(Button);

        public ConcurrentQueue<PokerPlayer> Participants;

        public Deck Deck { get; }

        public List<Card> DrawnCards { get; }

        public RoomStatus Status = RoomStatus.Registering;

        public RoomType Type;

        public PokerRoom(string title, int balance, RoomType type, int registerTime = 600)
        {
            Title = title;
            Type = type;

            switch (Type)
            {
                case RoomType.HeadsUp:
                    MaxParticipants = 2;
                    break;
                case RoomType.FiveMan:
                    MaxParticipants = 5;
                    break;
                case RoomType.TenMan:
                    MaxParticipants = 10;
                    break;
                default:
                    break;
            }

            MoneyNeeded = balance;
            TimeLeft = registerTime;

            Participants = new ConcurrentQueue<PokerPlayer>();
        }

        public override string ToString()
        {
            return $"'{Title}' ( ID: {ID} )";
        }

        public bool IsParticipating(int netId) => Participants.Any(p => p.NetId == netId);

        public bool AddParticipant(PokerClient client, int balance)
        {
            if(IsParticipating(client.NetID) || Status != RoomStatus.Registering || Participants.Count == MaxParticipants)
            {
                return false;
            }

            Participants.Enqueue(new PokerPlayer
            {
                Client = client,
                Balance = balance
            });

            return true;
        }

        public async Task OnRoomTick()
        {
            try
            {
                switch (Status)
                {
                    case RoomStatus.Registering:
                        if (TimeLeft > 0)
                        {
                            TimeLeft -= 1;
                        }

                        if (TimeLeft == 0)
                        {
                            Status = RoomStatus.StartingSoon;
                            TimeLeft = 10;
                        }
                        break;
                    case RoomStatus.StartingSoon:
                        if (TimeLeft > 0)
                        {
                            TimeLeft -= 1;
                        }

                        if (TimeLeft == 0)
                        {
                            StartGame();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await Task.FromResult(0);
        }

        public void StartGame()
        {
            Status = RoomStatus.Playing;

            var random = new Random();

            Button = random.Next(0, Participants.Count - 1);
        }

        public async Task PlayingTask()
        {
            foreach (var participant in Participants)
            {
                participant.FirstCard = Deck.GetNextCard();
                participant.SecondCard = Deck.GetNextCard();

                var player = Players.FirstOrDefault(x => x.Handle == participant.NetId.ToString());
                if(player != null)
                {
                    player.TriggerEvent("pokermp_game_show_cards_personal", participant.FirstCard.ToString(), participant.SecondCard.ToString());
                }
            }

            await Delay(10000);

            var flopCards = Deck.DrawCards(3);

            DrawnCards.AddRange(flopCards);

            // make button pay small blind
            // make button + 1 pay big blind

            // wait until everyone has paid blind

            // show flopCards to every participant
            foreach (var participant in Participants)
            {
                var player = Players.FirstOrDefault(x => x.Handle == participant.NetId.ToString());
                if (player != null)
                {
                    player.TriggerEvent("pokermp_game_show_cards_flop", "theflopcards");
                }
            }

            // foreach participant check/bet/raise

            // draw turn card and show to each player
            var turnCard = Deck.GetNextCard();
            DrawnCards.Add(turnCard);

            foreach (var participant in Participants)
            {
                var player = Players.FirstOrDefault(x => x.Handle == participant.NetId.ToString());
                if (player != null)
                {
                    player.TriggerEvent("pokermp_game_show_cards_turn", "theturncard");
                }
            }

            // betting round again

            // river
            var riverCard = Deck.GetNextCard();
            DrawnCards.Add(riverCard);
            foreach (var participant in Participants)
            {
                var player = Players.FirstOrDefault(x => x.Handle == participant.NetId.ToString());
                if (player != null)
                {
                    player.TriggerEvent("pokermp_game_show_cards_river", "therivercard");
                }
            }

            // betting round again
            // end game
        }
    }
}
