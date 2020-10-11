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
            Game newGame = new Game(newPlayer, newDealer, newDeck, console);
            newGame.Start();
            Assert.Equal(2, newDealer.CardsInHand.Count);
            Assert.Equal(2, newPlayer.CardsInHand.Count);
            Assert.Equal(48, newDeck.Cards.Count);
        }
        
        [Fact]
        public void CheckForWinnerShould_CompareDealerAndPlayerSumAndReturnCorrectString_WhenTied()
        {
            var newCard = new Card(CardFace.Nine, Suit.Club);
            var newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            var newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            var newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinnerGetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);

            Assert.Equal("Player and dealer have tied. Nobody wins.", actualResult);
        }
        
        [Fact]
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndReturnCorrectString_WhenDealerHasLargerHand()
        {
            Card newCard = new Card(CardFace.Seven, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinnerGetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);
            
            Assert.Equal("Dealers hand of cards is larger. Dealer has won!!", actualResult);
        }
        
        [Fact]
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndReturnCorrectString_WhenPlayerHasLargerHand()
        {
            Card newCard = new Card(CardFace.Ten, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinnerGetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);

            Assert.Equal("Players hand of cards is larger. Player has won!!", actualResult);
        }

        private static string CheckForWinnerGetActualResult(Card newCard, Card newCard2, Card newCardForListTwo, Card newCardTwoForListTwo)
        {
            var listOfCardsForTest = new List<Card>() {newCard, newCard2};
            var listTwoOfCardsForTest = new List<Card>() {newCardForListTwo, newCardTwoForListTwo};

            var newPlayer = new Player(listOfCardsForTest);
            var newDealer = new Dealer(listTwoOfCardsForTest);
            var console = new ConsoleInputOutput();
            var newDeck = new Deck();

            var newGame = new Game(newPlayer, newDealer, newDeck, console);
            var actualResult = newGame.CheckForWinner();
            return actualResult;
        }
        
        [Fact]
        public void GamePlayShould_ShouldNotEnablePlayerDrawCard_WhenPlayerInputStayResponse()
        {
            
            Player newPlayer = new Player();
            Dealer newDealer = new Dealer();
            Deck newDeck = new Deck();
            var playerResponse = new TestResponder(StayResponse);
            Game newGame = new Game(newPlayer, newDealer, newDeck, playerResponse);
            newGame.Start();
            Assert.Equal(2, newPlayer.CardsInHand.Count);
            newGame.GamePlay();
            Assert.Equal(2, newPlayer.CardsInHand.Count);
        }
        
        [Fact]
        public void GamePlayShould_EnablePlayerDrawCard_WhenPlayerInputHitStayResponse()
        {
            
            Player newPlayer = new Player();
            Dealer newDealer = new Dealer();
            Deck newDeck = new Deck();
            var playerResponse = new TestResponder(new[]{HitResponse,StayResponse});
            Game newGame = new Game(newPlayer, newDealer, newDeck, playerResponse);
            newGame.Start();
            Assert.Equal(2, newPlayer.CardsInHand.Count);
            newGame.GamePlay();
            Assert.Equal(3, newPlayer.CardsInHand.Count);
        }
    }
}