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
    }
}