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
    }
}