using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Person
    {
        public string Name { get; set; }
        
        public List<Card> CardsInHand;
        
        public Person(string name, List<Card> cardsInHand)
        {
            Name = name;
            CardsInHand = cardsInHand;
        }


        public void PrintHandCard()
        {
            foreach(var card in CardsInHand)
            {
                var cardString = card.FormatCardString();
                Console.Write(cardString);
                Console.Write(" ");
            }
        }

        public bool DetermineBust()
        {
            if (Sum() > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
            
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