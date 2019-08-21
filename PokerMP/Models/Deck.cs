using System.Collections.Generic;
using System.Linq;
using PokerMP.Enums;
using PokerMP.Extensions;
using PokerMP.Interfaces;

namespace PokerMP.Models
{
    public class Deck : IDeck
    {
        public static readonly IReadOnlyList<Card> AllCards;

        private static readonly IEnumerable<CardType> AllCardTypes = new List<CardType>
                                                                         {
                                                                             CardType.Two,
                                                                             CardType.Three,
                                                                             CardType.Four,
                                                                             CardType.Five,
                                                                             CardType.Six,
                                                                             CardType.Seven,
                                                                             CardType.Eight,
                                                                             CardType.Nine,
                                                                             CardType.Ten,
                                                                             CardType.Jack,
                                                                             CardType.Queen,
                                                                             CardType.King,
                                                                             CardType.Ace
                                                                         };

        private static readonly IEnumerable<CardSuit> AllCardSuits = new List<CardSuit>
                                                                         {
                                                                             CardSuit.Club,
                                                                             CardSuit.Diamond,
                                                                             CardSuit.Heart,
                                                                             CardSuit.Spade
                                                                         };

        private readonly IList<Card> listOfCards;

        private int cardIndex;

        static Deck()
        {
            var cards = new List<Card>();
            foreach (CardSuit cardSuit in AllCardSuits)
            {
                foreach (CardType cardType in AllCardTypes)
                {
                    cards.Add(new Card(cardSuit, cardType));
                }
            }

            AllCards = cards.AsReadOnly();
        }

        public Deck()
        {
            listOfCards = AllCards.Shuffle().ToList();
            cardIndex = AllCards.Count;
        }

        public Card GetNextCard()
        {
            if (cardIndex == 0)
            {
                throw new InternalPokerGameException("Deck is empty!");
            }

            cardIndex--;
            Card card = listOfCards[cardIndex];
            return card;
        }
    }
}
