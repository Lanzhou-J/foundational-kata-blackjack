using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class GameTests
    {
        private const string StayResponse = "0";
        private const string HitResponse = "1";
        [Fact]
        public void Start_Should_InitializeTwoCardsInHandForPlayerAndDealer()
        {
            Player newPlayer = new Player();
            Dealer newDealer = new Dealer();
            Deck newDeck = new Deck();
            var console = new ConsoleInputOutput();
            var rule = new Rule();
            Game newGame = new Game(newPlayer, newDealer, newDeck, console, rule);
            newGame.Start();
            Assert.Equal(2, newDealer.Deck.Cards.Count);
            Assert.Equal(2, newPlayer.Deck.Cards.Count);
            Assert.Equal(48, newDeck.Cards.Count);
        }
        
        [Fact]
        public void CheckForWinnerShould_CompareDealerAndPlayerSumAndChangeGameStateToTie_WhenTied()
        {
            var newCard = new Card(CardFace.Nine, Suit.Club);
            var newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            var newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            var newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinnerGetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);
            Assert.Equal(GameState.Tie, actualResult);
        }
        
        [Fact]
        public void CheckForWinnerShould_ChangeGameStateToDealerWon_WhenDealerHasLargerHand()
        {
            Card newCard = new Card(CardFace.Seven, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            var actualResult = CheckForWinnerGetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);

            
            Assert.Equal(GameState.DealerWon, actualResult);
        }
        
        [Fact]
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndChangeGameState_WhenPlayerHasLargerHand()
        {
            Card newCard = new Card(CardFace.Ten, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            var actualResult = CheckForWinnerGetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);


            Assert.Equal(GameState.PlayerWon, actualResult);
        }

        private static GameState CheckForWinnerGetActualResult(Card newCard, Card newCard2, Card newCardForListTwo, Card newCardTwoForListTwo)
        {
            var listOfCardsForTest = new List<Card>() {newCard, newCard2};
            var listTwoOfCardsForTest = new List<Card>() {newCardForListTwo, newCardTwoForListTwo};

            var newPlayer = new Player(new Deck(listOfCardsForTest));
            var newDealer = new Dealer(new Deck(listTwoOfCardsForTest));
            var console = new ConsoleInputOutput();
            var newDeck = new Deck();
            var rule = new Rule();

            var newGame = new Game(newPlayer, newDealer, newDeck, console, rule);
            newGame.CheckForWinner();
            return newGame.GameState;
        }
        
        [Fact]
        public void GamePlayShould_NotEnablePlayerDrawCard_WhenPlayerInputStayResponse()
        {
            
            Player newPlayer = new Player();
            Dealer newDealer = new Dealer();
            Deck newDeck = new Deck();
            var playerResponse = new TestResponder(new[]{StayResponse});
            var rule = new Rule();
            Game newGame = new Game(newPlayer, newDealer, newDeck, playerResponse, rule);
            newGame.Start();
            Assert.Equal(2, newPlayer.Deck.Cards.Count);
            newGame.Play();
            Assert.Equal(2, newPlayer.Deck.Cards.Count);
        }
        
        [Fact]
        public void GamePlayShould_EnablePlayerDrawCard_WhenPlayerInputHitStayResponse()
        {
            Player newPlayer = new Player();
            Dealer newDealer = new Dealer();
            Deck newDeck = new Deck();
            Rule rule = new Rule();
            var playerResponse = new TestResponder(new[]{HitResponse,StayResponse});
            Game newGame = new Game(newPlayer, newDealer, newDeck, playerResponse,rule);
            newGame.Start();
            Assert.Equal(2, newPlayer.Deck.Cards.Count);
            newGame.Play();
            Assert.Equal(3, newPlayer.Deck.Cards.Count);
        }
        
        [Fact]
        public void GamePlayShould_EnablePlayerDrawCardTwice_WhenPlayerInputHitResponseTwice()
        {
            Card playerCard1 = new Card(CardFace.Three, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Ten, Suit.Club);
            Card dealerCard1 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard2 = new Card(CardFace.Ten, Suit.Heart);
            Card playerCard3 = new Card(CardFace.Eight, Suit.Spade);
            Card playerCard4 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard1, dealerCard2, playerCard3, playerCard4};
            Player newPlayer = new Player();
            Dealer newDealer = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            Rule rule = new Rule();
            var playerResponse = new TestResponder(new[]{HitResponse, HitResponse, StayResponse});
            Game newGame = new Game(newPlayer, newDealer, deck, playerResponse, rule);
            newGame.Start();
            Assert.Equal(2, newPlayer.Deck.Cards.Count);
            newGame.Play();
            Assert.Equal(4, newPlayer.Deck.Cards.Count);
        }
        
        [Fact]
        public void GamePlayShould_UseMockListOfCards_AndPresentPlayerWinsOutcome()
        {
            Card playerCard1 = new Card(CardFace.Three, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Ten, Suit.Club);
            Card dealerCard3 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard4 = new Card(CardFace.Ten, Suit.Heart);
            Card playerCard5 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard3, dealerCard4, playerCard5};
            Player player1 = new Player();
            Dealer dealer1 = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            var rule = new Rule();
            IInputOutput iio = new TestResponder(new[]{HitResponse, StayResponse});
            Game newGame = new Game(player1, dealer1, deck, iio, rule);
            newGame.Start();
            Assert.Equal(GameState.Continue, newGame.GameState);
            newGame.Play();
            Assert.Equal(GameState.PlayerWon, newGame.GameState);
        }
        
        [Fact]
        public void GamePlayShould_UseMockListOfCards_AndPresentDealerWinsOutcome()
        {
            Card playerCard1 = new Card(CardFace.Three, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Four, Suit.Club);
            Card dealerCard3 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard4 = new Card(CardFace.Ace, Suit.Heart);
            Card playerCard5 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard3, dealerCard4, playerCard5};
            Player player1 = new Player();
            Dealer dealer1 = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            var rule = new Rule();
            IInputOutput iio = new TestResponder(new[]{HitResponse, StayResponse});
            Game newGame = new Game(player1, dealer1, deck, iio, rule);
            newGame.Start();
            Assert.Equal(GameState.Continue, newGame.GameState);
            newGame.Play();
            Assert.Equal(GameState.DealerWon, newGame.GameState);
        }
        
        [Fact]
        public void GamePlayShould_ChangeGameStateToTie_WhenBothPlayerAndDealerHaveBlackjackAfterHitOnce()
        {
            Card playerCard1 = new Card(CardFace.Three, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Ten, Suit.Club);
            Card dealerCard3 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard4 = new Card(CardFace.Ace, Suit.Heart);
            Card playerCard5 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard3, dealerCard4, playerCard5};
            Player player1 = new Player();
            Dealer dealer1 = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            var rule = new Rule();
            IInputOutput iio = new TestResponder(new[]{HitResponse, StayResponse});
            Game newGame = new Game(player1, dealer1, deck, iio, rule);
            newGame.Start();
            Assert.Equal(GameState.Continue, newGame.GameState);
            newGame.Play();
            Assert.Equal(GameState.Tie, newGame.GameState);
        }
        
        [Fact]
        public void GamePlayShould_ChangeGameStateToTie_WhenBothPlayerAndDealerHaveBlackjackAfterStart()
        {
            Card playerCard1 = new Card(CardFace.Ten, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Ace, Suit.Club);
            Card dealerCard3 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard4 = new Card(CardFace.Ace, Suit.Heart);
            Card playerCard5 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard3, dealerCard4, playerCard5};
            Player player1 = new Player();
            Dealer dealer1 = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            var rule = new Rule();
            IInputOutput iio = new TestResponder(new[]{StayResponse});
            Game newGame = new Game(player1, dealer1, deck, iio, rule);
            newGame.Start();
            Assert.Equal(GameState.Continue, newGame.GameState);
            newGame.Play();
            Assert.Equal(GameState.Tie, newGame.GameState);
        }
        
        [Fact]
        public void GamePlayShould_UseMockListOfCards_AndNeitherPlayerOrDealerHaveBlackjack()
        {
            Card playerCard1 = new Card(CardFace.Three, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Four, Suit.Club);
            Card dealerCard3 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard4 = new Card(CardFace.Ten, Suit.Heart);
            Card playerCard5 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard3, dealerCard4, playerCard5};
            Player player1 = new Player();
            Dealer dealer1 = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            var rule = new Rule();
            IInputOutput iio = new TestResponder(new[]{HitResponse, StayResponse});
            Game newGame = new Game(player1, dealer1, deck, iio, rule);
            newGame.Start();
            Assert.Equal(GameState.Continue, newGame.GameState);
            newGame.Play();
            Assert.Equal(GameState.DealerWon, newGame.GameState);
        }
        
        [Fact]
        public void GamePlayShould_UseNewMockListOfCards_AndPlayerShouldBustAndDealerWins()
        {
            Card playerCard1 = new Card(CardFace.Four, Suit.Heart);
            Card playerCard2 = new Card(CardFace.Ten, Suit.Club);
            Card dealerCard3 = new Card(CardFace.Ten, Suit.Spade);
            Card dealerCard4 = new Card(CardFace.Ten, Suit.Heart);
            Card playerCard5 = new Card(CardFace.Eight, Suit.Spade);
            List<Card> listOfMockCards = new List<Card>(){playerCard1, playerCard2, dealerCard3, dealerCard4, playerCard5};
            Player player1 = new Player();
            Dealer dealer1 = new Dealer();
            MockDeck deck = new MockDeck(listOfMockCards);
            var rule = new Rule();
            IInputOutput iio = new TestResponder(new[]{HitResponse, StayResponse});
            Game newGame = new Game(player1, dealer1, deck, iio, rule);
            newGame.Start();
            Assert.Equal(GameState.Continue, newGame.GameState);
            newGame.Play();
            Assert.Equal(GameState.DealerWon, newGame.GameState);
        }
        
        // To-Do: Test private method through GamePlay -> measure the card number of dealer.
        // [Fact]
        //  public void GamePlayShould_LetDealerContinueToDrawCard_WhenTheSumBelow17WithOneAce()
        //  {
        //      var newCard = new Card(CardFace.Ace, Suit.Club);
        //      var newCard2 = new Card(CardFace.Two, Suit.Club);
        //      var newCard3 = new Card(CardFace.Three, Suit.Club);
        //      var newCard4 = new Card(CardFace.Four, Suit.Club); //=>20 or 10? Does Dealer have a choice?
        //                                                         //Assumption: let dealer have better chance to win
        //      var newCard5 = new Card(CardFace.Five, Suit.Club);
        //      var newCard6 = new Card(CardFace.Two, Suit.Heart);
        //      var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
        //      var newDealer1 = new Dealer();
        //      newDealer1.Play(listOfCardsForTest);
        //      Assert.Equal(4, newDealer1.Deck.Cards.Count);
        //  }
        //  
        //  [Fact]
        //  public void GamePlayShould_LetDealerContinueToDrawCard_WhenTheSumBelow17WithNoAces()
        //  {
        //      var newCard = new Card(CardFace.Two, Suit.Club);
        //      var newCard2 = new Card(CardFace.Six, Suit.Club);
        //      var newCard3 = new Card(CardFace.Three, Suit.Club);
        //      var newCard4 = new Card(CardFace.Five, Suit.Club); 
        //      var newCard5 = new Card(CardFace.Five, Suit.Club);
        //      var newCard6 = new Card(CardFace.Two, Suit.Heart);
        //      var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
        //      var newDealer1 = new Dealer();
        //      newDealer1.Play(listOfCardsForTest);
        //      Assert.Equal(5, newDealer1.Deck.Cards.Count);
        //  }
        //  
        //  [Fact]
        //  public void GamePlayShould_LetDealerContinueToDrawCard_WhenTheSumBelow17WithThreeAces()
        //  {
        //      var newCard = new Card(CardFace.Ace, Suit.Club);
        //      var newCard2 = new Card(CardFace.Ace, Suit.Spade);
        //      var newCard3 = new Card(CardFace.Three, Suit.Club);
        //      var newCard4 = new Card(CardFace.Ace, Suit.Heart); 
        //      var newCard5 = new Card(CardFace.Five, Suit.Club);
        //      var newCard6 = new Card(CardFace.Two, Suit.Heart);
        //      var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
        //      var newDealer1 = new Dealer();
        //      newDealer1.Play(listOfCardsForTest);
        //      Assert.Equal(5, newDealer1.Deck.Cards.Count);
        //  }
    }
}