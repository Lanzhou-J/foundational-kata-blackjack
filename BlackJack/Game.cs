using System;

namespace BlackJack
{
    public class Game
    {
        public Game(Player player, Dealer dealer, IDeck shuffledDeck, IInputOutput iio, GameState gameState = GameState.Continue)
        {
            Player = player;
            Dealer = dealer;
            ShuffledDeck = shuffledDeck;
            _iio = iio;
            GameState = gameState;
        }

        private Player Player { get; }
        private Dealer Dealer { get; }

        private IDeck ShuffledDeck { get; }
        private readonly IInputOutput _iio;
        public GameState GameState { get; private set; }

        public void Start()
        {
            ClearPreviousOutput();
            PlayerTake2CardsFromShuffledDeck();
            DealerTake2CardsFromShuffledDeck();
            
            OutputPlayersFirst2CardsAndSum();
            OutputMessageWhenPlayerGotBlackjack();
        }

        private void OutputPlayersFirst2CardsAndSum()
        {
            _iio.Output("Your first two cards are: ");
            OutputPlayersDeck();
            OutputPlayersSum();
        }

        private void OutputPlayersSum()
        {
            _iio.Output($"You are currently at {Player.Sum()}");
        }

        private void OutputPlayersDeck()
        {
            _iio.Output(Player.Deck);
        }

        private void DealerTake2CardsFromShuffledDeck()
        {
            var newCardThree = ShuffledDeck.PopCard();
            Dealer.Deck.DrawCard(newCardThree);

            var newCardFour = ShuffledDeck.PopCard();
            Dealer.Deck.DrawCard(newCardFour);
        }

        private void PlayerTake2CardsFromShuffledDeck()
        {
            var newCard = ShuffledDeck.PopCard();
            Player.Deck.DrawCard(newCard);
            var newCardTwo = ShuffledDeck.PopCard();
            Player.Deck.DrawCard(newCardTwo);
        }

        private void ClearPreviousOutput()
        {
            _iio.Clear();
        }

        public void GamePlay()
        {
            var choice = AskPlayersChoice();
            while (choice != "0" && GameState == GameState.Continue)
            {
                var newHitCard = ShuffledDeck.PopCard();
                var playerIsBusted = Player.Hit(newHitCard);
                _iio.Output("with a hand of: ");
                OutputPlayersDeck();

                OutputMessageWhenPlayerGotBlackjack();

                if (playerIsBusted)
                {
                    _iio.Output("Player is busted. Dealer wins!!");
                    GameState = GameState.DealerWon;
                }
                else
                {
                    choice = AskPlayersChoice();
                }
            }

            if (GameState == GameState.Continue)
            {
                var dealerIsBusted = Dealer.Play(ShuffledDeck.Cards);
                if (dealerIsBusted)
                {
                    _iio.Output("The dealer has busted. Player is the winner!!");
                    GameState = GameState.PlayerWon;
                }
                else
                {
                    _iio.Output(CheckForWinner());
                }
            }
        }

        private void OutputMessageWhenPlayerGotBlackjack()
        {
            if (Player.DetermineBlackjack())
            {
                _iio.Output("Player has got Blackjack!!! Yay!");
                GameState = GameState.Continue;
            }
        }

        private string AskPlayersChoice()
        {
            var choice = _iio.Ask("Hit or stay? (Hit = 1, Stay = 0)");
            return choice;
        }

        public string CheckForWinner()
        {
            var outcome = "";
            if (Dealer.Sum() == Player.Sum())
            {
                outcome = ("Player and dealer have tied. Nobody wins.");
                GameState = GameState.Tie;
                return outcome;
            } 
            if(Dealer.Sum() > Player.Sum())
            {
                outcome = ("Dealers hand of cards is larger. Dealer has won!!");
                GameState = GameState.DealerWon;
                return outcome;
            }

            if(Dealer.Sum() < Player.Sum())
            {
                outcome = ("Players hand of cards is larger. Player has won!!");
                GameState = GameState.PlayerWon;
                return outcome;
            }
            return outcome;
        }
    }
}