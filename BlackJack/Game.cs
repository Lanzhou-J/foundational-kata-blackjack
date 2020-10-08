using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        public Game(Player player, Dealer dealer, Deck shuffledDeck, IInputOutput iio)
        {
            Player = player;
            Dealer = dealer;
            ShuffledDeck = shuffledDeck;
            _iio = iio;
        }

        private Player Player { get; set; }
        private Dealer Dealer { get; set; }

        private Deck ShuffledDeck { get; set; }
        private readonly IInputOutput _iio;

        public void Start()
        {
            Console.Clear();
            var newCard = ShuffledDeck.PopCard();
            Player.DrawCard(newCard);

            var newCardTwo = ShuffledDeck.PopCard();
            Player.DrawCard(newCardTwo);
            _iio.Output("Your first two cards are: ");
            Player.PrintHandCard();
            _iio.Output($"You are currently at {Player.Sum()}");
            
            if (Player.DetermineBlackjack())
            {
                _iio.Output("Player has won!! Yay!");
                Environment.Exit(1);
            }
 
            var newCardThree = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardThree);

            var newCardFour = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardFour);
            
            var choice = _iio.Ask("Hit or stay? (Hit = 1, Stay = 0)");

            while (choice != "0")
            {
                var newHitCard = ShuffledDeck.PopCard();
                Player.Hit(newHitCard);
                _iio.Output("with a hand of: ");
                Player.PrintHandCard();
                var playerIsBusted = Player.Hit(newHitCard);
                if (playerIsBusted)
                {
                    _iio.Output("Player is busted. Dealer wins!!"); 
                    Environment.Exit(1);
                }
                else
                {
                    choice = _iio.Ask("Hit or stay? (Hit = 1, Stay = 0)");
                }
            }

            var dealerIsBusted = Dealer.Play(ShuffledDeck.Cards);
            if (dealerIsBusted)
            {
                _iio.Output("The dealer has busted. Player is the winner!!");
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