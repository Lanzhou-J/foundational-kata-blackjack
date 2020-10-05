using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Person
    {
        public string Name { get; set; }
        
        public readonly List<Card> CardsInHand;
        
        public Person(string name, List<Card> cardsInHand)
        {
            Name = name;
            CardsInHand = cardsInHand;
        }
        
        public Person(string name)
        {
            Name = name;
            CardsInHand = new List<Card>();
        }

        public void PrintHandCard()
        {
            foreach(var card in CardsInHand)
            {
                var cardString = card.FormatCardString();
                Console.WriteLine(cardString);
            }
        }

        public bool DetermineBust()
        {
            return Sum() > 21;
        }
        
        public bool DetermineBlackjack()
        {
            return Sum() == 21;
        }

        public int Sum()
        {
            var sum = 0;
            foreach (var card in CardsInHand)
            {
                if (card.CardFace == CardFace.Jack || card.CardFace == CardFace.Queen || card.CardFace == CardFace.King)
                {
                    sum = sum + 10;
                }
                else
                {
                    int i = Convert.ToInt32(card.CardFace);
                    sum = sum + i;
                }
            }
            
            return sum;
        }

        public void DrawCard(Card newCard)
        {
            CardsInHand.Add(newCard);
        }
    }
}