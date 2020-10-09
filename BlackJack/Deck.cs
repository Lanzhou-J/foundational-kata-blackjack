using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = CreateADeck();
        }
        
        private List<Card> CreateADeck()
        {
            List<Card> newList = new List<Card>();
            foreach(CardFace name in Enum.GetValues(typeof(CardFace)))
            {
                foreach(Suit suitName in Enum.GetValues(typeof(Suit)))
                {
                    var newCard = new Card(name, suitName);
                    newList.Add(newCard);
                }
            }
            var shuffledList = newList.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledList;
        }

        public Card PopCard()
        {
            var firstCard = Cards[0];
            Cards.Remove(firstCard);
            return firstCard;
        }
    }
}