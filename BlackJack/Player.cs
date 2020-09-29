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

        public void Stay()
        {
            // Stop Draw card, print final result.
            // Dealer play starts. - Call Play() in Dealer;
        }


        public Player(string name, List<Card> cardsInHand) : base(name, cardsInHand)
        {
        }
    }
}