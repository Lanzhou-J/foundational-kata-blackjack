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
            
//             if player_in:
//             response = int(raw_input('Hit or stay? (Hit = 1, Stay = 0)'))
//             # If the player asks to be hit, take the first card from the top of
//             # deck and add it to their hand. If they ask to stay, change
//             # player_in to false, and move on to the dealer's hand.
//             if response:
//             player_in = True
//             new_player_card = deck.pop()
//             player_hand.append(new_player_card)
//             print 'You draw %s' % new_player_card
//             else:
//             player_in = False
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