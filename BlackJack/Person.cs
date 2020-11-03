using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Person
    {
        public Deck Deck { get; }

        public Person(Deck deck)
        {
            Deck = deck;
        }

        protected Person()
        {
            var cards = new List<Card>();
            Deck = new Deck(cards);
        }

        // public void PrintHandCard()
        // {
        //     foreach (var cardString in Deck.Select(card => card.ToString()))
        //     {
        //         Console.WriteLine(cardString);
        //     }
        // }

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
            foreach (var card in Deck.Cards)
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

            if (sum <= 11 && Deck.Cards.Any(i=> i.CardFace==CardFace.Ace))
            {

                sum = sum - 1 + 11;
            }

            return sum;
        }

        // public void DrawCard(Card card)
        // {
        //     CardsInHand.Add(card);
        // }
    }
}