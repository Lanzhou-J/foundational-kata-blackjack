using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Player
    {
        public Deck Deck { get; }

        public Player(Deck deck)
        {
            Deck = deck;
        }
        
        public void Hit(Card card)
        {
            Deck.DrawCard(card);
        }

        public Player()
        {
            var cards = new List<Card>();
            Deck = new Deck(cards);
        }
    }
}