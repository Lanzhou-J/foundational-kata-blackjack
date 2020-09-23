using System.Collections.Generic;

namespace BlackJack
{
    public class Player : Person
    {
        public void Hit()
        {
            //Draw one Card - DrawCard();
            // CardsinHand of player will change.
            // Originial shuffled deck will also change.
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