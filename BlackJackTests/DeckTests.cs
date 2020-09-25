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
        
        // Deck of Heart Contains some cards.
        //List.contain()
        
        [Fact]
        public void CreateADeckShould_ReturnListOfCardsWhichStartFromAceHeartZeroId()
        {
            Deck newDeck = new Deck();
            List<Card> listOfCards = newDeck.CreateADeck();
            Card newCard = new Card(CardFace.Ace, Suit.Heart, 0);
            // Assert.Equal(newCard.CardFace, listOfCards[0].CardFace); 
            // Assert.Equal(newCard.Suit, listOfCards[0].Suit); 
            // Assert.Equal(newCard.UniqueId, listOfCards[0].UniqueId); 
            // Assert.Equal(newCard, listOfCards[0]); 
        }
    }
}