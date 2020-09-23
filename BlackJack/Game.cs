using System;

namespace BlackJack
{
    public class Game
    {
        public void Start()
        {
            Console.Clear();
            var newPlayerInput = new PlayerInput();
            newPlayerInput.CollectInput();
        }

        public void CheckForWinner()
        {
            // dealer_score_label, dealer_score = hand_value(dealer_hand)
            //
            // if player_score < 100 and dealer_score == 100:
            // print 'You beat the dealer!'
            // elif player_score > dealer_score:
            // print 'You beat the dealer!'
            // elif player_score == dealer_score:
            // print 'You tied the dealer, nobody wins.' -- tie logic
            // elif player_score < dealer_score:
            // print "Dealer wins!"
        }

        public void CheckForGameEnd()
        {
            //if(Determinebust boolean is true) then game ends;
            // else if a winner is selected then game ends;
            // else if it is a tie, then game ends;
        }
    }
}