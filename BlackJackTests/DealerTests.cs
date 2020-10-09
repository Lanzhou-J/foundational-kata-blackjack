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
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Two, Suit.Club);
            Card newCard3 = new Card(CardFace.Three, Suit.Club);
            Card newCard4 = new Card(CardFace.Four, Suit.Club);
            Card newCard5 = new Card(CardFace.Five, Suit.Club);
            Card newCard6 = new Card(CardFace.Two, Suit.Heart);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3, newCard4, newCard5, newCard6};
            Dealer newDealer = new Dealer("Liv");
            newDealer.Play(listOfCardsForTest);
            Assert.Equal(6, newDealer.CardsInHand.Count);
        }
    }
}