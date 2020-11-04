using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player : Person
    {
        public void Hit(Card card)
        {
            Deck.DrawCard(card);
        }
        
        public Player(Deck deck) : base(deck)
        {
        }
        
        public Player()
        {
        }
    }
}