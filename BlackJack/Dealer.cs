using System.Collections.Generic;

namespace BlackJack
{
    public class Dealer: Person
    {

        public void Play()
        {
            // Continuous hitting until 17 then print result.
            // Then start winning logic functions of compare player and Dealer hand card sum value.
            // Every time Play() is called, multiple cards in CardsinHand and shuffled deck will change.
        }

        public Dealer(string name, List<Card> cardsInHand) : base(name, cardsInHand)
        {
        }
    }
}