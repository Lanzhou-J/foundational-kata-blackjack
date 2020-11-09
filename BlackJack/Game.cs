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
            ClearOutputPlatform();
            PlayerTake2CardsFromShuffledDeck();
            DealerTake2CardsFromShuffledDeck();
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
        
        private void ClearOutputPlatform()
        {
            _iio.Clear();
        }

        public void Play()
        {
            PlayerTakeTurnsToPlay();
            if (GameState != GameState.Continue) return;
            DealerTakeTurnsToPlay();
            CheckForWinner();
            OutputWinner();
        }
        
        private void PlayerTakeTurnsToPlay()
        {
            OutputPlayersCardsAndSum();
            if (Rule.DetermineBlackjack(Player.Deck))
            {
                _iio.Output(GameInstructions.PlayerGotBlackJack());
            }
            
            var choice = AskPlayersChoice();
            while (PlayerChooseHitAndGameContinues(choice))
            {
                var newHitCard = ShuffledDeck.PopCard();
                Player.Hit(newHitCard);
                OutputPlayersCardsAndSum();

                if (Rule.DetermineBlackjack(Player.Deck))
                {
                    _iio.Output(GameInstructions.PlayerGotBlackJack());
                }

                if (Rule.DetermineBust(Player.Deck))
                {
                    _iio.Output(GameInstructions.PlayerBustMessage());
                    GameState = GameState.DealerWon;
                }
                else
                {
                    choice = AskPlayersChoice();
                }
            }
        }

        private void DealerTakeTurnsToPlay()
        {
            _iio.Output(GameInstructions.DealersTurnMessage());
            OutputDealersCardsAndSum();
            
            var dealerDeckSum = CalculateDealerDeckSum();
            while (dealerDeckSum < 17)
            {
                _iio.Output(GameInstructions.DealerDrawNewCard());
                var newCard = ShuffledDeck.PopCard();
                Dealer.Deck.DrawCard(newCard);

                dealerDeckSum = CalculateDealerDeckSum();
                OutputDealersCardsAndSum();

                if (Rule.DetermineBust(Dealer.Deck))
                {
                    _iio.Output(GameInstructions.DealerBustMessage());
                    GameState = GameState.PlayerWon;
                }
            }
        }
        
        private void OutputDealersCardsAndSum()
        {
            var sum = CalculatePlayerDeckSum();
            var deckString = Player.Deck.ToString();
            _iio.Output(GameInstructions.DealerCardsAndSum(sum, deckString));
        }

        private int CalculateDealerDeckSum()
        {
            return Rule.CalculateSum(Dealer.Deck);
        }

        private void OutputPlayersCardsAndSum()
        {
            var sum = CalculatePlayerDeckSum();
            var deckString = Player.Deck.ToString();
            _iio.Output(GameInstructions.PlayerCardsAndSum(sum, deckString));
        }

        private int CalculatePlayerDeckSum()
        {
            return Rule.CalculateSum(Player.Deck);
        }

        private bool PlayerChooseHitAndGameContinues(string choice)
        {
            return choice != GameInstructions.PlayerStay && GameState == GameState.Continue;
        }

        private string AskPlayersChoice()
        {
            var choice = _iio.Ask(GameInstructions.AskChoiceMessage());
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
                    _iio.Output(GameInstructions.GameResultTie());
                    break;
                case GameState.PlayerWon:
                    _iio.Output(GameInstructions.GameResultPlayerWin());
                    break;
                case GameState.DealerWon:
                    _iio.Output(GameInstructions.GameResultDealerWin());
                    break;
                case GameState.Continue:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}