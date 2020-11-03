using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class DealerTests
    {
        [Fact]
        public void PlayShould_ContinueToDrawCard_WhenTheSumBelow17WithOneAce()
        {
            var newCard = new Card(CardFace.Ace, Suit.Club);
            var newCard2 = new Card(CardFace.Two, Suit.Club);
            var newCard3 = new Card(CardFace.Three, Suit.Club);
            var newCard4 = new Card(CardFace.Four, Suit.Club); //=>20 or 10? Does Dealer have a choice?
                                                               //Assumption: let dealer have better chance to win
            var newCard5 = new Card(CardFace.Five, Suit.Club);
            var newCard6 = new Card(CardFace.Two, Suit.Heart);
            var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
            var newDealer1 = new Dealer();
            newDealer1.Play(listOfCardsForTest);
            Assert.Equal(4, newDealer1.Deck.Cards.Count);
        }
        
        [Fact]
        public void PlayShould_ContinueToDrawCard_WhenTheSumBelow17WithNoAces()
        {
            var newCard = new Card(CardFace.Two, Suit.Club);
            var newCard2 = new Card(CardFace.Six, Suit.Club);
            var newCard3 = new Card(CardFace.Three, Suit.Club);
            var newCard4 = new Card(CardFace.Five, Suit.Club); 
            var newCard5 = new Card(CardFace.Five, Suit.Club);
            var newCard6 = new Card(CardFace.Two, Suit.Heart);
            var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
            var newDealer1 = new Dealer();
            newDealer1.Play(listOfCardsForTest);
            Assert.Equal(5, newDealer1.Deck.Cards.Count);
        }
        
        [Fact]
        public void PlayShould_ContinueToDrawCard_WhenTheSumBelow17WithThreeAces()
        {
            var newCard = new Card(CardFace.Ace, Suit.Club);
            var newCard2 = new Card(CardFace.Ace, Suit.Spade);
            var newCard3 = new Card(CardFace.Three, Suit.Club);
            var newCard4 = new Card(CardFace.Ace, Suit.Heart); 
            var newCard5 = new Card(CardFace.Five, Suit.Club);
            var newCard6 = new Card(CardFace.Two, Suit.Heart);
            var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
            var newDealer1 = new Dealer();
            newDealer1.Play(listOfCardsForTest);
            Assert.Equal(5, newDealer1.Deck.Cards.Count);

        }
    }
}