using System;

namespace BlackJack
{
    public class Game
    {
        public Game(Player player, Dealer dealer)
        {
            Player = player;
            Dealer = dealer;
        }

        private Player Player { get; set; }
        private Dealer Dealer { get; set; }

        private Deck ShuffledDeck { get; set; }

        public void Start()
        {
            //ShuffledDeck -> give card to DrawCard function
            Console.Clear();
            Player.DrawCard();
            Player.DrawCard();
            Dealer.DrawCard();
            Dealer.DrawCard();

            //let dealer have 2 cards
            var newPlayerInput = new PlayerInput();
            var choice = newPlayerInput.CollectInput();

            switch (choice)
            {
                case 1:
                    Player.Hit();
                    break;
                case 0:
                    Player.Stay();
                    break;
            }
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