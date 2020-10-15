using System;

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

        private Player Player { get; }
        private Dealer Dealer { get; }

        private Deck ShuffledDeck { get; }
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
                // Environment.Exit(1);
            }

            var newCardThree = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardThree);

            var newCardFour = ShuffledDeck.PopCard();
            Dealer.DrawCard(newCardFour);
        }

        }


        public void GamePlay()
        {
            var choice = _iio.Ask("Hit or stay? (Hit = 1, Stay = 0)");
            while (choice != "0")
            {
                var newHitCard = ShuffledDeck.PopCard();
                var playerIsBusted = Player.Hit(newHitCard);
                _iio.Output("with a hand of: ");
                Player.PrintHandCard();               
        
                if (Player.DetermineBlackjack())
                {
                    _iio.Output("Player has won Blackjack!!! Yay!");
                    // Environment.Exit(1);
                    //TO-DO: need to set state of the game to mark the end of the game - out of the loop
                    break;
                }
        

                if (playerIsBusted)
                {
                    _iio.Output("Player is busted. Dealer wins!!"); 
                    // Environment.Exit(1);
                    break;
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
                // Environment.Exit(1);

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