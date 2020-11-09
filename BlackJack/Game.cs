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
            Rule = rule;
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

        private void OutputPlayersCardsAndSum()
        {
            var sum = CalculatePlayerDeckSum();
            var deckString = Player.Deck.ToString();
            _iio.Output(GameInstructions.PlayerCardsAndSum(sum, deckString));
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
            if (GameState != GameState.Continue) return;
            DealerTakeTurnsToPlay();
            CheckForWinner();
            OutputWinner();
        }

        private void DealerTakeTurnsToPlay()
        {
            _iio.Output(GameInstructions.DealersTurnMessage());
            OutputDealersFirst2CardsAndSum();
            
            var dealerDeckSum = CalculateDealerDeckSum();
            while (dealerDeckSum < 17)
            {
                _iio.Output(GameInstructions.DealerDrawNewCard());
                var newCard = ShuffledDeck.PopCard();
                Dealer.Deck.DrawCard(newCard);

                dealerDeckSum = CalculateDealerDeckSum();
                OutputDealersDeckAndSum(dealerDeckSum);

                if (Rule.DetermineBust(Dealer.Deck))
                {
                    _iio.Output(GameInstructions.DealerBustMessage());
                    GameState = GameState.PlayerWon;
                }
            }
        }

        private void OutputDealersDeckAndSum(int dealerDeckSum)
        {
            _iio.Output($"Dealer is currently at {dealerDeckSum}");
            _iio.Output("with a hand of: ");
            OutputDealersDeck();
        }

        private void OutputDealersFirst2CardsAndSum()
        {
            _iio.Output(Messages.DealerFirstCardsMessage);
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
            OutputPlayersCardsAndSum();
            if (Rule.DetermineBlackjack(Player.Deck))
            {
                _iio.Output(Messages.PlayerGotBlackJack);
            }
            
            
            var choice = AskPlayersChoice();
            while (PlayerChooseHitAndGameContinues(choice))
            {
                var newHitCard = ShuffledDeck.PopCard();
                Player.Hit(newHitCard);
                OutputPlayersCardsAndSum();

                if (Rule.DetermineBlackjack(Player.Deck))
                {
                    _iio.Output(Messages.PlayerGotBlackJack);
                }

                if (Rule.DetermineBust(Player.Deck))
                {
                    _iio.Output(Messages.PlayerBustMessage);
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

        public void CheckForWinner()
        {
            
            if (Rule.CalculateSum(Dealer.Deck) == Rule.CalculateSum(Player.Deck))
            {
                GameState = GameState.Tie;
                
            } 
            if(Rule.CalculateSum(Dealer.Deck) > Rule.CalculateSum(Player.Deck))
            {
                GameState = GameState.DealerWon;
                
            }

            if(Rule.CalculateSum(Dealer.Deck) < Rule.CalculateSum(Player.Deck))
            {
                GameState = GameState.PlayerWon;
            }
        }

        private void OutputWinner()
        {
            switch (GameState)
            {
                case GameState.Tie:
                    _iio.Output("Player and dealer have tied. Nobody wins.");
                    break;
                case GameState.PlayerWon:
                    _iio.Output("Players hand of cards is larger. Player has won!!");
                    break;
                case GameState.DealerWon:
                    _iio.Output("Dealers hand of cards is larger. Dealer has won!!");
                    break;
                case GameState.Continue:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}