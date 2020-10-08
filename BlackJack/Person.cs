using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Person
    {
        private readonly List<Card> _cardsInHand;
        
        public Person(List<Card> cardsInHand)
        {
            _cardsInHand = cardsInHand;
        }

        protected Person()
        {
            _cardsInHand = new List<Card>();
        }

        public void PrintHandCard()
        {
            foreach (var cardString in _cardsInHand.Select(card => card.FormatCardString()))
            {
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
                    sum += 10;
                }
                else
                {
                    var i = Convert.ToInt32(card.CardFace);
                    sum += i;
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