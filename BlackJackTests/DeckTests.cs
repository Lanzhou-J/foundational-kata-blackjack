using System;
using System.Collections.Generic;
using BlackJack;
using Xunit;
using Xunit.Abstractions;

namespace BlackJackTests
{
    public class DeckTests
    {

        [Fact]
        public void NewDeckShould_ReturnAListOfCardsWithCorrectNumberOfItems()
        {
            var newDeck = new Deck();
            var listOfCards = newDeck.Cards;
            Assert.Equal(52, listOfCards.Count); 
        }

        [Fact]
        public void NewDeckShould_ReturnListOfCardsWhichContainsCorrectCards()
        {
            var newDeck = new Deck();
            var listOfCards = newDeck.Cards;
            Assert.Contains(listOfCards, item => item.CardFace == CardFace.Ace && item.Suit == Suit.Heart);
        }
        
        [Fact]
        public void PopCardShould_RemoveOneCardFromCardsInDeck()
        {
            var newDeck = new Deck();
            var listOfCards = newDeck.Cards;
            var originalCardsCount = listOfCards.Count;
            newDeck.PopCard();
            var currentCardsCount = listOfCards.Count;
            Assert.Equal(originalCardsCount-1, currentCardsCount);
        }
    }
}