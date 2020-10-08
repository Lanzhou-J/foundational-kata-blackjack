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
        public void CheckForWinner_Should_CompareDealerAndPlayerSumAndReturnCorrectString()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            
            Card newCardForListTwo = new Card(CardFace.Nine, Suit.Spade);
            Card newCardTwoForListTwo = new Card(CardFace.Jack, Suit.Heart);
            
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
            List<Card> listTwoOfCardsForTest = new List<Card>(){newCardForListTwo, newCardTwoForListTwo};
            
            Player newPlayer = new Player( listOfCardsForTest);
            Dealer newDealer = new Dealer(listTwoOfCardsForTest);
            var console = new ConsoleInputOutput();
            Deck newDeck = new Deck();
            
            Game newGame = new Game(newPlayer, newDealer, newDeck, console);
            var actualResult = newGame.CheckForWinner();
            
            Assert.Equal("Player and dealer have tied. Nobody wins.", actualResult);
        }
    }
}