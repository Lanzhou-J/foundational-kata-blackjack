using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace BlackJack
{
    public class Deck:IDeck
    {
        public List<Card> Cards { get; }

        public Deck()
        {
            Cards = CreateADeck();
        }
        
        public Deck(List<Card> cards)
        {
            Cards = cards;
        }
        public List<Card> CreateADeck()
        {
            var newList = (from CardFace name in Enum.GetValues(typeof(CardFace)) from Suit suitName in Enum.GetValues(typeof(Suit)) select new Card(name, suitName)).ToList();
            var shuffledList = newList.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledList;
        }

        public Card PopCard()
        {
            var firstCard = Cards[0];
            Cards.Remove(firstCard);
            return firstCard;
        }
        
        public void DrawCard(Card card)
        {
            Cards.Add(card);
        }

        public override string ToString()
        {
            var deckString = "";
            foreach (var cardString in Cards.Select(card => card.ToString()))
            {
                deckString += $"{cardString}/n";
            }

            return deckString;
        }
    }
}