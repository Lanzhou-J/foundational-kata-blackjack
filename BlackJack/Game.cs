using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        public Game(Player player, Dealer dealer, Deck shuffledDeck)
        {
            Player = player;
            Dealer = dealer;
            ShuffledDeck = shuffledDeck;
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
            Console.WriteLine("Your first two cards are: ");
            Player.PrintHandCard();
            Console.WriteLine($"You are currently at {Player.Sum()}");
            
            if (Player.DetermineBlackjack())
            {
                if (Dealer.DetermineBlackjack())
                {
                    Console.WriteLine("Dealer and Player have tied in Blackjack!!!");
                    Environment.Exit(1);
                }
                Console.WriteLine("Player has won Blackjack!!! Yay!");
                Environment.Exit(1);
            }
 
            var newCardThree = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardThree);

            var newCardFour = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardFour);
        }

        public void GamePlay()
        {
            var newPlayerInput = new PlayerInput();
            var choice = newPlayerInput.CollectInput();

            while (choice != 0)
            {
                var newHitCard = ShuffledDeck.PopCard();

                var playerIsBusted = Player.Hit(newHitCard);
                Console.WriteLine("with a hand of: ");
                Player.PrintHandCard();               
                
                if (Player.DetermineBlackjack())
                {
                    Console.WriteLine("Player has won Blackjack!!! Yay!");
                    Environment.Exit(1);
                }
                
                if (playerIsBusted)
                {
                    Console.WriteLine("Player is busted. Dealer wins!!"); 
                    Environment.Exit(1);
                }
                else
                {
                    choice = newPlayerInput.CollectInput();
                }
            }
            
            var dealerIsBusted = Dealer.Play(ShuffledDeck.Cards);
            if (dealerIsBusted)
            {
                Console.WriteLine("The dealer has busted. Player is the winner!!");
                Environment.Exit(1);
            }
            CheckForWinner();
        }

        public string CheckForWinner()
        {
            var outcome = "";
            if (Dealer.Sum() == Player.Sum())
            {
                outcome = ("Player and dealer have tied. Nobody wins.");
                return outcome;
            } 
            if(Dealer.Sum() > Player.Sum())
            {
                outcome = ("Dealers hand of cards is larger. Dealer has won!!");
                return outcome;
            }

            if(Dealer.Sum() < Player.Sum())
            {
                outcome = ("Players hand of cards is larger. Player has won!!");
                return outcome;
            }
            return outcome;
        }
    }
}