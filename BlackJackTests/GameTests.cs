using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class GameTests
    {
        [Fact]
        public void Start_Should_InitializeTwoCardsInHandForPlayerAndDealer()
        {
            Player newPlayer = new Player(name: "Liv");
            Dealer newDealer = new Dealer(name: "Lan");
            Deck newDeck = new Deck();
            Game newGame = new Game(newPlayer, newDealer, newDeck);
            newGame.Start();
            Assert.Equal(2, newDealer.CardsInHand.Count);
            Assert.Equal(2, newPlayer.CardsInHand.Count);
            Assert.Equal(48, newDeck.Cards.Count);
        }
        
        [Fact]
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndReturnCorrectString_WhenTied()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinner_GetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);
            
            Assert.Equal("Player and dealer have tied. Nobody wins.", actualResult);
        }
        
        [Fact]
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndReturnCorrectString_WhenDealerHasLargerHand()
        {
            Card newCard = new Card(CardFace.Seven, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinner_GetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);
            
            Assert.Equal("Dealers hand of cards is larger. Dealer has won!!", actualResult);
        }
        
        [Fact]
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndReturnCorrectString_WhenPlayerHasLargerHand()
        {
            Card newCard = new Card(CardFace.Ten, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            var actualResult = CheckForWinner_GetActualResult(newCard, newCard2, newCardForListTwo, newCardTwoForListTwo);

            Assert.Equal("Players hand of cards is larger. Player has won!!", actualResult);
        }

        private static string CheckForWinner_GetActualResult(Card newCard, Card newCard2, Card newCardForListTwo, Card newCardTwoForListTwo)
        {
            List<Card> listOfCardsForPlayer = new List<Card>() {newCard, newCard2};
            List<Card> listOfCardsForDealer = new List<Card>() {newCardForListTwo, newCardTwoForListTwo};

            Player newPlayer = new Player(name: "Liv", listOfCardsForPlayer);
            Dealer newDealer = new Dealer(name: "Lan", listOfCardsForDealer);

            Deck newDeck = new Deck();

            Game newGame = new Game(newPlayer, newDealer, newDeck);
            var actualResult = newGame.CheckForWinner();
            return actualResult;
        }
    }
}