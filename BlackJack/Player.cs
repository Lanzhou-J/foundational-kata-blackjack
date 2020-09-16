using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        private string Name { get; set; }
        private bool IsDealer { get; set; }
        public List<Card> CardsInHand;
        
        public Player(string name, bool isDealer, List<Card> cardsInHand)
        {
            Name = name;
            IsDealer = isDealer;
            CardsInHand = cardsInHand;
        }

        public void PrintHandCard()
        {
            foreach(var card in CardsInHand)
            {
                var cardString = card.DisplayCard();
                Console.Write(cardString);
                Console.Write(" ");
            }
        }
    }
}