using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class DeckTests
    {
        [Fact]
        public void CreateADeckShould_ReturnAListOfCardsWithCorrectNumberOfItems()
        {
            Deck newDeck = new Deck();
            List<Card> listOfCards = newDeck.CreateADeck();
            Assert.Equal(52, listOfCards.Count); 
        }
    }
}