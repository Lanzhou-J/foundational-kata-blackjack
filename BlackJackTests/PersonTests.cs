using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class PersonTests
    {
        List<Card> listOfCardsForTest;

        public PersonTests()
        {
            listOfCardsForTest = new List<Card>();
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnTrue_When21()
        {

            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Ten, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.True(newPerson.DetermineBlackjack());
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnFalse_WhenLessThan21()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.False(newPerson.DetermineBlackjack());
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnFalse_WhenMoreThan21()
        {
            Card newCard = new Card(CardFace.Three, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.False(newPerson.DetermineBlackjack());
        }
        
        [Fact]
        public void DetermineBustShould_ReturnTrue_WhenOver21()
        {
            Card newCard = new Card(CardFace.Three, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.True(newPerson.DetermineBust());
        }
        
        [Fact]
        public void DetermineBustShould_ReturnFalse_WhenLessThan21()
        {
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.False(newPerson.DetermineBust());
        }
        
        [Fact]
        public void DetermineBustShould_ReturnFalse_When21()
        {
            Card newCard = new Card(CardFace.Two, Suit.Club);
            Card newCard2 = new Card(CardFace.Nine, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.False(newPerson.DetermineBust());
        }
        
        [Fact]
        public void Sum_Should_ReturnSumValueOfCardsInHandWhenThereIsOnlyOneCard()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            listOfCardsForTest.Add(newCard);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.Equal(9,newPerson.Sum());
        }
        
        [Fact]
        public void Sum_Should_ReturnSumValueOfCardsInHandWhenThereIsMoreThanOneCard()
        {
            Card newCard = new Card(CardFace.Nine, Suit.Club);
            Card newCard2 = new Card(CardFace.Jack, Suit.Club);
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            Person newPerson = new Person("bob", listOfCardsForTest);
            Assert.Equal(19,newPerson.Sum());
        }
    }
}