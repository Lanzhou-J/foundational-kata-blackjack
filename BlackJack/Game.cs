using System;

namespace BlackJack
{
    public class Game
    {
        public Game(Player player, Dealer dealer, IDeck shuffledDeck, IInputOutput iio, Rule rule, GameState gameState = GameState.Continue)
        {
            Player = player;
            Dealer = dealer;
            ShuffledDeck = shuffledDeck;
            _iio = iio;
            GameState = gameState;
            Rule = new Rule();
        }

        private Player Player { get; }
        private Dealer Dealer { get; }

        private Rule Rule { get; }

        private IDeck ShuffledDeck { get; }
        private readonly IInputOutput _iio;
        public GameState GameState { get; private set; }

        public void Start()
        {
            Restart();
            PlayerTake2CardsFromShuffledDeck();
            DealerTake2CardsFromShuffledDeck();
        }

        private void OutputPlayersFirst2CardsAndSum()
        {
            _iio.Output("Your first two cards are: ");
            OutputPlayersDeck();
            OutputPlayersSum();
        }

        private void OutputPlayersSum()
        {
            _iio.Output($"You are currently at {CalculatePlayerDeckSum()}");
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

        private void Restart()
        {
            _iio.Clear();
        }

        public void GamePlay()
        {
            PlayerTakeTurnsToPlay();

            if (GameState == GameState.Continue)
            {
                _iio.Output("Dealers turn to play...\n");
                OutputDealersFirst2CardsAndSum();

                int index = 0;
                var dealerDeckSum = CalculateDealerDeckSum();
                while (dealerDeckSum < 17)
                {
                    _iio.Output("Dealer draws a new card: ");
                    Dealer.Deck.DrawCard(ShuffledDeck.Cards[index]);
                    index++;
                    
                    dealerDeckSum = CalculateDealerDeckSum();
                    _iio.Output($"Dealer is currently at {dealerDeckSum}");
                    _iio.Output("with a hand of: ");
                    OutputDealersDeck();
                    
                    if (Rule.DetermineBust(Dealer.Deck))
                    {
                        _iio.Output("The dealer has busted. Player is the winner!!");
                        GameState = GameState.PlayerWon;
                    }
                }
                
                _iio.Output(CheckForWinner());
                
            }
        }

        private void OutputDealersFirst2CardsAndSum()
        {
            _iio.Output("The dealers first two cards are: \n");
            OutputDealersDeck();
            OutputDealersSum();
        }

        private void OutputDealersSum()
        {
            _iio.Output($"Dealer is currently at {CalculateDealerDeckSum()}");
        }

        private void OutputDealersDeck()
        {
            _iio.Output(Dealer.Deck);
        }

        private int CalculateDealerDeckSum()
        {
            return Rule.CalculateSum(Dealer.Deck);
        }

        private void PlayerTakeTurnsToPlay()
        {
            OutputPlayersFirst2CardsAndSum();
            if (Rule.DetermineBlackjack(Player.Deck))
            {
                _iio.Output("Player has got Blackjack!!! Yay!");
            }
            var choice = AskPlayersChoice();
            while (PlayerChooseHitAndGameContinues(choice))
            {
                var newHitCard = ShuffledDeck.PopCard();
                Player.Hit(newHitCard);
                var deckSum = CalculatePlayerDeckSum();
                _iio.Output($"You are currently at {deckSum}");
                _iio.Output("with a hand of: ");
                OutputPlayersDeck();

                if (Rule.DetermineBlackjack(Player.Deck))
                {
                    _iio.Output("Player has got Blackjack!!! Yay!");
                    // GameState = GameState.Continue;
                }

                if (Rule.DetermineBust(Player.Deck))
                {
                    _iio.Output("Player is busted. Dealer wins!!");
                    GameState = GameState.DealerWon;
                }
                else
                {
                    choice = AskPlayersChoice();
                }
            }
        }

        private int CalculatePlayerDeckSum()
        {
            return Rule.CalculateSum(Player.Deck);
        }

        private bool PlayerChooseHitAndGameContinues(string choice)
        {
            return choice != "0" && GameState == GameState.Continue;
        }

        private string AskPlayersChoice()
        {
            var choice = _iio.Ask("Hit or stay? (Hit = 1, Stay = 0)");
            return choice;
        }

        public string CheckForWinner()
        {
            var outcome = "";
            if (Rule.CalculateSum(Dealer.Deck) == Rule.CalculateSum(Player.Deck))
            {
                outcome = ("Player and dealer have tied. Nobody wins.");
                GameState = GameState.Tie;
                return outcome;
            } 
            if(Rule.CalculateSum(Dealer.Deck) > Rule.CalculateSum(Player.Deck))
            {
                outcome = ("Dealers hand of cards is larger. Dealer has won!!");
                GameState = GameState.DealerWon;
                return outcome;
            }

            if(Rule.CalculateSum(Dealer.Deck) < Rule.CalculateSum(Player.Deck))
            {
                outcome = ("Players hand of cards is larger. Player has won!!");
                GameState = GameState.PlayerWon;
                return outcome;
            }
            return outcome;
        }
    }
}