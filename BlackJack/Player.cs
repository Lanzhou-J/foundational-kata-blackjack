using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player : Person
    {
        public bool Hit(Card newCard)
        {
            DrawCard(newCard);
            Sum();
            Console.WriteLine($"You are currently at {Sum()}");
            return DetermineBust();
        }
        
        public Player(List<Card> cardsInHand) : base(cardsInHand)
        {
        }
        
        public Player() : base()
        {
        }
    }
}