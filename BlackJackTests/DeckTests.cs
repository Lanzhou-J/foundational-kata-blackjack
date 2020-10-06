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
            Deck newDeck = new Deck();
            List<Card> listOfCards = newDeck.Cards;
            Assert.Equal(52, listOfCards.Count); 
        }

        [Fact]
        public void NewDeckShould_ReturnListOfCardsWhichContainsCorrectCards()
        {
            Deck newDeck = new Deck();
            List<Card> listOfCards = newDeck.Cards;
            Assert.Contains(listOfCards, item => item.CardFace == CardFace.Ace && item.Suit == Suit.Heart);
        }

        [Fact]
        public void PopCardShould_ReturnFirstCardFromDeckOfCards()
        {
            Deck newDeck = new Deck();
            List<Card> listOfCards = newDeck.Cards;
            var expectedCard = listOfCards[0];
            var actualCard = newDeck.PopCard();
            Assert.Equal(expectedCard.Suit, actualCard.Suit);
            Assert.Equal(expectedCard.CardFace, actualCard.CardFace);
        }
    }
}