using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
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

        public Card PopCard(List<Card> newListOfCards)
        {
            Random rnd = new Random();
            int cardInt = rnd.Next(52);
            var randomCard = newListOfCards[cardInt];
            return randomCard;
        }
    }
}