using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Person
    {
        public string Name { get; set; }

        private readonly List<Card> _cardsInHand;
        
        public Person(string name, List<Card> cardsInHand)
        {
            Name = name;
            _cardsInHand = cardsInHand;
        }

        protected Person(string name)
        {
            Name = name;
            _cardsInHand = new List<Card>();
        }

        public void PrintHandCard()
        {
            foreach(var card in _cardsInHand)
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
            foreach (var card in _cardsInHand)
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
            _cardsInHand.Add(newCard);
        }
    }
}