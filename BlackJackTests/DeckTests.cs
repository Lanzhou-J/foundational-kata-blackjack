using System.Collections.Generic;
using BlackJack;
using Xunit;

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
            Card newCard = new Card(CardFace.Ace, Suit.Heart);
            Assert.Contains(newCard, listOfCards); 
        }
    }
}