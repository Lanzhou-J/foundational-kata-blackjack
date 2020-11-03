using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player : Person
    {
        public bool Hit(Card card)
        {
            Deck.DrawCard(card);
            Sum();
            Console.WriteLine($"You are currently at {Sum()}");
            return DetermineBust();
        }
        
        public Player(Deck deck) : base(deck)
        {
        }
        
        public Player()
        {
        }
    }
}