using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        private List<Card> Cards { get; set; }

        public Deck(List<Card> cards)
        {
            Cards = cards;
        }
        public List<Card> CreateADeck()
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
            return newList;
        }

        public Card PopCard()
        {
            var firstCard = Cards[0];
            Cards.Remove(firstCard);
            return firstCard;
        }
    }
}