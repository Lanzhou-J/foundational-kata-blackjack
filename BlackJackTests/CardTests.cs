using System.Text.RegularExpressions;
using BlackJack;
using Xunit;


namespace BlackJackTests
{
    public class CardTests
    {
        [Theory]
        [InlineData(CardFace.Ace, Suit.Diamond, "[Ace, Diamond]")]
        [InlineData(CardFace.Six, Suit.Heart, "[Six, Heart]")]
        [InlineData(CardFace.King, Suit.Spade, "[King, Spade]")]
        public void FormatCardStringShould_ReturnCorrectString(CardFace cardFace, Suit suit, string expectedResult)
        {
            var newCard = new Card(cardFace, suit);
            
            Assert.Equal(expectedResult, newCard.FormatCardString());
        }
        
    }
}