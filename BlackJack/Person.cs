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

        public void DetermineBust()
        {
            // over 21 -> bust
            //if(bust){"You are at currently at Bust!"}
            
        }
    }
}