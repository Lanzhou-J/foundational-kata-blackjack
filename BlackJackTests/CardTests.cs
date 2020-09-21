using System;
using System.Text.RegularExpressions;
using BlackJack;
using Xunit;


namespace BlackJackTests
{
    public class CardTests
    {
        [Fact]
        public void FormatCardStringShould_ReturnCorrectStringPattern()
        {
            string cardStringPattern = @"^\[(\w+), (\w+)\]$";
            Card newCard = new Card(CardFace.Ace, Suit.Diamond);
            bool isMatch = Regex.IsMatch(newCard.FormatCardString(), cardStringPattern);
            Assert.True(isMatch);
        }
    }
}