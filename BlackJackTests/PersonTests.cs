using System.Collections.Generic;
using BlackJack;
using Xunit;
namespace BlackJackTests
{
    public class PersonTests
    {
        
        [Fact]
        public void DetermineBlackjackShould_ReturnTrue_When21()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Ten, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.True(newPerson.DetermineBlackjack());
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnFalse_WhenLessThan21()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.False(newPerson.DetermineBlackjack());
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnFalse_WhenMoreThan21()
        {
            Card newCard = new Card(CardFace.Three, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.False(newPerson.DetermineBlackjack());
        }
        
        [Fact]
        public void DetermineBustShould_ReturnTrue_WhenOver21()
        {
            Card newCard = new Card(CardFace.Three, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.True(newPerson.DetermineBust());
        }
        
        [Fact]
        public void DetermineBustShould_ReturnFalse_WhenLessThan21()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.False(newPerson.DetermineBust());
        }
        
        [Fact]
        public void DetermineBustShould_ReturnFalse_When21()
        {
            Card newCard = new Card(CardFace.Two, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.False(newPerson.DetermineBust());
        }
        
        [Fact]
        public void Sum_Should_ReturnSumValueOfCardsInHandWhenThereIsOnlyOneCard()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(9,newPerson.Sum());
        }
        
        [Fact]
        public void Sum_Should_ReturnSumValueOfCardsInHandWhenThereIsMoreThanOneCard()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(19,newPerson.Sum());
        }
        
        [Fact]
        public void DetermineAceShould_Return1_WhenSumMoreThan10()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(1,newPerson.DetermineAce());
        }
        
        [Fact]
        public void AceShould_Return11_WhenSumLessThanOrEqualTo10()
        {
            Card newCard = new Card(CardFace.Five, Suit.Club);
            Card newCard2 = new Card(CardFace.Four, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(11,newPerson.DetermineAce());
        }
    }
}