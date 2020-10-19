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
        public void SumShould_Return21_WhenPlayerHasTenAndAce()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Ten, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(21,newPerson.Sum());
        }
        
        [Fact]
        public void SumShould_Return21_WhenPlayerHasJackAndAce()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(21,newPerson.Sum());
        }
        
        [Fact]
        public void SumShould_Return17_WhenPlayerHasSevenNineAndAce()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Seven, Suit.Club);
            Card newCard3 = new Card(CardFace.Nine, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(17,newPerson.Sum());
        }
        
        [Fact]
        public void SumShould_Return21_WhenPlayerHasAceNineAndAce()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Ace, Suit.Spade);
            Card newCard3 = new Card(CardFace.Nine, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(21,newPerson.Sum());
        }
        
        [Fact]
        public void SumShould_Return21_WhenPlayerHasAceAceEightAndAce()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Ace, Suit.Spade);
            Card newCard3 = new Card(CardFace.Ace, Suit.Club);
            Card newCard4 = new Card(CardFace.Eight, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3, newCard4};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(21,newPerson.Sum());
        }
        
        [Fact]
        public void SumShould_Return14_WhenPlayerHasAceTwoAndAce()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Two, Suit.Spade);
            Card newCard3 = new Card(CardFace.Ace, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(14,newPerson.Sum());
        }
        
        [Fact]
        public void SumShould_Return19_WhenPlayerHasEightTenAndAce()
        {
            Card newCard = new Card(CardFace.Eight, Suit.Club);
            Card newCard2 = new Card(CardFace.Ten, Suit.Spade);
            Card newCard3 = new Card(CardFace.Ace, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
            Person newPerson = new Person(listOfCardsForTest);
            Assert.Equal(19,newPerson.Sum());
        }
        
    }
}