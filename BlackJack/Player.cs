using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player : Person
    {
        public bool Hit(Card card)
        {
            Deck.DrawCard(card);
            var deckSum = Deck.Sum;
            Console.WriteLine($"You are currently at {deckSum}");
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