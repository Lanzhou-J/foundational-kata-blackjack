using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class DealerTests
    {
        [Fact]
        public void PlayShould_ContinueToDrawCard_WhenTheSumBelow17()
        {
            var newCard = new Card(CardFace.Ace, Suit.Club);
            var newCard2 = new Card(CardFace.Two, Suit.Club);
            var newCard3 = new Card(CardFace.Three, Suit.Club);
            var newCard4 = new Card(CardFace.Four, Suit.Club);
            var newCard5 = new Card(CardFace.Five, Suit.Club);
            var newCard6 = new Card(CardFace.Two, Suit.Heart);
            var listOfCardsForTest = new List<Card>() {newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
            var newDealer = new Dealer();
            newDealer.Play(listOfCardsForTest);
            Assert.Equal(6, newDealer.CardsInHand.Count);
        }
    }
}