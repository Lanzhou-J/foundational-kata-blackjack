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
            Console.Clear();
            var newCard = ShuffledDeck.PopCard();
            Player.DrawCard(newCard);
            
            var newCardTwo = ShuffledDeck.PopCard();
            Player.DrawCard(newCardTwo);
            
            var newCardThree = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardThree);
            
            var newCardFour = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardFour);

            var newPlayerInput = new PlayerInput();
            var choice = newPlayerInput.CollectInput();

            switch (choice)
            {
                case 1:
                    var newHitCard = ShuffledDeck.PopCard();
                    Player.Hit(newHitCard);
                    Console.WriteLine("with a hand of: ");
                    Player.PrintHandCard();
                    break;
                case 0:
                    Dealer.Play();
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